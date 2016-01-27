using System;
using System.Collections.Generic;
using System.Threading;
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
            double maxDistance = Double.MaxValue;
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

            // TODO: Return amb coef?
            if (intersection == null) return Globals.WORLD_COLOR;
            if (!intersection.Intersected) return Globals.WORLD_COLOR;

            if (intersection.Object.Translucent && recursion < Globals.MAX_RECURSION)
            {
                //Translucent
                double k_refr, k_refl;

                var reflectionRay = ray.Reflection(intersection.Normal);

                var reflectionColor = ComputeColor(reflectionRay, recursion + 1, inside);

                var refractionRay = ray.Refraction(intersection.Normal, intersection.Object.Surface.RefractiveIndex, inside);

                var refractionColor = ComputeColor(refractionRay, recursion + 1, !inside);

                ray.Fresnel(intersection.Normal, refractionRay, intersection.Object.Surface.RefractiveIndex, out k_refl, out k_refr, inside);

                return reflectionColor * k_refr + refractionColor * k_refl;
            }

            //TODO: Should it be amb?
            var color = new Color();
            foreach (var light in Lights)
            {
                // Verify if there is any object between the intersecction point and this light
                var shadowRay = new Ray
                {
                    Direction = light.Position - intersection.Point,
                    Origin = intersection.Point
                };
                var blocked = false;
                foreach (var thing in Objects)
                {
                    Intersection dummy;
                    if (thing.Intersected(shadowRay, out dummy))
                    {
                        blocked = true;
                        break;
                    }
                }

                if (!blocked)
                {
                    var diffuse = intersection.Object.Surface.Color *
                                    intersection.Normal.Direction.Dot(shadowRay.Direction) *
                                    light.IntensityFactor(intersection.Point);

                    var reflection = ray.Reflection(intersection.Normal);

                    var specular = new Color(1,1,1) *
                                    intersection.Object.Surface.SpecularCoef *
                                    Math.Pow(reflection.Direction.Dot((Camera.Position - intersection.Point).Normalize()),
                                    intersection.Object.Surface.SpecularN);

                    color = color + diffuse + specular;
                }
            }

            return color;
        }
    }
}