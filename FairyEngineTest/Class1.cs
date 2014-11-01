using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace FairyEngineTest
{
    class Class1 : GameComponent
    {
        public Class1(Game game) : base(game)
        {

        }
        public override void Update(GameTime gameTime)
        {
            Console.Clear();
            if (((Game1)Game).controller.Up)
                Console.WriteLine("up");
            if (((Game1)Game).controller.Down)
                Console.WriteLine("down");
            if (((Game1)Game).controller.Right)
                Console.WriteLine("right");
            if (((Game1)Game).controller.Left)
                Console.WriteLine("left");
            if (((Game1)Game).controller.A)
                Console.WriteLine("a");
            if (((Game1)Game).controller.B)
                Console.WriteLine("b");
            base.Update(gameTime);
        }
    }
}
