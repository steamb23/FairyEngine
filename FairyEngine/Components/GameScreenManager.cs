using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SteamB23.FairyEngine.Graphics;

namespace SteamB23.FairyEngine.Components
{
    /// <summary>
    /// 스프라이트를 관리하며 백버퍼에 그립니다.
    /// </summary>
    public class GameScreenManager : DrawableGameComponent, ICollection<Sprite>
    {
        RenderTarget2D renderTarget;
        // 실질적인 게임 스크린 위치 및 크기
        Rectangle realGameScreen;
        // 가상 게임 스크린 크기
        Rectangle gameScreen;
        SpriteBatch spriteBatch;
        // addictive가 가장 위에 렌더링되며 alpha1, alpha2순임.
        List<Sprite> addictive = new List<Sprite>();
        List<Sprite> alpha1 = new List<Sprite>();
        List<Sprite> alpha2 = new List<Sprite>();
        public GameScreenManager(Game game, Rectangle gameScreen)
            : base(game)
        {
            this.realGameScreen = gameScreen;
            if (realGameScreen.Width == 0)
                realGameScreen.Width = game.GraphicsDevice.Viewport.Width;
            if (realGameScreen.Height == 0)
                realGameScreen.Height = game.GraphicsDevice.Viewport.Height;

            gameScreen = realGameScreen;
            gameScreen.X = 0;
            gameScreen.Y = 0;

            spriteBatch = new SpriteBatch(game.GraphicsDevice);
        }
        public void Add(Sprite item, LayerType layer)
        {
            switch (layer)
            {
                case LayerType.Addictive:
                    addictive.Add(item);
                    break;
                case LayerType.Alpha1:
                    alpha1.Add(item);
                    break;
                case LayerType.Alpha2:
                    alpha2.Add(item);
                    break;
            }
        }
        protected override void LoadContent()
        {
            if (renderTarget == null || renderTarget.IsContentLost)
                renderTarget = new RenderTarget2D(Game.GraphicsDevice, realGameScreen.Width, realGameScreen.Height);
        }
        public override void Draw(GameTime gameTime)
        {
            var renderTargetTemp = Game.GraphicsDevice.GetRenderTargets();
            Game.GraphicsDevice.SetRenderTarget(this.renderTarget);
            // Alpha1,2 그리기
            if (alpha1.Count != 0 || alpha2.Count != 0)
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
                foreach (var temp in alpha2)
                {
                    Draw(temp);
                }
                foreach (var temp in alpha1)
                {
                    Draw(temp);
                }
                spriteBatch.End();
            }
            // Addictive 그리기
            if (addictive.Count != 0)
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);
                foreach (var temp in addictive)
                {
                    Draw(temp);
                }
                spriteBatch.End();
            }
            base.Draw(gameTime);
        }
        void Draw(Sprite sprite)
        {
            bool isDraw =
                new Rectangle(sprite.Texture.Bounds.X + (int)sprite.Location.X,
                sprite.Texture.Bounds.Y + (int)sprite.Location.Y,
                sprite.SpriteBox.Width,
                sprite.SpriteBox.Height).Intersects(this.gameScreen);

            if (isDraw)
            {
                spriteBatch.Draw(
                    sprite.Texture,
                    sprite.Location + new Vector2(realGameScreen.X, realGameScreen.Y),
                    sprite.SpriteBox,
                    sprite.Color,
                    sprite.Rotation,
                    new Vector2(sprite.SpriteBox.Width, sprite.SpriteBox.Height),
                    sprite.Scale,
                    sprite.SpriteEffect,
                    0f);
            }
        }
        #region ICollection 구현
        public void Add(Sprite item)
        {
            this.Add(item, LayerType.Alpha1);
        }

        public void Clear()
        {
            addictive.Clear();
            alpha1.Clear();
            alpha2.Clear();
        }

        public bool Contains(Sprite item)
        {
            return addictive.Contains(item) || alpha1.Contains(item) || alpha2.Contains(item);
        }

        public void CopyTo(Sprite[] array, int arrayIndex)
        {
            ListMerge().CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get
            {
                return addictive.Count + alpha1.Count + alpha2.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool Remove(Sprite item)
        {
            return addictive.Remove(item) || alpha1.Remove(item) || alpha2.Remove(item);
        }

        public IEnumerator<Sprite> GetEnumerator()
        {
            return ListMerge().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ListMerge().GetEnumerator();
        }
        List<Sprite> ListMerge()
        {
            var result = new List<Sprite>();
            result.AddRange(addictive);
            result.AddRange(alpha1);
            result.AddRange(alpha2);
            return result;
        }
        #endregion
    }
    public enum LayerType
    {
        /// <summary>
        /// 알파 1번 레이어
        /// </summary>
        Alpha1,
        /// <summary>
        /// 알파 2번 레이어
        /// </summary>
        Alpha2,
        /// <summary>
        /// 가산 레이어
        /// </summary>
        Addictive
    }
}
