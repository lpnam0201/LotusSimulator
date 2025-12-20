using log4net;
using LotusSimulator.Contract.Constants;
using LotusSimulator.Contract.MessageIn;
using LotusSimulator.Contract.MessageOut;
using LotusSimulator.Core.MessageOut;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace LotusSimulator.Core.Services
{
    public class UserInputService : IUserInputService
    {
        private IHubContext<GameHub> _hubContext;
        private ConcurrentDictionary<Guid, IInputCompletionSource> inputCompletionSourceMap = new ConcurrentDictionary<Guid, IInputCompletionSource>();
        private readonly ILog _logger = LogManager.GetLogger(typeof(UserInputService));

        private IReadOnlyDictionary<Type, string> typeToEndpointMap = new Dictionary<Type, string>
        {
            {typeof(GameChangeZoneCollectionDto), Constants.CardChangeZoneMethod},
            {typeof(PlayabilityCollectionDto), Constants.PlayabilityUpdateMethod},
            {typeof(PriorityUpdateDto), Constants.PriorityUpdateMethod},
            {typeof(TestButtonDto), Constants.TestButtonClientReceiveMethod}
        };

        public UserInputService(IHubContext<GameHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public void CompleteWait<T>(T result) where T : IUserInputDto
        {
            if (inputCompletionSourceMap.ContainsKey(result.Guid))
            {
                var inputCompletionSource = inputCompletionSourceMap[result.Guid];
                inputCompletionSource.SetResult(result);
                inputCompletionSourceMap.Remove(result.Guid, out _);
            }
        }

        public async Task<TResponse> WaitForUserInput<TRequest, TResponse>(string connectionId, TRequest request) where TRequest : IUserInputDto
        {
            var inputCompletionSource = new InputCompletionSource<TResponse>();

            var endpoint = typeToEndpointMap[typeof(TRequest)];
            var guid = Guid.NewGuid();
            request.Guid = guid;
            await _hubContext.Clients.Client(connectionId).SendAsync(endpoint, request);

            inputCompletionSourceMap.TryAdd(guid, inputCompletionSource);

            return await inputCompletionSource.Task;
        }
    }
}
