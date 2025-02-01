using nkast.Aether.Physics2D.Dynamics;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateNightGameEngine.Source
{
    internal class KinematicBody : GameObject
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }

        public Body body;
        public bool DisableCollision = false;
        public bool DebugCollisions = false;
        private Shape2D shape;

        public List<OnCollisionEventHandler> onCollision = new List<OnCollisionEventHandler>();
        public List<OnSeparationEventHandler> onSeparations = new List<OnSeparationEventHandler>();

        public Vector2 Velocity = Vector2.Zero();

        public KinematicBody(Vector2 position, Vector2 scale, string tag)
        {
            Position = position;
            Scale = scale;
            Tag = tag;
            shape = new Shape2D(Shape2D.Shapes.Rectangle, position, scale, tag, Color.Transparent, Color.Transparent);
        }


        public override void OnDestroy()
        {
            shape.DestroySelf();
            if (Engine.world.BodyList.Contains(body))
            {
                Engine.world.Remove(body);
            }
        }

        public override void OnLoad()
        {
            body = Engine.world.CreateBody(Position);
            body.CreateRectangle(Scale.X, Scale.Y, 1f, new Vector2());
            body.BodyType = BodyType.Dynamic;
            body.IgnoreGravity = true;
            body.IgnoreCCD = DisableCollision;
            body.FixtureList[0].Tag = Tag;
            onCollision.Add(Body_OnCollision);
            onSeparations.Add(Body_OnSeparation);

            foreach (OnCollisionEventHandler handler in onCollision)
            {
                body.OnCollision += handler;
            }

            foreach (OnSeparationEventHandler handler in onSeparations)
            {
                body.OnSeparation += handler;
            }

        }

        public void Move()
        {
            if (body != null)
            {
                body.LinearVelocity = Velocity;
            }
        }


        public override void OnUpdate()
        {
            Position = new Vector2(body.Position.X, body.Position.Y);
            shape.Position = Position;


        }

        public void CollisionDebug(bool value)
        {
            DebugCollisions = value;
            if (DebugCollisions) { shape.OutlineColor = Color.Green; }
            else { shape.OutlineColor = Color.Transparent; }
        }

        private void Body_OnSeparation(Fixture sender, Fixture other, nkast.Aether.Physics2D.Dynamics.Contacts.Contact contact)
        {
        }

        private bool Body_OnCollision(Fixture sender, Fixture other, nkast.Aether.Physics2D.Dynamics.Contacts.Contact contact)
        {
            return true;
        }
    }
}
