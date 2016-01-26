using System;

namespace Raytracer.World.Space
{
    public class Vector : Coordinate
    {
        public Vector()
        {
        }


        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Generates a ray from p1->p2 using p1 as the origin
        /// </summary>
        /// <param name="p1">A point</param>
        /// <param name="p2">A point</param>
        public Vector(Point p1, Point p2)
        {
            X = p2.X - p1.X;
            Y = p2.Y - p1.Y;
            Z = p2.Z - p1.Z;
        }

        public double[] Array()
        {
            return new[] { X, Y, Z, 0 };
        }

        public Vector Transform(Matrix tm)
        {
            return new Vector
            {
                X = tm[0][0] * X + tm[1][0] * Y + tm[2][0] * Z,
                Y = tm[0][1] * X + tm[1][1] * Y + tm[2][1] * Z,
                Z = tm[0][2] * X + tm[1][2] * Y + tm[2][2] * Z
            };
        }

        public Point Point()
        {
            return new Point(X, Y, Z);
        }

        public static Vector operator -(Vector v)
        {
            return new Vector(-v.X, -v.Y, -v.Z);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public static Vector operator *(Vector v, double k)
        {
            return new Vector(k * v.X, k * v.Y, k * v.Z);
        }

        public double Module()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public Vector Normalize()
        {
            var module = Module();
            return new Vector
            {
                X = X / module,
                Y = Y / module,
                Z = Z / module
            };
        }

        public double Dot(Vector v)
        {
            return X * v.X + Y * v.Y + Z * v.Z;
        }

        public Vector Cross(Vector v)
        {
            return new Vector
            {
                X = Y * v.Z - Z * v.Y,
                Y = Z * v.X - X * v.Z,
                Z = X * v.Y - Y * v.X
            };
        }

        public override string ToString()
        {
            return $"Vector[X={X}, Y={Y}, Z={Z}]";
        }
    }
}