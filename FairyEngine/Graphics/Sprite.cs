using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SteamB23.FairyEngine.Graphics
{
    public class Sprite
    {
        public Sprite(ContentManager content, string assetName)
        {
            this.content = content;
            this.assetName = assetName;
            this.LoadContent();
            this.Color = Color.White;
        }
        // 복구용
        ContentManager content;
        string assetName;
        public virtual void LoadContent()
        {
            Texture = content.Load<Texture2D>(assetName);
        }

        public Texture2D Texture
        {
            get;
            set;
        }
        public Rectangle SpriteBox
        {
            get;
            set;
        }
        public Vector2 Location
        {
            get;
            set;
        }
        public float Rotation
        {
            get;
            set;
        }
        public float Scale
        {
            get;
            set;
        }
        public SpriteEffects SpriteEffect
        {
            get;
            set;
        }
        public Color Color
        {
            get;
            set;
        }
    }
}
