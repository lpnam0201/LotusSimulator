using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Services
{
    public class LookupCardImageService
    {
        public Texture2D LookupCardImage(string oracleId)
        {
            return GlobalInstances.ContentManager.Load<Texture2D>($@"Cards\{oracleId}");
        }
    }
}
