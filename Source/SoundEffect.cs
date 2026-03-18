using SFML.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateNightGameEngine.Source
{
    internal class SoundEffect
    {
        SoundBuffer Buffer;
        public Sound SoundPlayer;
        public string Tag;


        public SoundEffect(string path, string tag)
        {
            Tag = tag;

            try
            {
                Buffer = new SoundBuffer(path);
            }
            catch (Exception ex)
            {
                Log.Error($"[SoundEffect] Audio File {tag} at {path} does not exist. Error {ex}");
                return;
            }

            SoundPlayer = new Sound(Buffer);


        }

        public void Play(bool loop = false)
        {
            SoundPlayer.Play();
        }

        public void Stop()
        {
            SoundPlayer.Stop();
        }
    }
}
