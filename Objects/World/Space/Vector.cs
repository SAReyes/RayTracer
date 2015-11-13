using System;

namespace Objects.World.Space
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

        public double Module()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public Vector Normalize()
        {
            var module = Module();
            return new Vector
            {
                X = X/module,
                Y = Y/module,
                Z = Z/module
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