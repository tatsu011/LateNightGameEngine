using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateNightGameEngine.Source
{
    internal class AudioPlayer
    {
        public string Tag;
        public int Volume = 50;
        public Dictionary<string, SoundEffect> Sounds = new();

        public AudioPlayer(int volume)
        {
            Volume = volume;
        }

        public void AddSFX(SoundEffect sfx)
        {
            Sounds.Add(sfx.Tag, sfx);
        }

        public void RemoveSFX(SoundEffect sfx)
        {
            if(!Sounds.ContainsKey(sfx.Tag)) { return; }
            Sounds.Remove(sfx.Tag);
        }

        public void Play(string soundName)
        {
            if (Sounds.ContainsKey(soundName))
            {
                Sounds[soundName].SoundPlayer.Volume = Volume;
                Sounds[soundName].SoundPlayer.Play();
            }
        }
    }
}
