using LateNightGameEngine.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LateNightGameEngine
{
    internal class Wall : StaticBody
    {
        public Wall(Vector2 position, Vector2 scale, string tag) : base(position, scale, tag)
        {
           


        }

        public override void OnLoad()
        {
            AddChild(new Shape2D(Shape2D.Shapes.Rectangle, new Vector2(), Scale, Tag));

            base.OnLoad();
        }
    }
}
