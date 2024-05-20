using LotusSimulator.Contract.Constants;
using LotusSimulator.Contract.MessageOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Models
{
    public class BattlefieldDisplayModel : IZone, IZoneModifier
    {
        public GameObjectZone Zone => GameObjectZone.Exile;

        public List<PageDisplayModel> ArtifactEnchantments { get; set; } = new List<PageDisplayModel>();
        public List<PageDisplayModel> CreaturePlaneswalkerBattle { get; set; } = new List<PageDisplayModel>();
        public List<PageDisplayModel> Lands { get; set; } = new List<PageDisplayModel>();

        public GameObjectDisplayModel GetGameObject(DisplayZone displayZone, int page, int index)
        {
            List<PageDisplayModel> pages = null;
            switch (displayZone)
            {
                case DisplayZone.ArtifactEnchantment:
                    pages = ArtifactEnchantments;
                    break;
                case DisplayZone.CreaturePlaneswalkerBattle:
                    pages = CreaturePlaneswalkerBattle;
                    break;
                case DisplayZone.Land:
                    pages = Lands;
                    break;
            }

            return pages.FirstOrDefault(x => x.Index == page)
                ?.Models.FirstOrDefault(x => x.Index == index);
        }

        public void AddToArtifactEnchantments(GameObjectDisplayModel gameObject)
        {
            AddInternal(gameObject, ArtifactEnchantments);
        }

        public void AddToLands(GameObjectDisplayModel gameObject)
        {
            AddInternal(gameObject, Lands);
        }

        public void AddToCreaturePlaneswalkerBattle(GameObjectDisplayModel gameObject)
        {
            AddInternal(gameObject, CreaturePlaneswalkerBattle);
        }

        private void AddInternal(GameObjectDisplayModel gameObject, List<PageDisplayModel> pages)
        {
            var page = FindPageNotFull(pages);
            if (page == null)
            {
                page = new PageDisplayModel();
            }

            page.Models.Add(gameObject);
            pages.Add(page);
        }

        private PageDisplayModel FindPageNotFull(List<PageDisplayModel> pages)
        {
            foreach (var page in pages)
            {
                if (page.Models.Count < PageDisplayModel.Capacity)
                {
                    return page;
                }
            }

            return null;
        }

        public void Add(GameObjectDisplayModel gameObjectDisplayModel)
        {
            if (gameObjectDisplayModel.Types.Any(x => x == Contract.Constants.ObjectType.Land))
            {
                AddToLands(gameObjectDisplayModel);
            }

            if (gameObjectDisplayModel.Types.Any(x =>
                x == Contract.Constants.ObjectType.Creature
                || x == Contract.Constants.ObjectType.Planeswalker
                || x == Contract.Constants.ObjectType.Battle))
            {
                AddToCreaturePlaneswalkerBattle(gameObjectDisplayModel);
            }

            if (gameObjectDisplayModel.Types.Any(x =>
                x == Contract.Constants.ObjectType.Artifact
                || x == Contract.Constants.ObjectType.Enchantment))
            {
                AddToArtifactEnchantments(gameObjectDisplayModel);
            }
        }

        public void Remove(string id)
        {
            throw new NotImplementedException();
        }
    }
}
