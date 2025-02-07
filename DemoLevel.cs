using LateNightGameEngine.Source;
using nkast.Aether.Physics2D.Dynamics;
using nkast.Aether.Physics2D.Dynamics.Contacts;
using SFML.Graphics;
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
        int score = 0;
        Label scoreLabel;
        List<Point> points;

        public override string Name { get; set; }
        public override bool Init { get; set; }

        public DemoLevel(string name) : base(name)
        {
        }

        public override void OnLoad()
        {

            player = new Player(new Vector2(640f, 360f), new Vector2(50f), "Player");
            Wall wall = new Wall(new Vector2(640f, 0f), new Vector2(1280, 20), "Wall");
            Wall wall2 = new Wall(new Vector2(640f, 720f), new Vector2(1280, 20), "Wall");
            Wall wall3 = new Wall(new Vector2(0f, 360f), new Vector2(20, 720), "Wall");
            Wall wall4 = new Wall(new Vector2(1280f, 360f), new Vector2(20, 720), "Wall");
            scoreLabel = new Label("Score: 0", 32, new Vector2(400, 100), Color.White, "score Label", false);
            //point = new Point(new Vector2(200, 200), new Vector2(20), "point");
            //point.onCollision.Add(Collision_OnCollision);
            points = new List<Point>();
            points.Add(new Point(new Vector2(200, 200), new Vector2(20), "point"));
            points.Add(new Point(new Vector2(300, 300), new Vector2(20), "point"));
            points.Add(new Point(new Vector2(200, 300), new Vector2(20), "point"));
            points.Add(new Point(new Vector2(300, 200), new Vector2(20), "point"));
            points.Add(new Point(new Vector2(400, 400), new Vector2(20), "point"));
            points.Add(new Point(new Vector2(500, 500), new Vector2(20), "point"));
            points.Add(new Point(new Vector2(400, 500), new Vector2(20), "point"));
            points.Add(new Point(new Vector2(500, 400), new Vector2(20), "point"));
            points.Add(new Point(new Vector2(200, 400), new Vector2(20), "point"));
            points.Add(new Point(new Vector2(300, 500), new Vector2(20), "point"));
            points.Add(new Point(new Vector2(200, 500), new Vector2(20), "point"));
            points.Add(new Point(new Vector2(300, 400), new Vector2(20), "point"));


            foreach (Point p in points)
            {
                p.onCollision.Add(Collision_OnCollision);
            }


            
        }

        public override void OnUpdate()
        {
            scoreLabel.Text = $"Score: {score}";
        }

        private bool Collision_OnCollision(Fixture sender, Fixture other, Contact contact)
        {
            score++;
            if (score == 10)
            {
                LevelManager.ChangeLevel("Demo2");
            }
            return true;
        }
    }
}
