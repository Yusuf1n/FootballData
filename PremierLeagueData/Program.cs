using System;
using System.Threading.Tasks;

namespace PremierLeagueData
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("Football Data");
            //Console.WriteLine("Which League's standings would you like to see?");
            //Console.WriteLine("1. Premier League (England)");
            //Console.WriteLine("2. La Liga (Spain)");
            //Console.WriteLine("3. Serie A (Italy)");
            //Console.WriteLine("4. Bundesliga (Germany)");
            //Console.WriteLine("5. Ligue 1 (France)");
            //Console.WriteLine();
            //Console.Write("Please enter 1-5: ");
            //int league_ = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine();
            //await APIRequests.LeagueStandings(league_);
            //await APIRequests.TopScorers();
            //await APIRequests.TopAssistors();
            await APIRequests.Fixtures();
            Console.ReadLine();
        }
    }
}
