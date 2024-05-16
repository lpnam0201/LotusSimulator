using LotusSimulator.Cards.F;
using LotusSimulator.Cards.L;
using LotusSimulator.Contract.MessageOut;
using LotusSimulator.Core.Entities.Card;
using LotusSimulator.Core.Entities.Players;
using LotusSimulator.Core.Entities.Spell;
using LotusSimulator.Core.Entities.Turn;
using LotusSimulator.Core.Entities.Zones;
using LotusSimulator.Core.MessageOut;
using LotusSimulator.Core.Services;
using LotusSimulator.Entities;

namespace LotusSimulator.Managers
{
    public class GameManager
    {
        private GameStateService _gameStateService;
        private RandomService _randomService;
        private Game _game;
        private readonly GameStateMapper _gameStateMapper;
        private readonly MulliganService _mulliganService;
        private readonly LibraryService _libraryService;

        public GameManager(GameStateService gameStateService,
            RandomService randomService,
            Game game,
            GameStateMapper gameStateMapper,
            MulliganService mulliganService,
            LibraryService libraryService)
        {
            _gameStateService = gameStateService;
            _randomService = randomService;
            _game = game;
            _gameStateMapper = gameStateMapper;
            _mulliganService = mulliganService;
            _libraryService = libraryService;
        }

        public int AddPlayerToGame(string connectionId)
        {
            var player = new Player();
            player.Game = _game;
            player.ConnectionId = connectionId;
            _game.PlayerIds.Add(connectionId, player);
            _game.Players.Add(player);

            return AssignPlayerToGameSlot(player);
        }

        public string GetGameId()
        {
            return _game.Id;
        }

        private int AssignPlayerToGameSlot(Player player)
        {
            KeyValuePair<int, Player>? firstEmptySlot = _game.PlayerSlots.Any(x => x.Value == null)
                ? _game.PlayerSlots.First(x => x.Value == null)
                : null;
            if (firstEmptySlot != null)
            {
                var slot = firstEmptySlot.Value.Key;
                _game.PlayerSlots[slot] = player;
                return slot;
            }

            throw new NotImplementedException();
        }

        private void InitializeLibrary()
        {
            foreach (var player in _game.Players)
            {
                for (int i = 0; i <= 30; i++)
                {
                    var forest = new Card();
                    forest.CardLogic = new Forest();
                    forest.Owner = player;
                    forest.CardLogic.CopyStatsToCard(forest);

                    player.Library.Cards.Add(forest);

                    var elf = new Card();
                    elf.CardLogic = new LlanowarElves();
                    elf.Owner = player;
                    elf.CardLogic.CopyStatsToCard(elf);

                    player.Library.Cards.Add(elf);
                }

                _libraryService.Shuffle(player.Library);
            }
        }

        public async Task StartGameAsync()
        {
            InitializeLibrary();

            DecidePlayerGoFirst();

            DrawFirstHand();

            var gameStateCollection = _gameStateMapper.BuildGameStateCollection(_game);
            await _gameStateService.SendGameStarted(gameStateCollection);

            // Implement mulligan
            //var mulliganResult = await _gameStateService.SendMulliganOffer(_game.PlayerIds.Select(x => x.Key).ToList());
            var firstTurn = CreateFirstTurn();

        }

        private async Task CreateFirstTurn()
        {
            var turn = CreateTurn(_game.PlayerGoFirst);
            _game.CurrentTurn = turn;
        }
        

        private void DecidePlayerGoFirst()
        {
            var playerCount = _game.Players.Count;
            var goFirstIndex = _randomService.RandomInt(playerCount);

            _game.PlayerGoFirst = _game.Players[goFirstIndex];
        }

        private void DrawFirstHand()
        {
            foreach (var player in _game.Players)
            {
                for (var i = 0; i < 7; i++)
                {
                    Draw(player);
                }
            }
        }

        private void Draw(Player player)
        {
            var library = player.Library;

            var cardsDrawn = library.Cards.Take(1).ToList();
            foreach (var card in cardsDrawn)
            {
                player.Hand.Cards.Add(card);
            }
            library.Cards = library.Cards.Skip(1).ToList();
        }


        public bool AttemptCastSpell(string mode)
        {
            return true;
        }

        public void CastSpell(Core.Entities.Card.Card card)
        {
            var spell = CardToSpell(card);
        }

        private void ResolveSpell(Spell spell)
        {

        }

        private Spell CardToSpell(Core.Entities.Card.Card card)
        {
            var spell = new Spell();
            spell.Abilities = card.Abilities;
            spell.Colors = card.Colors;
            spell.Controller = card.Controller;
            spell.ManaCost = card.ManaCost;
            spell.Name = card.Name;
            spell.Owner = card.Owner;

            return spell;
        }

        public void PlayLand(Core.Entities.Card.Card card)
        {
            
        }

        private Permanent CardToPermanent()
        {
            return null;
        }

        private bool CanPlayLand(Player player)
        {
            if (player.LandPlayed >= player.LandPlaysPerTurn)
            {
                return false;
            }

            return true;
        }

        
    }
}
