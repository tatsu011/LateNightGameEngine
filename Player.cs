using LateNightGameEngine.Source;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateNightGameEngine
{
    internal class Player : KinematicBody
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }


        AnimatedSprite2D Animator;
        Camera cam;
        int Speed = 200;

        bool lookingRight = true;

        public Player(Vector2 position, Vector2 scale, string tag) : base(position, scale, tag)
        {
            Position = position;
            Scale = scale;
            Tag = tag;
        }

        public override void OnLoad()
        {
            Animator = new AnimatedSprite2D(1, new Vector2(4), "playerGfx");
            Animation2D run = new Animation2D("Assets/Run.png", new Vector2(16), 4);
            Animation2D Idle = new Animation2D("Assets/idle.png", new Vector2(16), 1);
            Animator.AddAnimation("Idle",Idle);
            Animator.AddAnimation("Run", run);
            AddChild(Animator);
            cam = new Camera(true, "playerCam");
            AddChild(cam);

            base.OnLoad();
        }

        public override void OnUpdate()
        {
            Velocity.X = Convert.ToInt32(Input.ActionKeyHeld("Right")) - Convert.ToInt32(Input.ActionKeyHeld("Left"));
            Velocity.Y = Convert.ToInt32(Input.ActionKeyHeld("Down")) - Convert.ToInt32(Input.ActionKeyHeld("Up"));

            Velocity = Velocity.Normalize() * Speed;


            Move();
            AnimationHandler();
            base.OnUpdate();
        }

        void AnimationHandler()
        {
            if (Velocity.X == 0 && Velocity.Y == 0)
            {
                Animator.Play("Idle");
            }
            else
            {
                Animator.Play("Run");
            }

            if(Velocity.X > 0 && !lookingRight)
            {
                flip();
            }
            if(Velocity.X < 0 && lookingRight)
            {
                flip();
            }

        }

        void flip()
        {
            Animator.FlipH = -Animator.FlipH;
            lookingRight = !lookingRight;
        }

    }
}
