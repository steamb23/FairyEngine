using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace SteamB23.FairyEngine
{
    interface IControllerConfig
    {
        float XAxisDeadZone
        {
            get;
        }
        float YAxisDeadZone
        {
            get;
        }
        Keys Up
        {
            get;
        }
        Keys Down
        {
            get;
        }
        Keys Right
        {
            get;
        }
        Keys Left
        {
            get;
        }
        Keys A
        {
            get;
        }
        Keys B
        {
            get;
        }
        Keys Start
        {
            get;
        }
    }
}
