using Objects.World.Space;
using Objects.World.Util;

namespace Objects.World.Solids
{
    public class Plane : Thing
    {

        public Ray Definition { get; set; }
        public Vector Normal => Definition.Direction;

        public override Intersection Intersected(Ray ray)
        {
            var intersection = new Intersection { Thing = this, Normal = new Ray() };

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
                return Intersection.None;
            }

            var lambda = -(
                Normal.X * ray.Origin.X +
                Normal.Y * ray.Origin.Y +
                Normal.Z * ray.Origin.Z) / prodEsc;

            if (lambda < Globals.EPSILON) { return Intersection.None; }

            intersection.Normal.Origin = new Point
            {
                X = ray.Origin.X + lambda * ray.Direction.X,
                Y = ray.Origin.Y + lambda * ray.Direction.Y,
                Z = ray.Origin.Z + lambda * ray.Direction.Z
            };

            return intersection;
        }

        public override string ToString()
        {
            return $"Plane=[Definition={Definition}]";
        }
    }
}