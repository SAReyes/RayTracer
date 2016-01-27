using System;
using System.Collections.Generic;
using Raytracer.World;
using Raytracer.World.Solids;
using Raytracer.World.Space;
using Raytracer.World.Util;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Sphere
            {
                Center = new Point(0, 0, 0),
                Radius = 500,
                Surface = new Surface
                {
                    Color = new Color(0, 1, 0),
                    RefractiveIndex = 0
                }
            };
            var p = new Plane
            {
                Definition = new Ray
                {
                    Direction = new Vector(0, 1, 0),
                    Origin = new Point(0, 0, 0)
                },
                Surface = new Surface
                {
                    Color = new Color(0.8,0.8,0.8),
                    RefractiveIndex = 0
                }
            };
            var l = new Light
            {
                Intensity = 1000000,
                Position = new Point(-400, 1000, 1000)
            };

            var things = new List<Thing>();
            var lights = new List<Light>();

            things.Add(s);
//            things.Add(p);
            lights.Add(l);

            var c = new Camera(new Point(0, 0, 800), new Vector(0, 0, -1));

            var scene = new Scene
            {
                Camera = c,
                Lights = lights,
                Objects = things
            };

            RayTracer.RayTracer.Compute(scene);

            Console.WriteLine("Completed!");
        }
    }
}
