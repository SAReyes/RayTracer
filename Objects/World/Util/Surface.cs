namespace Objects.World.Util
{
    public class Surface
    {
        public Color Diffuse { get; set; }
        public double Reflection { get; set; }

        public override string ToString()
        {
            return $"Surface[Diffuse={Diffuse}, Reflection={Reflection}]";
        }
    }
}