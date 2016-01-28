using Raytracer.World.Space;

namespace Raytracer.World.Util
{
    public abstract class Thing
    {
        public Surface Surface { get; set; }

        public abstract bool Intersected(Ray ray, out Intersection intersection);
    }
}