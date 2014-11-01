using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace SteamB23.FairyEngine
{
    public interface IControllerConfig
    {
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
        Keys LB
        {
            get;
        }
    }
}
