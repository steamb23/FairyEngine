using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SteamB23.FairyEngine.Components;
using SteamB23.FairyEngine.Graphics;

namespace SteamB23.FairyEngine.UIComponents
{
    public class ScoreView : UIComponent
    {
        /*
         * #스프라이트 구조
         * 1-2-3-4-5-6-7-8-9-0-OverFlow*
         * (*표시는 생략 가능)
         */
        int spacing;

        IScoreService score;
        public ScoreView(Game game, string name, Sprite sprite, int spacing)
            : base(game, name)
        {
            if (sprite.SpriteBoxes.Length > 10)
                throw new ArgumentException("매개변수의 SpriteBoxes.Length는 10이상이어야합니다.");
            this.Sprite = sprite;
            this.spacing = spacing;
            this.score = (IScoreService)game.Services.GetService(typeof(IScoreService));
            if (score == null)
            {
                MessageBox.GetServiceError(this, typeof(IScoreService), "", game);
                Game.Exit();
            }
        }
        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = ((GameResource)Game.Services.GetService(typeof(GameResource))).spriteBatch;
            Vector2 location = Location;
            for (int i = score.Length; i > 0; --i)
            {
                Sprite.SetSpriteBox(score[i]);
                spriteBatch.Draw(
                    Sprite.Texture,
                    location,
                    Sprite.SpriteBox,
                    Color.White,
                    0f,
                    new Vector2(0, Sprite.SpriteBox.Height),
                    1f,
                    SpriteEffects.None,
                    0f);
                location.X += Sprite.SpriteBox.Width + spacing;
            }

        }
    }
}
