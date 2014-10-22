using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SteamB23.FairyEngine.Components;

namespace SteamB23.FairyEngine
{
    public static class EngineManager
    {
        public static SpriteBatch spriteBatch;
        public static EntityManager EntityManager
        {
            get;
            private set;
        }
        public static GameScreenManager GameScreenManager
        {
            get;
            private set;
        }
        public static void Initialize(Game game, Rectangle gameScreen)
        {
            spriteBatch = new SpriteBatch(game.GraphicsDevice);

            EntityManager = new EntityManager(game);
            GameScreenManager = new GameScreenManager(game, gameScreen);

            EntityManager.UpdateOrder = 1;
            GameScreenManager.UpdateOrder = 2;

            GameScreenManager.DrawOrder = 1;

            game.Components.Add(EntityManager);
            game.Components.Add(GameScreenManager);
        }
    }
}
