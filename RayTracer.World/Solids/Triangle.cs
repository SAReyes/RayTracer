using Raytracer.World.Space;
using Raytracer.World.Util;

namespace Raytracer.World.Solids
{
    public class Triangle : Thing
    {
        public Point P1 { get; set; }
        public Point P2 { get; set; }
        public Point P3 { get; set; }

        public Ray Normal => new Ray
        {
            Direction = (P2 - P1).Cross(P3 - P1)
        };


        public override bool Intersected(Ray ray, out Intersection intersection)
        {
            intersection = new Intersection { Object = this };
            var normal = Normal;
            var esc = normal.Direction.Dot(ray.Direction);
            if (esc > Globals.EPSILON)
            {
                intersection.Normal = -normal;
            }
            else if (esc < Globals.EPSILON)
            {
                intersection.Normal = normal;
            }
            else
            {
                intersection = Intersection.None;
                return false;
            }

            var lambda = (P1 - ray.Origin).Dot(normal) / esc;
            if (lambda <= Globals.EPSILON)
            {
                intersection = Intersection.None;
                return false;
            }
            var lambdaPoint = ray.Point(lambda);

            var s1 = (P2 - P1).Cross(lambdaPoint - P1).Dot(normal);
            var s2 = (P3 - P2).Cross(lambdaPoint - P2).Dot(normal);
            var s3 = (P1 - P3).Cross(lambdaPoint - P3).Dot(normal);

            if (s1*s2 < Globals.EPSILON)
            {
                intersection = Intersection.None;
                return false;
            }
            if (s1 * s3 < Globals.EPSILON)
            {
                intersection = Intersection.None;
                return false;
            }
            
            intersection.Normal.Origin = lambdaPoint;
            intersection.Distance = lambdaPoint.Distance(ray.Origin);

            return true;
        }
    }
}