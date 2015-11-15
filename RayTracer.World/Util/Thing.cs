using Raytracer.World.Space;

namespace Raytracer.World.Util
{
    public abstract class Thing
    {
        public Surface Surface { get; set; }

        public abstract Intersection Intersected(Ray ray);
    }
}