using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateNightGameEngine.Source
{
    public class Sprite2D : GameObject
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }

        private Texture texture { get; set; }
        private Vector2 Frame {  get; set; }
        public Sprite sprite { get; set; }

        public Sprite2D(string path, Vector2 position, Vector2 frameSize, Vector2 scale, string tag)
        {
            Position = position;
            Frame = frameSize;
            Scale = scale;
            Tag = tag;

            try
            {
                texture = new Texture(path);
            }
            catch (Exception ex)
            {
                Log.Error($"failed to load Sprite2D texture at '{path}' \n {ex}");
            }

            sprite = new Sprite(texture);
            sprite.Origin = frameSize * new Vector2(0.5f, 0.5f);

        }

        public override void OnDestroy()
        {
            
        }

        public override void OnLoad()
        {
            
        }

        public override void OnUpdate()
        {
            sprite.Position = Position;
            sprite.Scale = Scale;
            Engine.App.Draw(sprite);
        }
    }
}
