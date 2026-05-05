using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LateNightGameEngine.Source
{
    internal class Label : GameObject
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }

        const string DefaultFontPath = "Assets/Default Font.ttf";
        public string Text = "";
        public string FontPath = "";
        public Font Font = null;
        public uint FontSize = 1;
        public bool Centered;
        public Color Color = Color.White;

        public Label(string text, string fontPath, uint fontSize, Vector2 position, Color color, string tag, bool centered ) 
        {
            Text = text;
            Position = position;
            Color = color;
            Tag = tag;
            Centered = centered;
            FontSize = fontSize;
            FontPath = fontPath;

            if (File.Exists(fontPath))
            {
                Font = new Font(fontPath);
            }
            else
            {
                Font = new Font(DefaultFontPath);
                Log.Error($"[Label]Could not find font from {fontPath}");
            }

        }

        public Label(string text, uint fontSize, Vector2 position, Color color, string tag, bool centered)
        {
            Text = text;
            Position = position;
            Color = color;
            Tag = tag;
            Centered = centered;
            FontSize = fontSize;

            Font = new Font(DefaultFontPath);


        }

        public override void OnDestroy()
        {
        }

        public override void OnLoad()
        {
        }

        public override void OnUpdate()
        {
            Text displayText = new Text(Font, Text, FontSize);
            if (Centered)
            {
                FloatRect textRect = displayText.GetLocalBounds();
                displayText.Origin = new Vector2(textRect.Left + textRect.Width * 0.5f, textRect.Top + textRect.Height * 0.5f);
                displayText.Position = Position;
                displayText.FillColor = Color;
                Engine.App.Draw(displayText);

            }
        }
    }
}
