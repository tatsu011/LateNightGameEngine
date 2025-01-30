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

        AnimatedSprite2D Animator;
        Camera cam;

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
            Animator = new AnimatedSprite2D(1, new Vector2(4), "playerGfx");
            Animation2D run = new Animation2D("Assets/Run.png", new Vector2(16), 4);
            Animation2D Idle = new Animation2D("Assets/idle.png", new Vector2(16), 1);
            Animator.AddAnimation("Idle",Idle);
            Animator.AddAnimation("Run", run);
            AddChild(Animator);
            cam = new Camera(true, "playerCam");
            AddChild(cam);
        }

        public override void OnUpdate()
        {
            bool isMoving = false;
            if(Input.ActionKeyHeld("Up"))
            {
                isMoving = true;
                Position.Y -= 1;
            }
            else if (Input.ActionKeyHeld("Down"))
            {
                isMoving = true;
                Position.Y += 1;
            }
            if (Input.ActionKeyHeld("Right"))
            {
                isMoving = true;
                Animator.FlipH = 1;
                Position.X += 1;
            }
            else if (Input.ActionKeyHeld("Left"))
            {
                isMoving = true;
                Animator.FlipH = -1;
                Position.X -= 1;
            }


            if (isMoving)
            {
                Animator.Play("Run");
            }
            else
            {
                Animator.Play("Idle");
            }
        }
    }
}
