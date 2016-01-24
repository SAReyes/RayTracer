using System;

namespace Raytracer.World.Space
{
    public class Point : Coordinate
    {
        public Point()
        {
        }

        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double[] Array()
        {
            return new[] { X, Y, Z, 1};
        }

        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
        }

        public static Vector operator -(Point p1, Point p2)
        {
            return new Vector(p2, p1);
        }

        public Point Transform(Matrix tm)
        {

            var x = tm[0][0] * X + tm[1][0] * Y + tm[2][0] * Z + tm[3][0];
            var y = tm[0][1] * X + tm[1][1] * Y + tm[2][1] * Z + tm[3][1];
            var z = tm[0][2] * X + tm[1][2] * Y + tm[2][2] * Z + tm[3][2];
            var h = tm[0][3] + tm[1][3] + tm[2][3] + tm[3][3];
            return new Point
            {
                X = x/h,
                Y = y/h,
                Z = z/h
            };
        }

        public override string ToString()
        {
            return $"Point[X={X}, Y={Y}, Z={Z}]";
        }
    }
}