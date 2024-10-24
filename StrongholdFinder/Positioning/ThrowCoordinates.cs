using StrongholdFinder.Utils;

namespace StrongholdFinder.Positioning
{
    public class ThrowCoordinates : Coordinates
    {
        public double XRotation { get; set; }
        public double Slope { get; set; }

        public ThrowCoordinates()
        {
            (X, Z, XRotation) = CoordinatesExtractor.GetCoordinatesFromClipboard();
            Slope = Math.Tan(-1 * XRotation * (Math.PI / 180));
        }

        public override string ToString()
        {
            return $"{base.ToString()}, XRotation {Math.Round(XRotation)}";
        }

        public string ToVerboseString()
        {
            return $"{this} Slope:{Math.Round(Slope)}";
        }
    }
}
