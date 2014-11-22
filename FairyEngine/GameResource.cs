using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SteamB23.FairyEngine.Components;

namespace SteamB23.FairyEngine
{
    /// <summary>
    /// 공통적인 부분을 제공합니다.
    /// </summary>
    public class GameResource
    {
        Game game;
        void Exiting(object sender, EventArgs e)
        {
            this.game.Exiting -= this.Exiting;
            this.game = null;
        }
        public Score Score
        {
            get;
            private set;
        }
        public byte PowerLevel
        {
            get;
            set;
        }
        public byte BombCount
        {
            get;
            set;
        }
        public SpriteBatch spriteBatch
        {
            get;
            private set;
        }
        public GameResource(Game game, Rectangle gameScreen, int scoreRate)
            :this(game,new EntityManager(game),new GameScreenManager(game,gameScreen),new GameUI(game), new Score(game, scoreRate))
        {
        }
        public GameResource(Game game, EntityManager entityManager, GameScreenManager gameScreenManager, GameUI gameUI, Score score)
        {
            this.game = game;
            game.Services.AddService(this.GetType(), this);
            game.Exiting += this.Exiting;

            spriteBatch = new SpriteBatch(game.GraphicsDevice);

            entityManager.UpdateOrder = 0x1100;
            gameScreenManager.UpdateOrder = 0x1200;
            score.UpdateOrder = 0x1300;
            gameUI.UpdateOrder = 0x1400;

            gameScreenManager.DrawOrder = 0x1100;
            gameUI.DrawOrder = 0x1200;

            game.Components.Add(entityManager);
            game.Components.Add(gameScreenManager);
            game.Components.Add(gameUI);

            game.Services.AddService(typeof(IEntityService), entityManager);
            game.Services.AddService(typeof(IGameScreenService), gameScreenManager);
            game.Services.AddService(typeof(IGameUIService), gameUI);
            game.Services.AddService(typeof(IScoreService), score);
        }
    }
}
