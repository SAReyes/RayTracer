using System;

namespace Raytracer.World.Space
{
    public class Ray
    {
        public Point Origin { get; set; }

        private Vector _direction;
        public Vector Direction
        {
            get { return _direction; }
            set { _direction = value.Normalize(); }
        }

        public Ray()
        {
            Origin = new Point();
        }

        public Ray Transform(Matrix tm)
        {
            return new Ray
            {
                Direction = Direction.Transform(tm),
                Origin = Origin.Transform(tm)
            };
        }

        public Point Point(double scalar)
        {
            return new Point
            {
                X = Origin.X + Direction.X * scalar,
                Y = Origin.Y + Direction.Y * scalar,
                Z = Origin.Z + Direction.Z * scalar
            };
        }

        public Ray Reflection(Ray normal)
        {
            return new Ray
            {
                Direction = Direction - normal.Direction * (2 * Direction.Dot(normal.Direction)),
                Origin = normal.Origin
            };
        }

        public Ray Refraction(Ray normal, double coef, bool inside = false)
        {
            var updatedNormal = inside ? -normal.Direction : normal.Direction;
            var nt = inside ? coef : 1 / coef;
            var ray = -Direction;
            var nDotI = updatedNormal.Dot(ray);
            var scalar = nt * nDotI - Math.Sqrt(1 - nt * nt * (1 - nDotI * nDotI));
            var leftTerm = updatedNormal * scalar;
            var rightTerm = ray * nt;
            return new Ray
            {
                Direction = leftTerm - rightTerm,
                Origin = normal.Origin
            };
        }

        public static Ray operator *(Ray r, double k)
        {
            return new Ray
            {
                Origin = r.Origin,
                Direction = new Vector(k * r.Direction.X, k * r.Direction.Y, k * r.Direction.Z)
            };
        }

        public static Ray operator -(Ray r)
        {
            return new Ray
            {
                Origin = r.Origin,
                Direction = -r.Direction
            };
        }

        public override string ToString()
        {
            return $"Ray[Origin={Origin}, Direction={Direction}]";
        }
    }
}