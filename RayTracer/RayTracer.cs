using System.Drawing;
using Raytracer.World;

namespace RayTracer
{
    public class RayTracer
    {
        public static void Trace(Scene scene)
        {
            var img = new Bitmap(scene.Camera.Viewport.Width, scene.Camera.Viewport.Height);

            img.SetPixel(0,0,Color.FromArgb(1,2,3));
        }
    }
}