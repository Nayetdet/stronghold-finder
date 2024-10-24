namespace StrongholdFinder.Positioning
{
    public class StrongholdCoordinates : Coordinates
    {
        public readonly ThrowCoordinates Throw1;
        public readonly ThrowCoordinates Throw2;

        public StrongholdCoordinates(ThrowCoordinates throw1, ThrowCoordinates throw2)
        {
            Throw1 = throw1;
            Throw2 = throw2;

            Z = ((Throw1.Z * Throw1.Slope) - (Throw2.Z * Throw2.Slope) + (Throw2.X - Throw1.X)) / (Throw1.Slope - Throw2.Slope);
            X = ((Z - Throw1.Z) * Throw1.Slope) + Throw1.X;
        }

        public bool AreAccurate()
        {
            return Math.Abs(Throw1.XRotation - Throw2.XRotation) > 5;
        }

        public int GetPlayerDistance()
        {
            var deltaX = X - Throw2.X;
            var deltaZ = Z - Throw2.Z;

            var distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaZ, 2));
            return (int)distance;
        }
    }
}
