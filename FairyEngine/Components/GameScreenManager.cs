﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SteamB23.FairyEngine.Graphics;

namespace SteamB23.FairyEngine.Components
{
    /// <summary>
    /// 스프라이트를 관리하며 그립니다.
    /// </summary>
    public class GameScreenManager : DrawableGameComponent, ICollection<GameSprite>
    {
        RenderTarget2D renderTarget;
        // 실질적인 게임 스크린 위치 및 크기
        Rectangle realGameScreen;
        // 가상 게임 스크린 크기
        Rectangle gameScreen;
        SpriteBatch spriteBatch;
        // addictive가 가장 위에 렌더링되며 alpha3, alpha2, alpha1순임.
        List<GameSprite> addictive = new List<GameSprite>();
        List<GameSprite> alpha1 = new List<GameSprite>();
        List<GameSprite> alpha2 = new List<GameSprite>();
        List<GameSprite> alpha3 = new List<GameSprite>();
        public GameScreenManager(Game game, Rectangle gameScreen)
            : base(game)
        {
            this.realGameScreen = gameScreen;
            if (realGameScreen.Width == 0)
                realGameScreen.Width = game.GraphicsDevice.Viewport.Width;
            if (realGameScreen.Height == 0)
                realGameScreen.Height = game.GraphicsDevice.Viewport.Height;

            this.gameScreen = realGameScreen;
            this.gameScreen.X = 0;
            this.gameScreen.Y = 0;

            spriteBatch = new SpriteBatch(game.GraphicsDevice);
        }
        public void Add(GameSprite item, LayerType layer)
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
                case LayerType.Alpha3:
                    alpha3.Add(item);
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
            if (alpha1.Count != 0 || alpha2.Count != 0 || alpha3.Count != 0)
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
                foreach (var temp in alpha1)
                {
                    Draw(temp);
                }
                foreach (var temp in alpha2)
                {
                    Draw(temp);
                }
                foreach (var temp in alpha3)
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
        void Draw(GameSprite sprite)
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
        public void Add(GameSprite item)
        {
            this.Add(item, LayerType.Alpha1);
        }

        public void Clear()
        {
            addictive.Clear();
            alpha1.Clear();
            alpha2.Clear();
            alpha3.Clear();
        }

        public bool Contains(GameSprite item)
        {
            return addictive.Contains(item) || alpha1.Contains(item) || alpha2.Contains(item) || alpha3.Contains(item);
        }

        public void CopyTo(GameSprite[] array, int arrayIndex)
        {
            ListMerge().CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get
            {
                return addictive.Count + alpha1.Count + alpha2.Count + alpha3.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool Remove(GameSprite item)
        {
            return addictive.Remove(item) || alpha1.Remove(item) || alpha2.Remove(item) || alpha3.Remove(item);
        }

        public IEnumerator<GameSprite> GetEnumerator()
        {
            return ListMerge().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ListMerge().GetEnumerator();
        }
        List<GameSprite> ListMerge()
        {
            var result = new List<GameSprite>();
            result.AddRange(addictive);
            result.AddRange(alpha1);
            result.AddRange(alpha2);
            result.AddRange(alpha3);
            return result;
        }
        #endregion
    }
    public enum LayerType
    {
        /// <summary>
        /// 가산 레이어
        /// </summary>
        Addictive,
        /// <summary>
        /// 알파 1번 레이어
        /// </summary>
        Alpha1,
        /// <summary>
        /// 알파 2번 레이어
        /// </summary>
        Alpha2,
        /// <summary>
        /// 알파 3번 레이어
        /// </summary>
        Alpha3,
    }

}
