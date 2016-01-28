using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raytracer.World;
using Color = Raytracer.World.Util.Color;

namespace RayTracer
{
    public class RayTracer
    {
        public static void Compute(Scene scene, string outputFile = "output.png")
        {
            Console.Write("Rendering ... \r");


            var height = scene.Camera.Viewport.Height;
            var width = scene.Camera.Viewport.Width;

            Bitmap bitmap = new Bitmap(width, height);

            var start = DateTime.Now.Ticks;
            for (var i = 0; i < height; i++)
            {
                if (i % 10 == 0)
                {
                    var span = DateTime.Now.Ticks - start;
                    var secs = span / 1000;
                    var minutes = secs / 60;
                    var hours = minutes / 60;
                    minutes = minutes % 60;
                    secs = secs % 60;

                    var progress = (double)i / height * 100;

                    Console.Write($"Rendering {Math.Truncate(progress * 100) / 100}% [{hours}:{minutes}:{secs}.{span % 1000}]          \r");
                }
                for (var j = 0; j < width; j++)
                {
                    if (i == 430 && j == 240)
                    {
                        Console.Write("Derp \r");
                    }
                    var color = new Color();
                    for (var aai = 0; aai < Globals.ANTI_ALIASING; aai++)
                    {
                        for (var aaj = 0; aaj < Globals.ANTI_ALIASING; aaj++)
                        {
                            var ray = scene.Camera.WorldRay(i + (double) aai / Globals.ANTI_ALIASING, j + (double)aaj / Globals.ANTI_ALIASING);

                            color = color + scene.ComputeColor(ray);
                        }
                    }
                    var c = (color / (Globals.ANTI_ALIASING * Globals.ANTI_ALIASING)).ParseToInt();
                    bitmap.SetPixel(j, i, System.Drawing.Color.FromArgb(c.R, c.G, c.B));
                }
            }
            Console.WriteLine("\nRendering ... [Completed!]              ");

            bitmap.Save(outputFile, ImageFormat.Png);

            Process myProcess = new Process { StartInfo = { FileName = outputFile } };
            myProcess.Start();
        }
    }
}
