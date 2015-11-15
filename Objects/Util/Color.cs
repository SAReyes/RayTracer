namespace Raytracer.World.Util
{
    public class Color
    {
        public double R { get; set; }
        public double G { get; set; }
        public double B { get; set; }

        public Color()
        {
        }

        public Color(double r, double g, double b)
        {
            R = r;
            G = g;
            B = b;
        }

        public static Color operator +(Color r1, Color r2)
        {
            return new Color(r1.R + r2.R, r1.G + r2.G, r1.B + r2.B);
        }

        public static Color operator -(Color r1, Color r2)
        {
            return new Color(r1.R - r2.R, r1.G - r2.G, r1.B - r2.B);
        }

        public override string ToString()
        {
            return $"Color[R={R}, G={G}, B={B}]";
        }
    }
}