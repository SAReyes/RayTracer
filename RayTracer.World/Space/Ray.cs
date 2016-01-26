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
            var n = inside ? coef : 1 / coef;
            var r = -Direction;
            var ni = normal.Direction.Dot(r);
            var t1 = n * ni - Math.Sqrt(1 - n * n * (1 - ni * ni));
            var left = normal.Direction * t1;
            var right = r * n;
            return new Ray
            {
                Direction = left - right,
                Origin = normal.Origin
            };
        }

        public void Fresnel(Ray normal, Ray refracted, double coef, out double k_refl, out double k_refr,
            bool inside = false)
        {
            var n1 = inside ? coef : 1;
            var n2 = inside ? 1 : coef;

            var cos_i = (-Direction).Dot(normal.Direction);
            var cos_t = refracted.Direction.Dot(-normal.Direction);

            var _rs = Math.Abs((n1 * cos_i - n2 * cos_t) / (n1 * cos_i + n2 * cos_t));
            var _rp = Math.Abs((n1 * cos_t - n2 * cos_i) / (n1 * cos_t + n2 * cos_i));

            var rs = _rs * _rs;
            var rp = _rp * _rp;

            k_refl = (rs + rp) /2;
            k_refr = 1 - k_refl;
        }
        public override string ToString()
        {
            return $"Ray[Origin={Origin}, Direction={Direction}]";
        }
    }
}