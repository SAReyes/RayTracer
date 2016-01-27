using Raytracer.World.Space;

namespace Raytracer.World
{
    public class Light
    {
        public Point Position { get; set; }
        public double Intensity { get; set; }

        public double IntensityFactor(Point point)
        {
            var distance = point.Distance(Position);
            return Intensity / (distance * distance + 1);
        }

    }
}