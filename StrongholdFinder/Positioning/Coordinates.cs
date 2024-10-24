namespace StrongholdFinder.Positioning
{
    public abstract class Coordinates
    {
        public double X { get; set; }
        public double Z { get; set; }

        public Coordinates() { }

        public Coordinates(double x, double y)
        {
            X = x;
            Z = y;
        }

        public override string ToString()
        {
            return $"X {Math.Round(X)}, Z {Math.Round(Z)}";
        }
    }
}
