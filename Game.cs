using LateNightGameEngine.Source;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateNightGameEngine
{
    internal class Game : Engine
    {
        public Game() : base(1280,720,"Engine Test", Color.Cyan) { }

        public override void OnLoad()
        {
        }

        public override void OnUnload() { }
    }
}
