using LotusSimulator.Core.Entities.Turn;
using LotusSimulator.Core.MessageOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public class DrawStepRunner : IStepRunner
    {
        private readonly LibraryService _libraryService;
        private readonly PriorityService _priorityService;
        private readonly IUserInputService _userInputService;
        private readonly GameStateMapper _gameStateMapper;

        public DrawStepRunner(LibraryService libraryService, PriorityService priorityService,
            IUserInputService userInputService, GameStateMapper gameStateMapper)
        {
            _libraryService = libraryService;
            _priorityService = priorityService;
            _userInputService = userInputService;
            _gameStateMapper = gameStateMapper;
        }

        public async Task Run(Step step)
        {
            var player = step.Phase.Turn.Player;
            var game = player.Game;
            await _libraryService.Draw(player);

            await _priorityService.GrantPriority(player);
        }
    }
}
