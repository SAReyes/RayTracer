namespace Raytracer.World.Space
{
    public class Ray
    {
        public Point Origin { get; set; }

        private Vector _direction;
        public Vector Direction
        {
            get { return _direction; }
            set { _direction = value.Normalize(); }
        }

        public Ray Transform(Matrix tm)
        {
            return new Ray
            {
                Direction = Direction.Transform(tm),
                Origin = Origin.Transform(tm)
            };
        }

        public Point Point(double scalar)
        {
            return new Point
            {
                X = Origin.X + Direction.X * scalar,
                Y = Origin.Y + Direction.Y * scalar,
                Z = Origin.Z + Direction.Z * scalar
            };
        }

        public override string ToString()
        {
            return $"Ray[Origin={Origin}, Direction={Direction}]";
        }
    }
}