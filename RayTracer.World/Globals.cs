using Raytracer.World.Util;

namespace Raytracer.World
{
    public class Globals
    {
        public static double EPSILON = 0.02;
        public static int MAX_RECURSION = 10;
        public static Color WORLD_COLOR = new Color(0.2, 0.2, 0.2);
        public static double AMB_COEF = 0.3;
        public static Color LIGHT_COLOR = new Color(1, 1, 1);
        public static int ANTI_ALIASING = 1;
    }
}