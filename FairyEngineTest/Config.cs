using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SteamB23.FairyEngine;
using Microsoft.Xna.Framework.Input;

namespace FairyEngineTest
{
    class Config : IControllerConfig
    {
        #region IControllerConfig 멤버
        public Keys Up
        {
            get
            {
                return Keys.Up;
            }
        }

        public Keys Down
        {
            get
            {
                return Keys.Down;
            }
        }

        public Keys Right
        {
            get
            {
                return Keys.Right;
            }
        }

        public Keys Left
        {
            get
            {
                return Keys.Left;
            }
        }

        public Keys A
        {
            get
            {
                return Keys.Z;
            }
        }

        public Keys B
        {
            get
            {
                return Keys.X;
            }
        }

        public Keys Start
        {
            get
            {
                return Keys.Escape;
            }
        }

        public Keys LB
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        #endregion
    }
}
