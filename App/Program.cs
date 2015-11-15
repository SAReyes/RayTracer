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
            var plane = new Plane
            {
                Definition = new Ray
                {
                    Direction = new Vector(1, 0, 0),
                    Origin = new Point()
                }
            };

            var ray = new Ray
            {
                Direction = new Vector(-2, 0, 0),
                Origin = new Point(10, 0, 0)
            };

            Console.WriteLine(plane);
            Console.WriteLine();
            Console.WriteLine(ray);
            Console.WriteLine();
            Console.WriteLine(plane.Intersected(ray));

            Console.ReadLine();
        }
    }
}
