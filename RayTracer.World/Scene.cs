using System.Collections.Generic;
using Raytracer.World.Util;

namespace Raytracer.World
{
    public class Scene
    {
        public IList<Light> Lights { get; set; }
        public IList<Thing> Objects { get; set; } 
        public Camera Camera { get; set; }
    }
}