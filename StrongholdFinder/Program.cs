using StrongholdFinder.Calculations;
using StrongholdFinder.Positioning;

namespace StrongholdFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.CursorVisible = false;

            Console.WriteLine("""
                ____  _                         _           _     _ _____ _           _           
               / ___|| |_ _ __ ___  _ __   __ _| |__   ___ | | __| |  ___(_)_ __   __| | ___ _ __ 
               \___ \| __| '__/ _ \| '_ \ / _` | '_ \ / _ \| |/ _` | |_  | | '_ \ / _` |/ _ \ '__|
                ___) | |_| | | (_) | | | | (_| | | | | (_) | | (_| |  _| | | | | | (_| |  __/ |   
               |____/ \__|_|  \___/|_| |_|\__, |_| |_|\___/|_|\__,_|_|   |_|_| |_|\__,_|\___|_|   
                                          |___/                                                                                                                               
            >> Enter your coordinates by pressing "F3 + C" in the direction of the launched Ender Eye <<
            """);

            Coordinates start = new();
            Coordinates end = new();
            var distance = StrongholdLocator.CalculateDistance(start, end);

            Console.WriteLine();
            Console.WriteLine($">> Approximate distance: {distance} blocks <<");
            Console.ReadKey();
        }
    }
}
