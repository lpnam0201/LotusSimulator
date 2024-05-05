using LotusSimulator.Core.Entities.Card;
using LotusSimulator.Core.Entities.Players;
using LotusSimulator.Core.Entities.Spell;
using LotusSimulator.Core.Entities.Turn;
using LotusSimulator.Core.Services;
using LotusSimulator.Entities;
using Microsoft.AspNetCore.SignalR;

namespace LotusSimulator.Managers
{
    public class GameManager
    {
        private IHubContext<GameHub> _hubContext;
        private RandomService _randomService;
        private Game _game;

        public GameManager(IHubContext<GameHub> hubContext, RandomService randomService, Game game)
        {
            _hubContext = hubContext;
            _randomService = randomService;
            _game = game;
        }

        private void InitializeDeck()
        {
            foreach (var player in _game.Players)
            {

            }
        }

        public void Begin()
        {
            DecidePlayerGoFirst();

        }

        private void DecidePlayerGoFirst()
        {
            var playerCount = _game.Players.Count;
            var goFirstIndex = _randomService.RandomInt(playerCount);

            _game.PlayerGoFirst = _game.Players[goFirstIndex];
        }

        private void DrawFirstHand()
        {

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
