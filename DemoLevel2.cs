using LateNightGameEngine.Source;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateNightGameEngine
{
    internal class DemoLevel2 : Level
    {
        Player player;

        public override string Name { get; set; }
        public override bool Init { get; set; }

        public DemoLevel2(string name) : base(name)
        {
        }

        public override void OnLoad()
        {
            Shape2D box = new Shape2D(Shape2D.Shapes.Rectangle, new Vector2(300),new Vector2(50),"box", Color.Transparent, Color.Red);
            Shape2D box2 = new Shape2D(Shape2D.Shapes.Circle, new Vector2(300), new Vector2(25), "circle", Color.Transparent, Color.Blue);
            player = new Player(new Vector2(400, 400), Vector2.Zero(), "Player");
            player.CollisionDebug(true);
        }

        public override void OnUpdate()
        {
        }
    }
}
