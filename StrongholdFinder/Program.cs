using StrongholdFinder.Positioning;

namespace StrongholdFinder
{
    internal class Program
    {
        private const int WINDOW_SIZE_X = 92;
        private const int WINDOW_SIZE_Y = 15;

        private static void DisplayMenu()
        {
            Console.Clear();
            Console.SetWindowSize(1, 1);
            Console.SetWindowSize(WINDOW_SIZE_X, WINDOW_SIZE_Y);
            Console.Title = "StrongholdFinder";
            Console.CursorVisible = false;

            if (OperatingSystem.IsWindows())
            {
                Console.SetBufferSize(WINDOW_SIZE_X, WINDOW_SIZE_Y);
            }

            Console.WriteLine("""
                ____  _                         _           _     _ _____ _           _           
               / ___|| |_ _ __ ___  _ __   __ _| |__   ___ | | __| |  ___(_)_ __   __| | ___ _ __ 
               \___ \| __| '__/ _ \| '_ \ / _` | '_ \ / _ \| |/ _` | |_  | | '_ \ / _` |/ _ \ '__|
                ___) | |_| | | (_) | | | | (_| | | | | (_) | | (_| |  _| | | | | | (_| |  __/ |   
               |____/ \__|_|  \___/|_| |_|\__, |_| |_|\___/|_|\__,_|_|   |_|_| |_|\__,_|\___|_|   
                                          |___/                                                                                                                               
            >> Enter your coordinates by pressing "F3 + C" in the direction of the launched Ender Eye <<
            """);
        }

        private static ThrowCoordinates CreateAndDisplayThrowCoordinates(int position)
        {
            ThrowCoordinates throwCoordinates = new();
            Console.WriteLine($"{position}st throw: {throwCoordinates}");
            return throwCoordinates;
        }

        private static void Main(string[] args)
        {
            DisplayMenu();

            var throw1 = CreateAndDisplayThrowCoordinates(position: 1);
            var throw2 = CreateAndDisplayThrowCoordinates(position: 2);
            StrongholdCoordinates strongholdCoordinates = new(throw1, throw2);

            Console.WriteLine();
            if (!strongholdCoordinates.AreAccurate())
            {
                Console.WriteLine("Warning: The angle difference is too small, accuracy may be compromised");
            }

            Console.WriteLine($"Stronghold Coordinates: {strongholdCoordinates}");
            Console.WriteLine($"Distance: {strongholdCoordinates.GetPlayerDistance()} blocks");
            Console.ReadKey();
        }
    }
}
