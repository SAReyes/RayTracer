using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
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

            var start = DateTime.Now;
            for (var i = 0; i < height; i++)
            {
                if (i % 10 == 0)
                {
                    var span = DateTime.Now - start;

                    var progress = (double)i / height * 100;

                    Console.Write($"Rendering {Math.Truncate(progress * 100) / 100}% [{span.Hours}:{span.Minutes}:{span.Seconds}.{span.Milliseconds}]          \r");
                }
                for (var j = 0; j < width; j++)
                {
                    // Anti-aliasing por supermuestreo
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
            var finished = DateTime.Now - start;
            Console.WriteLine("Rendering ... [Completed!]              ");

            bitmap.Save(outputFile, ImageFormat.Png);

            Process myProcess = new Process { StartInfo = { FileName = outputFile } };
            myProcess.Start();
            
            Console.WriteLine($"Time expended: [{finished.Hours}:{finished.Minutes}:{finished.Seconds}.{finished.Milliseconds}]");
            Console.ReadLine();
        }
    }
}
