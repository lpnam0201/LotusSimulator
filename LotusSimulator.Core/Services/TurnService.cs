using LotusSimulator.Core.Entities.Players;
using LotusSimulator.Core.Entities.Turn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public class TurnService
    {
        private readonly PhaseRunnerFactory _phaseRunnerFactory;

        public TurnService(PhaseRunnerFactory phaseRunnerFactory)
        {
            _phaseRunnerFactory = phaseRunnerFactory;
        }

        public async Task RunTurn(Turn turn)
        {
            foreach (var phase in turn.Phases)
            {
                turn.CurrentPhase = phase;
                var phaseRunner = _phaseRunnerFactory.CreatePhaseRunner(phase.GetType());
                await phaseRunner.Run(phase);
            }
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
