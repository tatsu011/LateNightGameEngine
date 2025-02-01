using LateNightGameEngine.Source;
using nkast.Aether.Physics2D.Dynamics;
using nkast.Aether.Physics2D.Dynamics.Contacts;
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
            Wall wall = new Wall(new Vector2(300, 400), new Vector2(50), "Wall");
            player.onCollision.Add(Body_OnCollision);
        }

        private bool Body_OnCollision(Fixture sender, Fixture other, Contact contact)
        {
            Log.Info($"[DemoLevel]{player.Tag} collided with a thing");
            return true;
        }

        public override void OnUpdate()
        {
        }
    }
}
