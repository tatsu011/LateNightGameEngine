using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateNightGameEngine.Source
{
    public class Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2()
        {
            X = 0;
            Y = 0;
        }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }   

        public Vector2(float num)
        {
            X = num;
            Y = num;
        }

        public static Vector2 Zero() //replace this with a Property with gettter method.
        {
            return new Vector2(0, 0);
        }
        //TODO: Vector static directions. (Up, Down, Left, Right)

        public Vector2 Normalize()
        {
            if (X == 0 && Y == 0)
                return this;

            float num = (float)Math.Sqrt(X * X + Y * Y);
            float iNum = 1f / num;

            return new Vector2(X * iNum, Y * iNum);
        }

        //Vector/Vector math.
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X - b.X, a.Y - b.Y);
        }
        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X * b.X, a.Y * b.Y);
        }
        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X / b.X, a.Y / b.Y);
        }

        //Vector/float math
        public static Vector2 operator +(Vector2 a, float b)
        {
            return new Vector2(a.X + b, a.Y + b);
        }
        public static Vector2 operator -(Vector2 a, float b)
        {
            return new Vector2(a.X - b, a.Y - b);
        }
        public static Vector2 operator *(Vector2 a, float b)
        {
            return new Vector2(a.X * b, a.Y * b);
        }
        public static Vector2 operator /(Vector2 a, float b)
        {
            return new Vector2(a.X / b, a.Y / b);
        }


        //conversion operator for different versions of Vector 2.
        public static implicit operator SFML.System.Vector2f(Vector2 v)
        {
            return new SFML.System.Vector2f(v.X, v.Y);
        }
        public static implicit operator nkast.Aether.Physics2D.Common.Vector2(Vector2 v)
        {
            return new nkast.Aether.Physics2D.Common.Vector2(v.X, v.Y);
        }

        //Eventually operators with int/floats.

    }
}
