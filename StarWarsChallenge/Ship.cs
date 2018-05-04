using System;

namespace StarWarsChallenge
{
    public class Ship
    {
        public string Name { get; set; }
        public double Mglt { get; set; }
        public double Consumables { get; set; }
        public bool ValidJump { get; set; }

        public Ship()
        {

        }

        public Ship(string name, string MGLT, string consumables)
        {
            var result = double.TryParse(MGLT, out double mglt);

            Name = name;
            Mglt = mglt;
            Consumables = hoursTillResupply(consumables);
        }

        /// <summary>
        /// This method will return the hours till resupply
        /// Assumption made that a standard month is 30 days
        /// </summary>
        /// <param name="consumables">
        /// Consumables is the amount of time before resupply
        /// It is formatted in hours, days, weeks, months, years
        /// </param>
        /// <returns>
        /// total consumables in hours
        /// </returns>
        private int hoursTillResupply(string consumables)
        {
            if (consumables.ToLower() == "unknown") return 0;

            string[] parts = consumables.Split(' ');
            if (parts.Length > 1)
            {
                int time = 0;
                int hours = 0;
                var result = int.TryParse(parts[0], out time);
                var period = parts[1].ToLower();

                if (time > 0)
                {
                    switch (period)
                    {
                        case "year":
                        case "years":
                            hours = time * Constants.daysInYear * Constants.hoursInDay;
                            break;

                        case "month":
                        case "months":
                            hours = time * Constants.daysInMonth * Constants.hoursInDay;
                            break;

                        case "week":
                        case "weeks":
                            hours = time * Constants.daysInWeek * Constants.hoursInDay;
                            break;

                        case "day":
                        case "days":
                            hours = time * Constants.hoursInDay;
                            break;

                        case "hour":
                        case "hours":
                            hours = time;
                            break;

                        default:
                            hours = 0;
                            break;
                    }
                }
  
                return hours;
            }
            else return 0;
        }

        /// <summary>
        /// Calculate the number of stops for resupply required based on the distance the ship will travel.
        /// Sets ValidJump to false if the ship cannot make the jump due to limited range or incomplete information
        /// </summary>
        /// <param name="distance">MGLT the shis is going to travel</param>
        /// <returns>
        /// Number of resupply stops.
        /// </returns>
        public int ResuppliesRequired(double distance)
        {
            var jumps = 0;
            ValidJump = true;

            // Check - if MGLT or Consumables are 0 then this jump is not possible
            if (Mglt == 0 || Consumables == 0)
            {
                ValidJump = false;
                return -1;
            }

            double hoursToDestination = distance / Mglt;
            jumps = (int)(hoursToDestination / Consumables);

            // If the ship jumps exactly to it's consumable limit it will resupply at destination 
            // therefore 1 less jump than calculated
            if (Math.IEEERemainder(hoursToDestination, Consumables) == 0) { jumps--; }
            return jumps;
        }
    }
}
