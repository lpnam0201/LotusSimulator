using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.GUIComponents.Screens
{
    public abstract class Screen
    {
        protected bool IsRequestingServer;

        public virtual void Draw(GameTime gameTime)
        {

        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public abstract void Dispose();
    }
}
