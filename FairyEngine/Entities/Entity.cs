using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SteamB23.FairyEngine.Entities
{
    public class Entity : GameComponent
    {
        Entity(Game game)
            : base(game)
        {
        }
        public sealed override void Update(GameTime gameTime)
        {
            if (isDestory)
                DestroyUpdate(gameTime);
            else
                NormalUpdate(gameTime);
            base.Update(gameTime);
        }
        public virtual void NormalUpdate(GameTime gameTime)
        {
        }
        #region 파괴 관련 메서드
        /// <summary>
        /// Destroy 판정후 필요한 업데이트를 합니다.
        /// </summary>
        /// <remarks>
        /// 오버라이드시 <c>base.DestroyUpdate</c>는 맨 마지막에 호출되어야 합니다.
        /// </remarks>
        /// <param name="gameTime"></param>
        public virtual void DestroyUpdate(GameTime gameTime)
        {
            OnDestroyed();
        }
        /// <summary>
        /// 엔터티 파괴 절차를 실행하도록 설정합니다.
        /// </summary>
        public void Destroy()
        {
            isDestory = true;
        }
        
        public event EventHandler Destroyed;
        protected void OnDestroyed()
        {
            if (Destroyed != null)
                Destroyed(this, EventArgs.Empty);
        }
        bool isDestory;
        public bool IsDestroy
        {
            get
            {
                return isDestory;
            }
        }
        #endregion
    }
}
