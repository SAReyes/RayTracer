using Raytracer.World.Space;

namespace Raytracer.World.Util
{
    /// <summary>
    /// <para>
    /// An intersection, verify the property {Intersected} to
    /// see if an object's been intersected by a ray
    /// </para>
    /// <para>
    /// Use Intersection.None or the empty constructor to tell 
    /// there's been no intersection
    /// </para>
    /// </summary>
    public class Intersection
    {
        public Thing Thing { get; set; }
        public Ray Normal { get; set; }

        public bool Intersected => Thing != null && Normal != null;

        public override string ToString()
        {
            return $"Intersection[Intersected={Intersected}, Normal={Normal}, Thing={Thing}]";
        }

        public static Intersection None => new Intersection();
    }
}