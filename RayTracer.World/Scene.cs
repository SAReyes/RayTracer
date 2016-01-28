using System;
using System.Collections.Generic;
using Raytracer.World.Space;
using Raytracer.World.Util;

namespace Raytracer.World
{
    public class Scene
    {
        public IList<Light> Lights { get; set; }
        public IList<Thing> Objects { get; set; }
        public Camera Camera { get; set; }

        public Color ComputeColor(Ray ray)
        {
            return ComputeColor(ray, 0);
        }

        private Color ComputeColor(Ray ray, int recursion, bool inside = false)
        {
            var maxDistance = Double.MaxValue;
            Intersection intersection = null;
            foreach (var thing in Objects)
            {
                Intersection dummy;
                if (!thing.Intersected(ray, out dummy)) continue;

                if (dummy.Distance < maxDistance)
                {
                    maxDistance = dummy.Distance;
                    intersection = dummy;
                }
            }

            // No intersections, get the world color
            if (intersection == null) return Globals.WORLD_COLOR;
            if (!intersection.Intersected) return Globals.WORLD_COLOR;

            if (intersection.Object.Surface.Delta && recursion < Globals.MAX_RECURSION)
            {
                //Translucent
                double k_refr, k_refl;
                var reflectionColor = new Color();
                var refractionColor = new Color();

                var reflectionRay = ray.Reflection(intersection.Normal);

                if (intersection.Object.Surface.ReflectanceIndex > Globals.EPSILON)
                {
                    reflectionColor = ComputeColor(reflectionRay, recursion + 1, inside);
                }

                var refractionRay = ray.Refraction(intersection.Normal, intersection.Object.Surface.RefractiveIndex, inside);

                if (intersection.Object.Surface.RefractiveIndex > Globals.EPSILON)
                {
                    refractionColor = ComputeColor(refractionRay, recursion + 1, !inside);
                }

                return reflectionColor * intersection.Object.Surface.ReflectanceIndex +
                       refractionColor * intersection.Object.Surface.SpecularCoef;
            }

            var color = intersection.Object.Surface.Color * Globals.AMB_COEF;
            foreach (var light in Lights)
            {
                // Verify if there is any object between the intersecction point and this light
                var lightRay = new Ray
                {
                    Direction = intersection.Point - light.Position,
                    Origin = light.Position
                };
                var blocked = false;
                foreach (var thing in Objects)
                {
                    Intersection lightIntersection;
                    var distanceHitLight = light.Position.Distance(intersection.Point);
                    if (thing.Intersected(lightRay, out lightIntersection) &&
                        Math.Abs(lightIntersection.Distance - distanceHitLight) > Globals.EPSILON &&
                        lightIntersection.Distance < distanceHitLight)
                    {
                        blocked = true;
                        break;
                    }
                }

                if (!blocked)
                {
                    var diffuse = intersection.Object.Surface.Color *
                                  intersection.Normal.Direction.Dot((lightRay * -1).Direction);

                    var reflection = lightRay.Reflection(intersection.Normal);

                    var specular = Globals.LIGHT_COLOR *
                                   intersection.Object.Surface.SpecularCoef *
                                   Math.Pow(reflection.Direction.Dot(ray.Direction * -1),
                                       intersection.Object.Surface.SpecularN);

                    color = color + (diffuse + specular) * light.IntensityFactor(intersection.Point);
                }
            }

            return color;
        }
    }
}