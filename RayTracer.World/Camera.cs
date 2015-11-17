using Raytracer.World.Space;

namespace Raytracer.World
{
    public class Camera
    {
        public Point Position { get; set; }
        public double F { get; set; }
        public Viewport Viewport { get; set; }

        public Vector U { get; }
        public Vector V { get; }
        public Vector W { get; }

        public Camera(Point position, double f, Viewport viewport, Vector g) : this(position, g)
        {
            F = f;
            Viewport = viewport;
        }

        public Camera(Point position, Vector g)
        {
            F = 100;
            Viewport = new Viewport(800, 600);

            Position = position;

            W = -g.Normalize();

            var Up = new Vector(0, 1, 0);

            U = Up.Cross(W).Normalize();
            V = W.Cross(U);
        }

        public override string ToString()
        {
            return $"Camera=[Position={Position}, Viewport={Viewport}, F={F}, U={U}, V={V}, W={W}]";
        }
        
    }
}