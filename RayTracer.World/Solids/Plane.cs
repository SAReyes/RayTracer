using Raytracer.World.Space;
using Raytracer.World.Util;

namespace Raytracer.World.Solids
{
    public class Plane : Thing
    {

        public Ray Definition { get; set; }
        public Vector Normal => Definition.Direction;

        public double D => -(Definition.Origin.X * Normal.X +
                             Definition.Origin.Y * Normal.Y +
                             Definition.Origin.Z * Normal.Z);

        public override bool Intersected(Ray ray, out Intersection intersection)
        {
            intersection = new Intersection { Object = this, Normal = new Ray() };

            var prodEsc = ray.Direction.Dot(Normal);

            if (prodEsc > Globals.EPSILON)
            {
                intersection.Normal.Direction = -Normal;
            }
            else if (prodEsc < Globals.EPSILON)
            {
                intersection.Normal.Direction = Normal;
            }
            else
            {
                intersection = Intersection.None;
                return false;
            }

            var lambda = -(D +
                Normal.X * ray.Origin.X +
                Normal.Y * ray.Origin.Y +
                Normal.Z * ray.Origin.Z) / prodEsc;

            if (lambda < Globals.EPSILON)
            {
                intersection = Intersection.None;
                return false;
            }

            intersection.Normal.Origin = new Point
            {
                X = ray.Origin.X + lambda * ray.Direction.X,
                Y = ray.Origin.Y + lambda * ray.Direction.Y,
                Z = ray.Origin.Z + lambda * ray.Direction.Z
            };
            intersection.Distance = ray.Origin.Distance(intersection.Point);

            return true;
        }

        public Plane Transform(Matrix tm)
        {
            return new Plane
            {
                Definition = Definition.Transform(tm)
            };
        }

        public override string ToString()
        {
            return $"Plane=[Definition={Definition}]";
        }

        protected bool Equals(Plane other)
        {
            return Equals(Definition, other.Definition);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Plane) obj);
        }

        public override int GetHashCode()
        {
            return (Definition != null ? Definition.GetHashCode() : 0);
        }
    }
}