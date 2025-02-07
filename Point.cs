using LateNightGameEngine.Source;
using nkast.Aether.Physics2D.Dynamics;
using nkast.Aether.Physics2D.Dynamics.Contacts;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateNightGameEngine
{
    internal class Point : StaticBody
    {

        AudioPlayer aPlayer;

        public Point(Vector2 position, Vector2 scale, string tag) : base(position, scale, tag)
        {
            Position = position;
            Scale = scale;
            Tag = tag;
        }

        public override void OnLoad()
        {
            AddChild(new Shape2D(Shape2D.Shapes.Rectangle, Vector2.Zero(), Scale, Tag, Color.Transparent, Color.Cyan));
            onCollision.Add(Collision_OnCollision);
            aPlayer = new AudioPlayer(25);
            aPlayer.AddSFX(new SoundEffect("Assets/sfx.ogg", "point"));
            base.OnLoad();
        }

        private bool Collision_OnCollision(Fixture sender, Fixture other, Contact contact)
        {
            aPlayer.Play("point");
            DestroySelf();
            return true;
        }
    }
}
