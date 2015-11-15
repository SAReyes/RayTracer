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


        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
        }

        public static Vector operator -(Point p1, Point p2)
        {
            return new Vector(p2, p1);
        }

        public override string ToString()
        {
            return $"Point[X={X}, Y={Y}, Z={Z}]";
        }
    }
}