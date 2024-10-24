using System.Text.RegularExpressions;

namespace StrongholdFinder.Utils
{
    internal static partial class CoordinatesValidator
    {
        [GeneratedRegex(
            @"^\/execute in minecraft:overworld run tp @s (-?\d+\.\d{2}(?:\s-?\d+\.\d{2}){4})$",
            RegexOptions.Compiled
        )]

        public static partial Regex Regex();
    }
}
