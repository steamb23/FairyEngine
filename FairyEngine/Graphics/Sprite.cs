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
        }
        ContentManager content;
        string assetName;
        public virtual void LoadContent()
        {
            Texture = content.Load<Texture2D>(assetName);
        }
        public void SetSpriteBox(int spriteBoxesCount)
        {
            this.SpriteBox = SpriteBoxes[spriteBoxesCount];
        }
        public Rectangle[] SpriteBoxes
        {
            get;
            set;
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
    }
}
