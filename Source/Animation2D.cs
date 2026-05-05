using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LateNightGameEngine.Source
{
    internal class Animation2D
    {
        //data class.
        public Sprite sprite { get; set; }
        public Texture texture { get; set; }
        public Vector2 Frame { get; set; } //this is how big one frame is.
        public Vector2 FrameScale { get; set; } //determines the number of the sprite in the sheet.
        float lastFrame = 0f;
        
        public float TotalFrames
        {
            get
            {
                return FrameScale.X * FrameScale.Y;
            }
            set
            {
                lastFrame = value;
            }
        }


        public string Tag { get; set; }
        public IntRect FrameRect { get; set; }


        public Animation2D(string spriteSheetPath, Vector2 frameSize, int totalFrames)
        {
            Frame = frameSize;
            FrameScale = new Vector2(totalFrames, 1);

            try
            {
                texture = new Texture(spriteSheetPath);
            }
            catch (Exception ex)
            {
                Log.Error($"failed to load Animation2D texture at '{spriteSheetPath}' \n {ex}");
            }

            sprite = new Sprite(texture);
            FrameRect = new IntRect(new SFML.System.Vector2i((int)Frame.X, 0),new SFML.System.Vector2i( (int)Frame.X, (int)Frame.Y)); //... shouldn't that first arg be 0?

            sprite.Origin = frameSize * new Vector2(0.5f);
        }



        public void setFrame(int frame)
        {
            //4x4 -> 0, 1, 2, 3
            //
            //0,0 = top left

            int y = frame / (int)FrameScale.Y;
            int x = frame % (int)FrameScale.X;
            Log.Info($"Setting frame to {x}, {y}");

            Vector2 framePos = new Vector2(x, y);
            Vector2 newPos = framePos * Frame;
            FrameRect = new IntRect(new SFML.System.Vector2i((int)newPos.X - 16,(int)newPos.Y - 16),new SFML.System.Vector2i((int)Frame.X, (int)Frame.Y));
        }

    }
}
