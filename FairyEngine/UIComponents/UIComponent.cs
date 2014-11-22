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
        Sprite _sprite;
        string _name;
        protected UIComponent()
        {
            Enable = true;
            Visible = true;
        }
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
        public virtual Sprite Sprite
        {
            get
            {
                return _sprite;
            }
            set
            {
                _sprite = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
        }
        public virtual bool Enable
        {
            get;
            set;
        }
        public virtual bool Visible
        {
            get;
            set;
        }
        public UIComponent(Game game, string name)
        {
            this.Game = game;
            this._name = name;
        }

        public virtual void Update(GameTime gameTime)
        {
        }
        public virtual void Draw(GameTime gameTime)
        {
        }
    }
}
