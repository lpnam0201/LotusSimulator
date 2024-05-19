using LotusSimulator.Contract.MessageOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Models
{
    public class GameDisplayModel
    {
        public string PriorityHolder { get; set; }

        public List<PlayerDisplayModel> Players { get; set; } = new List<PlayerDisplayModel>();

        public LibraryDisplayModel GetLibrary(string id)
        {
            return GetPlayer(id).Library;
        }

        public GraveyardDisplayModel GetGraveyard(string id)
        {
            return GetPlayer(id).Graveyard;
        }

        public ExileDisplayModel GetExile(string id)
        {
            return GetPlayer(id).Exile;
        }

        public HandDisplayModel GetHand(string id)
        {
            return GetPlayer(id).Hand;
        }

        public PlayerDisplayModel GetPlayer(string id)
        {
            return Players.First(x => x.Id == id);
        }

        public GameObjectDisplayModel GetGameObject(string id)
        {
            var gameObject = Players.SelectMany(x => x.Library.GameObjects)
                .Concat(Players.SelectMany(x => x.Hand.GameObjects))
                .Concat(Players.SelectMany(x => x.Graveyard.GameObjects))
                .Concat(Players.SelectMany(x => x.Exile.GameObjects))
                .Concat(Players.SelectMany(x => x.Battlefield.ArtifactEnchantments.SelectMany(y => y.Models)))
                .Concat(Players.SelectMany(x => x.Battlefield.Lands.SelectMany(y => y.Models)))
                .Concat(Players.SelectMany(x => x.Battlefield.CreaturePlaneswalkerBattle.SelectMany(y => y.Models)));

            return gameObject.FirstOrDefault(x => x.Id == id);
        }
    }
}
