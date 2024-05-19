using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Contract.Constants
{
    public static class Constants
    {
        public const string ReceiveGameStateMethod = "ReceiveGameState";
        public const string PlayerJoinGameMethod = "PlayerJoinGame";
        public const string GamePreparationUpdatedMethod = "GamePreparationUpdated";
        public const string MulliganOfferMethod = "MulliganOffer";
        public const string StartGameMethod = "StartGame";
        public const string GameStartedMethod = "GameStarted";
        public const string PlayabilityUpdateMethod = "PlayabilityUpdate";
        public const string PriorityUpdateMethod = "PriorityUpdate";
        public const string PassPriorityMethod = "PassPriority";
        public const string CardChangeZoneMethod = "CardChangeZone";
        public const string PlayerInputMethod = "PlayerInput";
    }
}
