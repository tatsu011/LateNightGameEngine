using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace LateNightGameEngine.Source
{
    internal class AnimatedSprite2D : GameObject
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }

        public float FrameTime { get; set; }
        public int FlipH = 1; //...shouldn't these be bools?
        public int FlipV = 1;

        public Animation2D CurrentAnimation { get; set; }
        public string CurrentAnimationName { get; set; }

        private Dictionary<string, Animation2D> Animations = new Dictionary<string, Animation2D>();
        private int CurrentFrame = 0;
        private float elapsedTime;

        public AnimatedSprite2D(float frameTime, Vector2 scale, string tag)
        {
            FrameTime = frameTime / 10;
            Scale = scale;
            Position = Vector2.Zero();
            Tag = tag;

        }

        public void AddAnimation(string animName, Animation2D data)
        {
            Animations.Add(animName, data);
            CurrentAnimation = data;
            CurrentAnimationName = animName;
        }

        public void RemoveAnimation(string target)
        {
            if(Animations.ContainsKey(target))
            {
                Animations.Remove(target); 
            }
        }

        public void Play(string name)
        {
            if (name == CurrentAnimationName)
            {
                return;
            }

            if(Animations.ContainsKey(name))
            {
                CurrentAnimation = Animations[name];
                CurrentAnimationName = name;
                CurrentFrame = 0;
            }
            else
            {
                Log.Error($"[AnimatedSprite2D] Error, could not find the {name} animation in {Tag}");
            }
        }


        public override void OnDestroy()
        {
        }

        public override void OnLoad()
        {
        }

        public override void OnUpdate()
        {
            if (CurrentAnimation == null)
                return;

            elapsedTime += Time.deltaTime;

            if(elapsedTime >= FrameTime && CurrentAnimation.TotalFrames > 1)
            {
                CurrentFrame = (CurrentFrame == CurrentAnimation.TotalFrames - 1) ? 0 : CurrentFrame + 1;
                elapsedTime = 0f;
            }

            CurrentAnimation.FrameRect = new IntRect((int)(CurrentFrame * CurrentAnimation.Frame.X), 
                                                     0,
                                                     (int)CurrentAnimation.Frame.X, 
                                                     (int)CurrentAnimation.Frame.Y);

            CurrentAnimation.sprite.Position= Position;
            CurrentAnimation.sprite.Scale = new Vector2(Scale.X * FlipH, Scale.Y * FlipV);
            CurrentAnimation.sprite.TextureRect = CurrentAnimation.FrameRect;

            Engine.App.Draw(CurrentAnimation.sprite);
        }
    }
}
