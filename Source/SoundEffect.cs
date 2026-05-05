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
        readonly SoundBuffer Buffer;
        public Sound SoundPlayer;
        public string Tag;


        public SoundEffect(string path, string tag, bool looping = false)
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

            SoundPlayer = new(Buffer)
            {
                IsLooping = looping
            };


        }

        public void Play()
        {
            SoundPlayer.Play();
        }

        public void Stop()
        {
            SoundPlayer.Stop();
        }
    }
}
