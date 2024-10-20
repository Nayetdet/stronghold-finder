using System.Text.RegularExpressions;
using TextCopy;

namespace StrongholdFinder.Positioning
{
    public class Coordinates
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double XRotation { get; set; }
        public double YRotation { get; set; }

        public Coordinates()
        {
            GetUserCoordinates();
        }

        private void GetUserCoordinates()
        {
            Match match;
            ClipboardService.SetText(string.Empty);

            do
            {
                string clipboardText = ClipboardService.GetText() ?? string.Empty;
                match = CoordinatesValidator.Regex().Match(clipboardText);
                Thread.Sleep(250);
            } while (!match.Success);

            var rawCoordinates = match.Groups[1].Value;
            var coordinates = rawCoordinates.Split(' ').Select(x => double.Parse(x)).ToArray();
            Console.WriteLine($"Coordinates: {rawCoordinates}");

            X = coordinates[0];
            Y = coordinates[1];
            Z = coordinates[2];
            XRotation = coordinates[3];
            YRotation = coordinates[4];
        }
    }
}
