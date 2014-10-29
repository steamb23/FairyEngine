using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SteamB23.FairyEngine.Components
{
    public class ControllerManager : GameComponent
    {
        #region 입력 상태
        public bool Up
        {
            get;
            private set;
        }
        public bool Down
        {
            get;
            private set;
        }
        public bool Right
        {
            get;
            private set;
        }
        public bool Left
        {
            get;
            private set;
        }
        public bool A
        {
            get;
            private set;
        }
        public bool B
        {
            get;
            private set;
        }
        public bool Start
        {
            get;
            private set;
        }
        public bool LB
        {
            get;
            private set;
        }
        #endregion
        GamePadState gamePad;
        public IControllerConfig Config
        {
            get;
            set;
        }
        public ControllerManager(Game game, IControllerConfig config)
            : base(game)
        {
            this.Config = config;
            gamePad = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.None);
        }
        public override void Update(GameTime gameTime)
        {
            KeyClear();
        }

        private void KeyClear()
        {
            Up = false;
            Down = false;
            Right = false;
            Left = false;
            A = false;
            B = false;
            Start = false;
            LB = false;
        }

    }
}
