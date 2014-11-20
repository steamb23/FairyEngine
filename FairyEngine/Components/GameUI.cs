using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SteamB23.FairyEngine.Graphics;

namespace SteamB23.FairyEngine.Components
{
    public class GameUI : DrawableGameComponent, IGameUIService
    {        
        public GameUI(Game game)
            : base(game)
        {
        }
    }
}
