using System;
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
                Radius = 20.0,
                Surface = new Surface
                {
                    Diffuse = new Color(0.5, 0.5, 0.5),
                    Reflection = 0
                }
            };
            Console.WriteLine(s);

            var m = new Matrix()
            {
                [0] = new Vector(2, 0, 0).Array(),
                [1] = new Vector(0, 2, 0).Array(),
                [2] = new Vector(0, 0, 2).Array(),
                [3] = new Point(0, 20, 0).Array(),
            };
            Console.WriteLine(s.Transform(m));

            Console.ReadLine();
        }
    }
}
