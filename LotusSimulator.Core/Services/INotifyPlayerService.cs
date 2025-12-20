using LotusSimulator.Contract.MessageOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public interface INotifyPlayerService
    {
        Task NotifyGameStarted(GameStateCollectionDto gameStateCollection);
        Task NotifyCardChangeZone(GameChangeZoneCollectionDto cardChangeZone);
        Task NotifyPlayabilityUpdate(PlayabilityCollectionDto playabilityCollection);
        Task NotifyPriorityUpdate(PriorityUpdateDto priorityUpdate);
    }
}
