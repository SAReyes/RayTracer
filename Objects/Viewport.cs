namespace Raytracer.World
{
    public class Viewport
    {
        public int Width { get; set; } 
        public int Height { get; set; }

        public Viewport(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"Viewport=[Width={Width}, Height={Height}]";
        }
    }
}