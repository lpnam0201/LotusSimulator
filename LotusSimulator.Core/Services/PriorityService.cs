using LotusSimulator.Contract.MessageOut;
using LotusSimulator.Core.Entities.Players;
using LotusSimulator.Entities;

namespace LotusSimulator.Core.Services
{
    public class PriorityService
    {
        private readonly PlayabilityService _playabilityService;
        private readonly IUserInputService _userInputService;
        private readonly TurnOrderService _turnOrderService;
        private readonly GameStateMapper _gameStateMapper;
        private readonly INotifyPlayerService _notifyPlayerService;

        public PriorityService(PlayabilityService playableActionService, IUserInputService userInputService, TurnOrderService turnOrderService, GameStateMapper gameStateMapper, INotifyPlayerService notifyPlayerService)
        {
            _playabilityService = playableActionService;
            _userInputService = userInputService;
            _turnOrderService = turnOrderService;
            _gameStateMapper = gameStateMapper;
            _notifyPlayerService = notifyPlayerService;
        }

        public async Task GrantPriority(Player player)
        {
            var game = player.Game;
            game.PriorityHolder = player;

            await _playabilityService.SetPlayabilityAllPlayers(game);
            var playabilityCollection = _gameStateMapper.BuildPlayabilityCollectionDto(game, player.ConnectionId);
            await _notifyPlayerService.NotifyPlayabilityUpdate(playabilityCollection);

            var priorityConnectionId = game.Players.FirstOrDefault(x => x == game.PriorityHolder).ConnectionId;
            await _notifyPlayerService.NotifyPriorityUpdate(new PriorityUpdateDto
            {
                PriorityHolderId = priorityConnectionId
            });
        }

        public async Task PassPriority(Game game)
        {
            game.PriorityHolder = null;
            game.PassedPrioritiesWithNoAction += 1;
        }

        public bool IsAllPlayerPassedInSuccession(Game game)
        {
            return game.Players.Count == game.PassedPrioritiesWithNoAction;
        }
    }
}
