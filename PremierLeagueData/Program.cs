using System;
using System.Threading.Tasks;

namespace PremierLeagueData
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            bool exit = false;

            do
            {
                Console.WriteLine("Football Data - Main Menu");
                Console.WriteLine("1. League Standings");
                Console.WriteLine("2. Fixture Results");
                Console.WriteLine("3. Top Scorers");
                Console.WriteLine("4. Top Assistors");
                Console.WriteLine("5. Exit");
                Console.WriteLine();
                Console.Write("Please enter your option between 1-5: ");
                int option = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (option)
                {
                    case 1:
                        await ChooseLeague.LeagueforLeagueStandings();
                        break;
                    case 2:
                        await ChooseLeague.LeagueAndGWforFixtureResults();
                        break;
                    case 3:
                        await ChooseLeague.LeagueforTopScorers();
                        break;
                    case 4:
                        await ChooseLeague.LeagueforTopAssistors();
                        break;
                    case 5:
                        exit = true;
                        break;
                }
            }
            while (!exit);
        }
    }
}
