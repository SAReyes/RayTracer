using System;
using Raytracer.World.Space;
using Raytracer.World.Util;

namespace Raytracer.World.Solids
{
    public class Sphere : Thing
    {
        public Point Center { get; set; }
        public double Radius { get; set; }

        //TODO: Tolerance
        public override bool Intersected(Ray ray, out Intersection intersection)
        {
            intersection = new Intersection { Object = this };

            var d = ray.Origin - Center;
            var b = d.Dot(ray.Direction);
            var c = d.Dot(d) - Radius * Radius;

            var disc = b * b - c;
            if (disc < Globals.EPSILON)
            {
                intersection = Intersection.None;
                return false;
            }

            var l1 = -b + Math.Sqrt(disc);
            var l2 = -b - Math.Sqrt(disc);

            Point origin;

            if (disc > Globals.EPSILON)
            {
                if (l1 < Globals.EPSILON && l2 < Globals.EPSILON)
                {
                    intersection = Intersection.None;
                    return false;
                }

                if (l1 > Globals.EPSILON && l2 < Globals.EPSILON)
                {
                    origin = ray.Point(l1);
                }
                else if (l1 > l2 && l2 > Globals.EPSILON)
                {
                    origin = ray.Point(l2);
                }
                else
                {
                    intersection = Intersection.None;
                    return false;
                }
            }
            else
            {
                origin = ray.Point(l1);
            }
            intersection.Distance = ray.Origin.Distance(origin);
            intersection.Normal = new Ray
            {
                Origin = origin,
                Direction = origin - Center
            };

            return true;
        }

        public Sphere Transform(Matrix tm)
        {
            var radius = Math.Abs(tm[0][0] - tm[1][1]) < Globals.EPSILON && Math.Abs(tm[1][1] - tm[2][2]) < Globals.EPSILON ?
                Radius * tm[0][0] : Radius;

            return new Sphere
            {
                Radius = radius,
                Center = Center.Transform(tm),
                Surface = Surface
            };
        }

        protected bool Equals(Sphere other)
        {
            return Equals(Center, other.Center) && Radius.Equals(other.Radius);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Sphere) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Center != null ? Center.GetHashCode() : 0)*397) ^ Radius.GetHashCode();
            }
        }

        public override string ToString()
        {
            return $"Sphere[Center={Center}, Radius={Radius}, Surface={Surface}";
        }
    }
}