using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SteamB23.FairyEngine.Graphics
{
    public class GameSprite : Sprite
    {
        public GameSprite(ContentManager content, string assetName):base(content,assetName)
        {
            // 기본값 초기화
            this.Location = new Vector2(0, 0);
            this.Rotation = 0f;
            this.Scale = 0f;
            this.SpriteEffect = SpriteEffects.None;
            this.Color = Color.White;
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
