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
            var things = new List<Thing>();
            var lights = new List<Light>();

            //            things.Add(new Sphere
            //            {
            //                Center = new Point(0, -1250, 0),
            //                Radius = 750,
            //                Surface = new Surface
            //                {
            //                    Color = new Color(0, 1, 0),
            //                    SpecularCoef = 0.5,
            //                    SpecularN = 10
            //                }
            //            }.Transform(new Matrix(
            //                new Vector(1, 0, 0),
            //                new Vector(0, 1, 0),
            //                new Vector(0, 0, 1),
            //                new Point(-1000, 0, 0)
            //            )));


            //            things.Add(new Sphere
            //            {
            //                Center = new Point(1000, -1500, 1000),
            //                Radius = 500,
            //                Surface = new Surface
            //                {
            //                    Color = new Color(0, 0, 1),
            //                    ReflectanceIndex = 0,
            //                    SpecularCoef = 0.5,
            //                    SpecularN = 15
            //                }
            //            });
            //            things.Add(new Sphere
            //            {
            //                Center = new Point(-1000, -1250, 250),
            //                Radius = 750,
            //                Surface = new Surface
            //                {
            //                    Color = new Color(1, 0.5, 0),
            //                    SpecularCoef = 0.5,
            //                    SpecularN = 10
            //                }
            //            });

//            things.Add(new Sphere
//            {
//                Center = new Point(1000, -1400, 1250),
//                Radius = 600,
//                Surface = new Surface
//                {
//
//                    Color = new Color(0, 0, 1),
//                    RefractiveIndex = 1.9,
//                    SpecularCoef = 1
//                }
//            });
//            things.Add(new Sphere
//            {
//                Center = new Point(-1000, -1250, 250),
//                Radius = 750,
//                Surface = new Surface
//                {
//                    Color = new Color(1, 0.5, 0),
//                    ReflectanceIndex = 0.75,
//                }
//            });

            things.Add(new Sphere
            {
                Center = new Point(1250, -600, 750),
                Radius = 400,
                Surface = new Surface
                {
                    Color = new Color(0, 0, 1),
                    RefractiveIndex = 1.9,
                    SpecularCoef = 1
                }
            });
            things.Add(new Sphere
            {
                Center = new Point(-1000, -1250, 250),
                Radius = 750,
                Surface = new Surface
                {
                    Color = new Color(1, 0.5, 0),
                    ReflectanceIndex = 0.75,
                }
            });
            things.Add(new Triangle
            {
                P1 = new Point(1750, -1000, 1250),
                P2 = new Point(750, -1000, 1250),
                P3 = new Point(750, -1000, 750),
                Surface = new Surface
                {
                    Color = new Color(1, 1, 0)
                }
            });
            things.Add(new Triangle
            {
                P1 = new Point(1750, -1000, 1250),
                P2 = new Point(1750, -1000, 750),
                P3 = new Point(750, -1000, 750),
                Surface = new Surface
                {
                    Color = new Color(1, 1, 0)
                }
            });
            things.Add(new Triangle
            {
                P1 = new Point(750, -2000, 750),
                P2 = new Point(1750, -1000, 750),
                P3 = new Point(750, -1000, 750),
                Surface = new Surface
                {
                    Color = new Color(1, 1, 0)
                }
            });
            things.Add(new Triangle
            {
                P1 = new Point(750, -2000, 750),
                P2 = new Point(1750, -1000, 750),
                P3 = new Point(1750, -2000, 750),
                Surface = new Surface
                {
                    Color = new Color(1, 1, 0)
                }
            });
            things.Add(new Triangle
            {
                P1 = new Point(1750, -1000, 1250),
                P2 = new Point(1750, -1000, 750),
                P3 = new Point(1750, -2000, 750),
                Surface = new Surface
                {
                    Color = new Color(1, 1, 0)
                }
            });
            things.Add(new Triangle
            {
                P1 = new Point(1750, -1000, 1250),
                P2 = new Point(1750, -2000, 1250),
                P3 = new Point(1750, -2000, 750),
                Surface = new Surface
                {
                    Color = new Color(1, 1, 0)
                }
            });
            things.Add(new Triangle
            {
                P1 = new Point(1750, -1000, 1250),
                P2 = new Point(1750, -2000, 1250),
                P3 = new Point(750, -2000, 1250),
                Surface = new Surface
                {
                    Color = new Color(1, 1, 0)
                }
            });
            things.Add(new Triangle
            {
                P1 = new Point(1750, -1000, 1250),
                P2 = new Point(750, -1000, 1250),
                P3 = new Point(750, -2000, 1250),
                Surface = new Surface
                {
                    Color = new Color(1, 1, 0)
                }
            });
            things.Add(new Triangle
            {
                P1 = new Point(750, -1000, 750),
                P2 = new Point(750, -1000, 1250),
                P3 = new Point(750, -2000, 1250),
                Surface = new Surface
                {
                    Color = new Color(1, 1, 0)
                }
            });
            things.Add(new Triangle
            {
                P1 = new Point(750, -1000, 750),
                P2 = new Point(750, -2000, 750),
                P3 = new Point(750, -2000, 1250),
                Surface = new Surface
                {
                    Color = new Color(1, 1, 0)
                }
            });

            things.Add(new Plane
            {
                Definition = new Ray
                {
                    Direction = new Vector(0, 1, 0),
                    Origin = new Point(0, -2000, 0)
                },
                Surface = new Surface
                {
                    Color = new Color(1, 1, 1),
                    ReflectanceIndex = 0
                }
            });
            things.Add(new Plane
            {
                Definition = new Ray
                {
                    Direction = new Vector(0, -1, 0),
                    Origin = new Point(0, 2000, 0)
                },
                Surface = new Surface
                {
                    Color = new Color(1, 1, 1),
                    ReflectanceIndex = 0
                }
            });
            things.Add(new Plane
            {
                Definition = new Ray
                {
                    Direction = new Vector(0, 0, 1),
                    Origin = new Point(0, 0, -1000)
                },
                Surface = new Surface
                {
                    Color = new Color(1, 1, 1),
                    ReflectanceIndex = 0
                }
            });
            things.Add(new Plane
            {
                Definition = new Ray
                {
                    Direction = new Vector(-1, 0, 0),
                    Origin = new Point(2000, 0, 0)
                },
                Surface = new Surface
                {
                    Color = new Color(1, 0, 0),
                    ReflectanceIndex = 0
                }
            });
            things.Add(new Plane
            {
                Definition = new Ray
                {
                    Direction = new Vector(1, 0, 0),
                    Origin = new Point(-2000, 0, 0)
                },
                Surface = new Surface
                {
                    Color = new Color(0, 1, 0),
                    ReflectanceIndex = 0
                }
            });


            lights.Add(new Light
            {
                Intensity = 2000000,
                Position = new Point(0, 1900, 1000)
            });

            var c = new Camera(new Point(0, 0, 8000), new Vector(0, 0, -1))
            {
                F = 750,
                Viewport = new Viewport(500, 500)
            };

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
