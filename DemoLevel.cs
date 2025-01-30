using LateNightGameEngine.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateNightGameEngine
{
    internal class DemoLevel : Level
    {
        Player player;

        public override string Name { get; set; }
        public override bool Init { get; set; }

        public DemoLevel(string name) : base(name)
        {
        }

        public override void OnLoad()
        {

            player = new Player(new Vector2(400, 400), Vector2.Zero(), "Player");
        }

        public override void OnUpdate()
        {
        }
    }
}
