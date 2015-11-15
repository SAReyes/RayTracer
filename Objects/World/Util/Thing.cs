using Objects.World.Space;

namespace Objects.World.Util
{
    public abstract class Thing
    {
        public Surface Surface { get; set; }

        public abstract Intersection Intersected(Ray ray);
    }
}