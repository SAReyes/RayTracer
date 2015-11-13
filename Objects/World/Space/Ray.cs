namespace Objects.World.Space
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
            return $"Ray[Origin={Origin}, Direction={Direction}";
        }
    }
}