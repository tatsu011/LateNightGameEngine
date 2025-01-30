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

        

        public override void OnLoad()
        {
            DemoLevel level1 = new DemoLevel("Demo");
            DemoLevel2 level2 = new DemoLevel2("Demo2");
            LevelManager.ChangeLevel("Demo");
        }

        public override void OnUnload() { }

        public override void OnUpdate()
        {
            if(Input.ActionOnKeyDown("Confirm"))
            {
                LevelManager.ChangeLevel("Demo2");
            }
            if (Input.ActionOnKeyDown("Cancel"))
            {
                LevelManager.ChangeLevel("Demo");
            }
            base.OnUpdate();
        }
    }
}
