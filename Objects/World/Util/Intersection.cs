using Objects.World.Space;

namespace Objects.World.Util
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
        public Ray Ray { get; set; }

        public bool Intersected => Thing != null && Ray != null;

        public override string ToString()
        {
            return $"Intersection[Intersected={Intersected}, Ray={Ray}, Thing={Thing}]";
        }

        public static Intersection None { get { return new Intersection(); } }
    }
}