namespace Raytracer.World.Space
{
    public class Matrix
    {
        private readonly double[][] _matrix;

        public Matrix(int i, int j)
        {
            _matrix = new double[i][];
            for (int index = 0; index < i; index++)
            {
                _matrix[index] = new double[j];
            }
        }

        public Matrix() : this(4, 4) { }

        public Matrix(Vector x, Vector y, Vector z, Point h) : this(4, 4)
        {
            _matrix[0] = x.Array();
            _matrix[1] = y.Array();
            _matrix[2] = z.Array();
            _matrix[3] = h.Array();
        }

        public double[] this[int i]
        {
            get { return _matrix[i]; }
            set { _matrix[i] = value; }
        }
    }
}