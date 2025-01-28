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
        public Game() : base(1280,720,"Engine Test", Color.Black) { }

        Player player;

        public override void OnLoad()
        {
            player = new Player(new Vector2(400, 400), Vector2.Zero(), "Player");
        }

        public override void OnUnload() { }

        public override void OnUpdate()
        {
            //Log.Info($"Player is at: {player.Position.X}, {player.Position.Y}");

            base.OnUpdate();
        }
    }
}
