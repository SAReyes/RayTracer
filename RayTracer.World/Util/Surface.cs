using System;

namespace Raytracer.World.Util
{
    public class Surface
    {
        public Color Color { get; set; }

        public double SpecularN { get; set; }
        public double SpecularCoef { get; set; }

        public double RefractiveIndex { get; set; }
        public double ReflectanceIndex { get; set; }

        public bool Delta => Math.Abs(ReflectanceIndex) > Globals.EPSILON || Math.Abs(RefractiveIndex) > Globals.EPSILON;
        

        public override string ToString()
        {
            return $"Surface[Diffuse={Color}, Reflection={ReflectanceIndex}]";
        }
    }
}