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

        public IntColor ParseToInt()
        {
            return new IntColor
            {
                R = R > 1 ? 255 : R < 0 ? 0 : (int)(R * 255),
                G = G > 1 ? 255 : G < 0 ? 0 : (int)(G * 255),
                B = B > 1 ? 255 : B < 0 ? 0 : (int)(B * 255)
            };
        }

        public static Color operator *(Color r, double d)
        {
            return new Color(r.R * d, r.G * d, r.B * d);
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

        public class IntColor
        {
            public int R { get; set; }
            public int G { get; set; }
            public int B { get; set; }
        }
    }
}