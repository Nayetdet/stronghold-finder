using System.Text.RegularExpressions;
using System.Globalization;
using TextCopy;

namespace StrongholdFinder.Utils
{
    internal static class CoordinatesExtractor
    {
        private static string GetRawCoordinatesFromClipboard()
        {
            var match = Match.Empty;
            var lastClipboardText = ClipboardService.GetText();

            while (!match.Success)
            {
                var clipboardText = ClipboardService.GetText() ?? string.Empty;
                if (!clipboardText.Equals(lastClipboardText))
                {
                    lastClipboardText = clipboardText;
                    match = CoordinatesValidator.Regex().Match(clipboardText);
                }

                Thread.Sleep(250);
            }

            return match.Groups[1].Value;
        }

        public static (double x, double z, double xRotation) GetCoordinatesFromClipboard()
        {
            var coordinates = GetRawCoordinatesFromClipboard()
                .Split(' ')
                .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
                .ToArray();

            return (coordinates[0], coordinates[2], coordinates[3]);
        }
    }
}
