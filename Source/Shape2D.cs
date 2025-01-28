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
            Rectangle, Circle
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
            Children = new List<GameObject>();

            Log.Info($"Registered a new {Shape}, called {Tag}");
        }

        public Shape2D(Shapes shape, Vector2 position, Vector2 scale, string tag)
        {
            Shape = shape;
            Position = position;
            Origin = position;
            Scale = scale;
            Tag = tag;
            Children = new List<GameObject>();

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
                    RectangleShape graphics = new RectangleShape(Scale);
                    graphics.Position = Position;
                    graphics.FillColor = Color;
                    graphics.Origin = Scale * new Vector2(0.5f, 0.5f);
                    graphics.OutlineColor = OutlineColor;
                    graphics.OutlineThickness = OutlineThickness;
                    Engine.App.Draw(graphics);
                    break;
                case Shapes.Circle:
                    CircleShape circle = new CircleShape(Scale.X);
                    circle.Position = Position;
                    circle.FillColor = Color;
                    circle.Origin = Scale * new Vector2(0.5f, 0.5f);
                    circle.OutlineColor = OutlineColor;
                    circle.OutlineThickness = OutlineThickness;
                    Engine.App.Draw(circle);


                    break;
            }

        }
    }
}
