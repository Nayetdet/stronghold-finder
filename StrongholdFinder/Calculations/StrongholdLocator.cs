using StrongholdFinder.Positioning;

namespace StrongholdFinder.Calculations
{
    public static class StrongholdLocator
    {
        private static double CalculateSlope(double xRotation)
        {
            var angle = -1 * xRotation * (Math.PI / 180);
            return Math.Tan(angle);
        }

        public static int CalculateDistance(Coordinates start, Coordinates end)
        {
            var slopeStart = CalculateSlope(start.XRotation);
            var slopeEnd = CalculateSlope(end.XRotation);

            var strongholdZ = (start.Z * slopeStart - end.Z * slopeEnd + end.X - start.X) / (slopeStart - slopeEnd);
            var strongholdX = (strongholdZ - start.Z) * slopeStart + start.X;
            var distance = Math.Sqrt(Math.Pow(strongholdX - end.X, 2) + Math.Pow(strongholdZ - end.Z, 2));

            return (int)Math.Round(distance);
        }
    }
}
