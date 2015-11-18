using System;
using Raytracer.World;
using Raytracer.World.Space;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var camera = new Camera(new Point(0, 0, 100), new Vector(0, 0, -1));

            Console.WriteLine(camera);
            Console.WriteLine(camera.Pixel(300, 400));

            Console.ReadLine();
        }
    }
}
