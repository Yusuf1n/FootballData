using System;
using System.Threading.Tasks;

namespace PremierLeagueData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Football Data - Main Menu");
            Console.WriteLine("1. League Standings");
            Console.WriteLine("2. Fixture Results");
            Console.WriteLine("3. Top Scorers");
            Console.WriteLine("4. Top Assistors");
            Console.WriteLine();
            Console.Write("Please enter your option between 1-4: ");
            int option = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (option)
            {
                case 1:
                    LeagueforLeagueStandings();
                    break;
                case 2:
                    LeagueAndGWforFixtureResults();
                    break;
                case 3:
                    LeagueforTopScorers();
                    break;
                case 4:
                    LeagueforTopAssistors();
                    break;
            }
            
            //await APIRequests.TopScorers();
            //await APIRequests.TopAssistors();
            //await APIRequests.Fixtures();
            Console.ReadLine();
        }

        static async Task LeagueforLeagueStandings()
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

        static async Task LeagueAndGWforFixtureResults()
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

        static async Task LeagueforTopScorers()
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

        static async Task LeagueforTopAssistors()
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
