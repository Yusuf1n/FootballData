using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeagueData
{
    public class ChooseLeague
    {
        public static async Task LeagueforLeagueStandings()
        {
            Console.WriteLine("Which Leagues standings would you like to see?");
            Console.WriteLine("1. Premier League (England)");
            Console.WriteLine("2. La Liga (Spain)");
            Console.WriteLine("3. Serie A (Italy)");
            Console.WriteLine("4. Bundesliga (Germany)");
            Console.WriteLine("5. Ligue 1 (France)");
            Console.WriteLine();
            Console.Write("Please enter 1-5: ");
            int league_ = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            await APIRequests.LeagueStandings(league_);
        }

        public static async Task LeagueAndGWforFixtureResults()
        {
            Console.WriteLine("Which Leagues Fixture Results would you like to see?");
            Console.WriteLine("1. Premier League (England)");
            Console.WriteLine("2. La Liga (Spain)");
            Console.WriteLine("3. Serie A (Italy)");
            Console.WriteLine("4. Bundesliga (Germany)");
            Console.WriteLine("5. Ligue 1 (France)");
            Console.WriteLine();
            Console.Write("Please enter 1-5: ");
            int league_ = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Which Gameweeks Fixture Results would you like to see?");
            Console.Write("Gameweek: ");
            int gameweek = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            await APIRequests.FixtureResults(league_, gameweek);
        }

        public static async Task LeagueforTopScorers()
        {
            Console.WriteLine("Which Leagues Top Scorers would you like to see?");
            Console.WriteLine("1. Premier League (England)");
            Console.WriteLine("2. La Liga (Spain)");
            Console.WriteLine("3. Serie A (Italy)");
            Console.WriteLine("4. Bundesliga (Germany)");
            Console.WriteLine("5. Ligue 1 (France)");
            Console.WriteLine();
            Console.Write("Please enter 1-5: ");
            int league_ = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            await APIRequests.TopScorers(league_);
        }

        public static async Task LeagueforTopAssistors()
        {
            Console.WriteLine("Which Leagues Top Assistors would you like to see?");
            Console.WriteLine("1. Premier League (England)");
            Console.WriteLine("2. La Liga (Spain)");
            Console.WriteLine("3. Serie A (Italy)");
            Console.WriteLine("4. Bundesliga (Germany)");
            Console.WriteLine("5. Ligue 1 (France)");
            Console.WriteLine();
            Console.Write("Please enter 1-5: ");
            int league_ = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            await APIRequests.TopAssistors(league_);
        }
    }
}
