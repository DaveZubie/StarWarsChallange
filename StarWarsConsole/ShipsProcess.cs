using Newtonsoft.Json.Linq;
using StarWarsChallenge;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsConsole
{
    class ShipsProcess
    {
        /// <summary>
        /// Connect to the API and read all ships
        /// </summary>
        /// <returns>List of all ships we will process</returns>
        public List<Ship> ReadAllShips()
        {
            var api = new ApiHandler();

            string next = null;
            List<Ship> ships = new List<Ship>();

            do
            {
                var url = string.IsNullOrEmpty(next) ? string.Format("{0}{1}", Constants.starWarsApi, "/starships") : next;
                var json = api.APIReader(url);

                if (api.Error)
                {
                    // If there was an error display message and exit 
                    UiDisplay.DisplayErrorMessage(json);
                    ships = null;
                    next = null;
                }
                else
                {
                    JObject response = JObject.Parse(json);
                    next = String.IsNullOrEmpty(response["next"].ToString()) ? null : response["next"].ToString();
                    JArray shipsArray = (JArray)response["results"];

                    ProcessShipArray(shipsArray, ships);
                }
            }
            while (next != null);

            return ships;
        }

        /// <summary>
        /// Processes the Results of the API call 
        /// </summary>
        /// <param name="shipList">Ships from API</param>
        /// <param name="ships">Ships we will be adding to</param>
        private void ProcessShipArray(JArray shipList, List<Ship> ships)
        {
            foreach (dynamic ship in shipList)
            {
                ships.Add(
                    new Ship(
                        ship["name"].Value,
                        ship["MGLT"].Value,
                        ship["consumables"].Value)
                );
            }
        }

        /// <summary>
        /// Calculate the number of jumps required to reach the destination
        /// </summary>
        /// <param name="ships">List of ships to Process</param>
        /// <param name="distance">distance that will be travelled</param>
        public void CalculateJumps(List<Ship> ships, double distance)
        {
            List<string> validShips = new List<string>();
            List<string> invalidShips = new List<string>();

            foreach (Ship ship in ships)
            {
                var resupplysNeeded = ship.ResuppliesRequired(distance);

                if (ship.ValidJump)
                    validShips.Add(string.Format("{0}{1}{2}", ship.Name, ": ", resupplysNeeded));
                else
                    invalidShips.Add(ship.Name);
            }

            UiDisplay.DisplayResults(validShips, invalidShips);
        }
    }
}
