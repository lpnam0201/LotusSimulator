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

        public GameManager(GameStateService gameStateService, RandomService randomService, Game game, GameStateMapper gameStateMapper)
        {
            _gameStateService = gameStateService;
            _randomService = randomService;
            _game = game;
            _gameStateMapper = gameStateMapper;
        }

        public int AddPlayerToGame(string connectionId)
        {
            var player = new Player();
            _game.PlayerIds.Add(connectionId, player);
            _game.Players.Add(player);

            return AssignPlayerToGameSlot(player);
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
                    forest.CardLogic.CopyStatsToCard(forest);

                    player.Library.Cards.Add(forest);

                    var elf = new Card();
                    elf.CardLogic = new LlanowarElves();
                    elf.CardLogic.CopyStatsToCard(forest);

                    player.Library.Cards.Add(elf);
                }

                ShuffleLibrary(player.Library);
            }
        }

        private void ShuffleLibrary(Library library)
        {
            var count = library.Cards.Count;
            library.Cards = library.Cards.OrderBy(x => _randomService.RandomInt(count)).ToList();
        }

        public void Begin()
        {
            InitializeLibrary();

            DecidePlayerGoFirst();

            DrawFirstHand();
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

            var gameStateCollection = _gameStateMapper.BuildGameStateCollection(_game);
            _gameStateService.SendGameStates(gameStateCollection).GetAwaiter().GetResult();
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

        public Turn CreateTurn(Player forPlayer)
        {
            var turn = new Turn();
            turn.Player = forPlayer;
            turn.Phases = new List<Phase>
            {
                CreateBeginningPhase(turn),
                CreatePreCombatMainPhase(turn),
                CreateCombatPhase(turn),
                CreatePostCombatMainPhase(turn),
                CreateEndingPhase(turn)
            };

            return turn;
        }

        public BeginningPhase CreateBeginningPhase(Turn turn)
        {
            var beginningPhase = new BeginningPhase();
            beginningPhase.Turn = turn;
            beginningPhase.Steps = new List<Step>
            {
                CreateUntapStep(beginningPhase),
                CreateUpkeepStep(beginningPhase),
                CreateDrawStep(beginningPhase)
            };

            return beginningPhase;
        }

        public UntapStep CreateUntapStep(Phase phase)
        {
            return new UntapStep()
            {
                Phase = phase
            };
        }

        public UpkeepStep CreateUpkeepStep(Phase phase)
        {
            return new UpkeepStep()
            {
                Phase = phase
            };
        }

        public DrawStep CreateDrawStep(Phase phase)
        {
            return new DrawStep()
            {
                Phase = phase
            };
        }

        public PreCombatMainPhase CreatePreCombatMainPhase(Turn turn)
        {
            return new PreCombatMainPhase()
            {
                Turn = turn
            };
        }

        public PostCombatMainPhase CreatePostCombatMainPhase(Turn turn)
        {
            return new PostCombatMainPhase()
            {
                Turn = turn
            };
        }

        public CombatPhase CreateCombatPhase(Turn turn)
        {
            var combatPhase = new CombatPhase();
            combatPhase.Turn = turn;
            combatPhase.Steps = new List<Step>
            {
                CreateBeginningCombatStep(combatPhase),
                CreateDeclareAttackerStep(combatPhase),
                CreateDeclareBlockerStep(combatPhase),
                CreateFirstStrikeCombatDamageStep(combatPhase),
                CreateRegularCombatDamageStep(combatPhase),
                CreateEndingCombatStep(combatPhase)
            };

            return combatPhase;
        }

        public BeginningCombatStep CreateBeginningCombatStep(Phase phase)
        {
            return new BeginningCombatStep
            {
                Phase = phase
            };
        }

        public DeclareAttackerStep CreateDeclareAttackerStep(Phase phase)
        {
            return new DeclareAttackerStep()
            {
                Phase = phase
            };
        }

        public DeclareBlockerStep CreateDeclareBlockerStep(Phase phase)
        {
            return new DeclareBlockerStep()
            {
                Phase = phase
            };
        }

        public FirstStrikeCombatDamageStep CreateFirstStrikeCombatDamageStep(Phase phase)
        {
            return new FirstStrikeCombatDamageStep()
            {
                Phase = phase
            };
        }

        public RegularCombatDamageStep CreateRegularCombatDamageStep(Phase phase)
        {
            return new RegularCombatDamageStep()
            {
                Phase = phase
            };
        }

        public EndingCombatStep CreateEndingCombatStep(Phase phase)
        {
            return new EndingCombatStep()
            {
                Phase = phase
            };
        }

        public EndingPhase CreateEndingPhase(Turn turn)
        {
            var endingPhase = new EndingPhase();
            endingPhase.Turn = turn;
            endingPhase.Steps = new List<Step>
            {
                CreateEndStep(endingPhase),
                CreateCleanupStep(endingPhase)
            };

            return endingPhase;
        }

        public EndStep CreateEndStep(Phase phase)
        {
            return new EndStep()
            {
                Phase = phase
            };
        }

        public CleanupStep CreateCleanupStep(Phase phase)
        {
            return new CleanupStep()
            {
                Phase = phase
            };
        }
    }
}
