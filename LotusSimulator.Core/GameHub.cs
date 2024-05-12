using LotusSimulator.Contract.Constants;
using LotusSimulator.Contract.MessageIn;
using LotusSimulator.Contract.MessageOut;
using LotusSimulator.Core.Services;
using Microsoft.AspNetCore.SignalR;

namespace LotusSimulator
{
    public class GameHub : Hub
    {
        public GameContainer _gameContainer;

        public GameHub(GameContainer gameContainer)
        {
            _gameContainer = gameContainer;
        }

        public async Task<PlayerJoinGameResultDto> PlayerJoinGame(PlayerJoinGameRequestDto playerJoinGameRequest)
        {
            var connectionId = Context.ConnectionId;
            var slot = _gameContainer.AssignPlayerToGame(connectionId);

            var gamePreparationResult = new GamePreparationResultDto();
            gamePreparationResult.PlayerStatus = new GamePreparationPlayerStatusDto();
            gamePreparationResult.PlayerStatus.Nickname = playerJoinGameRequest.Nickname;
            gamePreparationResult.PlayerStatus.Status = GamePreparationPlayerStatus.Joined;
            gamePreparationResult.PlayerStatus.Slot = slot;

            await Clients.All.SendAsync(Constants.GamePreparationUpdatedMethod, gamePreparationResult);

            var result = new PlayerJoinGameResultDto()
            {
                AccessToken = "abc-token",
                Slot = slot
            };
            return result;
        }
    }
}
