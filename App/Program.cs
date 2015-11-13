using System;
using Objects.World.Solids;
using Objects.World.Space;
using Objects.World.Util;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var sphere = new Sphere
            {
                Center = new Point(0,0,0),
                Radius = 5,
                Surface = new Surface
                {
                    Diffuse = new Color(0.5,0.5,0.5),
                    Reflection = 0.9,
                },
            };

            var ray = new Ray
            {
                Origin = new Point(10, 0, 1),
                Direction = new Vector(-1, 0 ,0)
            };

            Console.WriteLine(sphere);
            Console.WriteLine(ray);
            Console.WriteLine(sphere.Intersected(ray));
            Console.ReadLine();
        }
    }
}
