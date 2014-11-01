using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SteamB23.FairyEngine.Components
{
    public class Controller : GameComponent
    {
        bool up;
        bool down;
        bool right;
        bool left;
        #region 입력 상태
        public bool Up
        {
            get
            {
                return up || GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular).DPad.Up == ButtonState.Pressed || keyboard.IsKeyDown(Config.Up);
            }
        }
        public bool Down
        {
            get
            {
                return down || GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular).DPad.Down == ButtonState.Pressed || keyboard.IsKeyDown(Config.Down);
            }
        }
        public bool Right
        {
            get
            {
                return right || GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular).DPad.Right == ButtonState.Pressed || keyboard.IsKeyDown(Config.Right);
            }
        }
        public bool Left
        {
            get
            {
                return left || GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular).DPad.Left == ButtonState.Pressed || keyboard.IsKeyDown(Config.Left);
            }
        }
        public bool A
        {
            get
            {
                return GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular).Buttons.A == ButtonState.Pressed || keyboard.IsKeyDown(Config.A);
            }
        }
        public bool B
        {
            get
            {
                return GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular).Buttons.B == ButtonState.Pressed || keyboard.IsKeyDown(Config.B);
            }
        }
        public bool Start
        {
            get
            {
                return GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular).Buttons.Start == ButtonState.Pressed || keyboard.IsKeyDown(Config.Start);
            }
        }
        public bool LB
        {
            get
            {
                return GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular).Buttons.LeftShoulder == ButtonState.Pressed;
            }
        }
        #endregion
        GamePadState gamePad;
        KeyboardState keyboard;
        public IControllerConfig Config
        {
            get;
            set;
        }
        public Controller(Game game, IControllerConfig config)
            : base(game)
        {
            this.Config = config;
            gamePad = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular);
            keyboard = Keyboard.GetState();
        }
        // 
        public override void Update(GameTime gameTime)
        {
            gamePad = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular);
            keyboard = Keyboard.GetState();
            if (gamePad.ThumbSticks.Left.X != 0 || gamePad.ThumbSticks.Left.Y != 0)
            {
                // 라디안 각도 알아내기
                float radian = (float)Math.Atan2(gamePad.ThumbSticks.Left.Y, gamePad.ThumbSticks.Left.X);
                // 디그리 각도로 변환
                float degree = radian * 180.0f / (float)Math.PI;
                // 디그리가 0보다 작으면 360을 더한다.
                if (degree < 0)
                    degree += 360;
                //Angle열거형으로 변환
                switch ((Way)((degree + 22.5f) / 45))
                {
                    case Way.Right:
                        right = true;//
                        up = false;
                        down = false;
                        left = false;
                        break;
                    case Way.UpRight:
                        up = true;//
                        down = false;
                        right = true;//
                        left = false;
                        break;
                    case Way.Up:
                        up = true;//
                        down = false;
                        right = false;
                        left = false;
                        break;
                    case Way.UpLeft:
                        up = true;//
                        down = false;
                        right = false;
                        left = true;//
                        break;
                    case Way.Left:
                        up = false;
                        down = false;
                        right = false;
                        left = true;//
                        break;
                    case Way.DownLeft:
                        up = false;
                        down = true;//
                        right = false;
                        left = true;//
                        break;
                    case Way.Down:
                        up = false;
                        down = true;//
                        right = false;
                        left = false;
                        break;
                    case Way.DownRight:
                        up = false;
                        down = true;//
                        right = true;;//
                        left = false;
                        break;
                }
            }
            else
            {
                up = false;
                down = false;//
                right = false;
                left = false;
            }
            base.Update(gameTime);
        }
        enum Way
        {
            Right=0,
            UpRight=1,
            Up=2,
            UpLeft=3,
            Left=4,
            DownLeft=5,
            Down=6,
            DownRight=7
        }
    }
}
