using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateNightGameEngine.Source
{
    public class Shape2D : GameObject
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }

        public enum Shapes
        {
            Rectangle, Circle, Capsule
        }

        public Shapes Shape;

        public Color Color = Color.White;
        public Color OutlineColor = Color.White;
        public float OutlineThickness = 1.0f;

        public Shape2D(Shapes shape, Vector2 position, Vector2 scale, string tag, Color color, Color outlineColor)
        {
            Shape = shape;
            Position = position;
            Origin = position;
            Scale = scale;
            Tag = tag;
            Color = color;
            OutlineColor = outlineColor;
            Children = [];

            Log.Info($"Registered a new {Shape}, called {Tag}");
        }

        public Shape2D(Shapes shape, Vector2 position, Vector2 scale, string tag)
        {
            Shape = shape;
            Position = position;
            Origin = position;
            Scale = scale;
            Tag = tag;
            Children = [];

            Log.Info($"Registered a new {Shape}, called {Tag}");
        }


        public override void OnDestroy()
        {
            
        }

        public override void OnLoad()
        {
            
        }

        public override void OnUpdate()
        {
            switch (Shape)
            {
                case Shapes.Rectangle:
                    RectangleShape graphics = new(Scale)
                    {
                        Position = Position,
                        FillColor = Color,
                        Origin = Scale * new Vector2(0.5f, 0.5f),
                        OutlineColor = OutlineColor,
                        OutlineThickness = OutlineThickness
                    };
                    Engine.App.Draw(graphics);
                    break;
                case Shapes.Circle:
                    CircleShape circle = new(Scale.X)
                    {
                        Position = Position,
                        FillColor = Color,
                        Origin = Scale * new Vector2(0.5f, 0.5f),
                        OutlineColor = OutlineColor,
                        OutlineThickness = OutlineThickness
                    };
                    Engine.App.Draw(circle);
                    break;
                case Shapes.Capsule:
                    //2 circles and a rectangle in the center.
                    CircleShape top = new(Scale.X / 2);
                    CircleShape bottom = new(Scale.X / 2);
                    RectangleShape center = new(new Vector2(Scale.X, Scale.Y / 2))
                    {
                        Position = Position,
                        FillColor = Color,
                        Origin = Scale * new Vector2(0.5f)
                    };


                    break;
            }

        }
    }
}
