using StarWarsChallenge;
using System.Collections.Generic;
using StarWarsConsole;

namespace ConsoleApp1
{
    /// <summary>
    /// This is the main console application
    /// It will display a welcome message and accept the distance you wish to travel. 
    /// Calculations for all ships will be displayed. 
    /// Ships will be divided into two categories 
    /// 1) Ships where we have the required information (i.e. MGLT and Consumables are known) 
    /// 2) All other ships which are missing some piece of information.
    /// </summary>
    class Program
    {
        static ShipsProcess shipsProcess;

        static void Main(string[] args)
        {
            var exitProgram = false;

            shipsProcess = new ShipsProcess();

            UiDisplay.DisplayWelcomeMessage();
            
            do
            {
                var response = UiDisplay.DisplayReadyMessage();

                if (response.ToLower() == "x")
                {
                    exitProgram = true;
                }
                else
                {
                    if (UiDisplay.ValidateDistance(response))
                    {
                        UiDisplay.DisplayAccessingData();
                        // Load all ships
                        List<Ship> ships = shipsProcess.ReadAllShips();

                        UiDisplay.DisplayProcessingInformation();
                        // Calculate Jumps
                        shipsProcess.CalculateJumps(ships, double.Parse(response));
                    }
                }
            } while (!exitProgram);
        }
    }
}
