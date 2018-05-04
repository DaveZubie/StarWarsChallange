using StarWarsChallenge;
using System;
using System.Collections.Generic;

namespace StarWarsConsole
{
    public class UiDisplay
    {
        /// <summary>
        /// Validate the distance entered by the user
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool ValidateDistance(string distance)
        {
            double actualDistance = 0;

            bool validDistance = double.TryParse(distance, out actualDistance);

            if (!validDistance)
            {
                var errorMessage = ErrorHandler.ReturnErrorDescription(Constants.invalidDistance);
                WriteLine(errorMessage);
                PressAnyKeyToContinue();
            }
            return validDistance;
        }

        /// <summary>
        /// Display processed information to screen 
        /// </summary>
        /// <param name="validShips"></param>
        /// <param name="invalidShips"></param>
        public static void DisplayResults(List<string> validShips, List<string> invalidShips)
        {
            // Printout the ships who can and cannot make the journey
            PrintShipManifest(validShips, true);
            BlankLine();
            PrintShipManifest(invalidShips, false);

            BlankLine();
            PressAnyKeyToContinue();
        }

        /// <summary>
        /// Print the list of ships to screen
        /// </summary>
        /// <param name="ships">List of Ships to display</param>
        /// <param name="validJumps">This will display the correct header for the display</param>
        private static void PrintShipManifest(List<string> ships, bool validJumps)
        {
            WriteLine("*****************************************************");
            var headerMessage = validJumps ? Constants.validJumpsHeader : Constants.invalidJumpsHeader;

            WriteLine(headerMessage);

            foreach (string ship in ships)
                WriteLine(ship);
        }

        /// <summary>
        /// UI Displays
        /// </summary>
        public static void DisplayWelcomeMessage()
        {
            WriteLine("*****************************************************");
            WriteLine("Welcome Commander.");
            BlankLine();
        }

        public static string DisplayReadyMessage()
        {
            WriteLine("*****************************************************");
            WriteLine("To disconnect type X");
            BlankLine();
            WriteLine("How many MGLT would you like to travel?");
            return ReadLine();
        }

        public static void DisplayErrorMessage(string message)
        {
            WriteLine("*****************************************************");
            WriteLine(string.Format("{0}{1}", Constants.defaultErrorMessage, message));
            BlankLine();
            WriteLine("*****************************************************");
        }

        public static void DisplayAccessingData()
        {
            WriteLine("*****************************************************");
            WriteLine("We are accessing the primary Ships Datacore on Naboo.");
            BlankLine();
        }

        public static void DisplayProcessingInformation()
        {
            WriteLine("*****************************************************");
            WriteLine("Processing information.");
            BlankLine();
        }

        /// <summary>
        /// Utility methods
        /// </summary>
        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public static string ReadLine()
        {
            return Console.ReadLine();
        }

        public static void ReadKey()
        {
            Console.ReadKey();
        }

        public static void PressAnyKeyToContinue()
        {
            WriteLine("Press any key to continue.");
            ReadKey();
        }

        private static void BlankLine()
        {
            WriteLine("");
        }
        
    }
}
