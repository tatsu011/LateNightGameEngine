using LateNightGameEngine.Source;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateNightGameEngine
{
    internal class Player : GameObject
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }

        public Player(Vector2 position, Vector2 scale, string tag) 
        { 
            Position = position;
            Origin = position;
            Scale = scale;
            Tag = tag;
        }


        public override void OnDestroy()
        {
            
        }

        public override void OnLoad()
        {
            Shape2D shape = new Shape2D(Shape2D.Shapes.Rectangle, Vector2.Zero(), Vector2.Zero(), "PlayerShape", Color.Black, Color.White);
            AddChild(shape);
        }

        public override void OnUpdate()
        {
            if(Input.ActionKeyHeld("Up"))
            {
                Position.Y += 1;
            }
            if (Input.ActionKeyHeld("Down"))
            {
                Position.Y -= 1;
            }
            if (Input.ActionKeyHeld("Right"))
            {
                Position.X += 1;
            }
            if (Input.ActionKeyHeld("Left"))
            {
                Position.X -= 1;
            }
        }
    }
}
