using LateNightGameEngine.Source;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateNightGameEngine
{
    internal class DemoLevel2 : Level
    {
        Player player;
        Label label;

        public override string Name { get; set; }
        public override bool Init { get; set; }

        public DemoLevel2(string name) : base(name)
        {
        }

        public override void OnLoad()
        {
            label = new Label("Victory!", 12, new Vector2(640, 360), Color.White, "Victory", true);
        }

        public override void OnUpdate()
        {
        }
    }
}
