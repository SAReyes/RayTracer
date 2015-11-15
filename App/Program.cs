using System;
using Raytracer.World;
using Raytracer.World.Solids;
using Raytracer.World.Space;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var camera = new Camera(new Point(0, 0, 0), new Vector(0, -1, -1));

            Console.WriteLine(camera);

            Console.ReadLine();
        }
    }
}
