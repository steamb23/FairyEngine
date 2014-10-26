using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SteamB23.FairyEngine.Graphics;

namespace SteamB23.FairyEngine.UIComponents
{
    public abstract class UIComponent
    {
        public Game Game
        {
            get;
            private set;
        }
        public Vector2 Location
        {
            get;
            set;
        }
        public Sprite Sprite
        {
            get;
            set;
        }
        string name;
        public string Name
        {
            get
            {
                return name;
            }
        }
        public UIComponent(Game game, string name)
        {
            this.Game = game;
            this.name = name;
        }

        public virtual void Update(GameTime gameTime)
        {
        }
        public virtual void Draw(GameTime gameTime)
        {
        }
    }
}
