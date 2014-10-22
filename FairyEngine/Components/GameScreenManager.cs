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
        Rectangle gameScreen;
        SpriteBatch spriteBatch;
        // addictive가 가장 위에 렌더링되며 alpha1, alpha2순임.
        List<Sprite> addictive = new List<Sprite>();
        List<Sprite> alpha1 = new List<Sprite>();
        List<Sprite> alpha2 = new List<Sprite>();
        public GameScreenManager(Game game, Rectangle gameScreen)
            : base(game)
        {
            this.gameScreen = gameScreen;
            if (gameScreen.Width == 0)
                gameScreen.Width = game.GraphicsDevice.Viewport.Width;
            if (gameScreen.Height == 0)
                gameScreen.Height = game.GraphicsDevice.Viewport.Height;
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
                renderTarget = new RenderTarget2D(Game.GraphicsDevice, gameScreen.Width, gameScreen.Height);
        }
        public override void Draw(GameTime gameTime)
        {
            var renderTargetTemp = Game.GraphicsDevice.GetRenderTargets();
            Game.GraphicsDevice.SetRenderTarget(this.renderTarget);
            // Alpha2 그리기
            if (alpha2.Count != 0)
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
                foreach (var temp in alpha2)
                {
                    if (temp.Texture.Bounds.Intersects(this.gameScreen))
                    {
                        spriteBatch.Draw(
                            temp.Texture,
                            temp.Location,
                            temp.SpriteBox,
                            temp.Color,
                            temp.Rotation,
                            new Vector2(temp.SpriteBox.Width, temp.SpriteBox.Height),
                            temp.Scale,
                            temp.SpriteEffect,
                            0f);
                    }
                }
                spriteBatch.End();
            }
            // Alpha1 그리기
            if (alpha1.Count != 0)
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
                foreach (var temp in alpha1)
                {
                    if (temp.Texture.Bounds.Intersects(this.gameScreen))
                    {
                        spriteBatch.Draw(
                            temp.Texture,
                            temp.Location,
                            temp.SpriteBox,
                            temp.Color,
                            temp.Rotation,
                            new Vector2(temp.SpriteBox.Width, temp.SpriteBox.Height),
                            temp.Scale,
                            temp.SpriteEffect,
                            0f);
                    }
                }
                spriteBatch.End();
            }
            // Addictive 그리기
            if (addictive.Count != 0)
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);
                foreach (var temp in addictive)
                {
                    if (temp.Texture.Bounds.Intersects(this.gameScreen))
                    {
                        spriteBatch.Draw(
                            temp.Texture,
                            temp.Location,
                            temp.SpriteBox,
                            temp.Color,
                            temp.Rotation,
                            new Vector2(temp.SpriteBox.Width, temp.SpriteBox.Height),
                            temp.Scale,
                            temp.SpriteEffect,
                            0f);
                    }
                }
                spriteBatch.End();
            }
            
            // 텍스쳐로 내보내서 렌더타겟 복구후 텍스쳐를 표시
            base.Draw(gameTime);
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
            throw new NotImplementedException();
        }

        public void CopyTo(Sprite[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Remove(Sprite item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Sprite> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
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
