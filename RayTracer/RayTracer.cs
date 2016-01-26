using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raytracer.World;

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

                    Console.Write($"Rendering ... [{hours}:{minutes}:{secs}] {(double)i / height * 100}\r");
                }
                for (var j = 0; j < width; j++)
                {
                    var ray = scene.Camera.WorldRay(i, j);
                    if (i == 250 & j == 400)
                    {
                        Console.Write("derp \r");
                    }
                    var c = scene.ComputeColor(ray).ParseToInt();

                    bitmap.SetPixel(j, i, Color.FromArgb(c.R, c.G, c.B));
                }
            }
            Console.WriteLine("\nRendering ... [Completed!]              ");

            bitmap.Save(outputFile, ImageFormat.Png);

            Process myProcess = new Process {StartInfo = {FileName = outputFile}};
            myProcess.Start();
        }
    }
}
