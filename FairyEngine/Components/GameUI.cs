using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SteamB23.FairyEngine.Graphics;
using SteamB23.FairyEngine.UIComponents;

namespace SteamB23.FairyEngine.Components
{
    public class GameUI : DrawableGameComponent, IGameUIService
    {
        Dictionary<string, UIComponent> List
        {
            get
            {
                return uiComponentList;
            }
        }
        Dictionary<string, UIComponent> uiComponentList;
        public GameUI(Game game)
            : base(game)
        {
            uiComponentList = new Dictionary<string, UIComponent>();
        }
        public override void Update(GameTime gameTime)
        {
            System.Threading.Tasks.Parallel.ForEach(uiComponentList, (ftemp) =>
            {
                ftemp.Value.Update(gameTime);
            });
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = ((GameResource)Game.Services.GetService(typeof(GameResource))).spriteBatch;
            spriteBatch.Begin();
            foreach (var ftemp in uiComponentList)
            {
                ftemp.Value.Draw(gameTime);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
