using System;
using System.Threading.Tasks;

namespace PremierLeagueData
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await APIRequests.LeagueStandings();
            Console.ReadLine();
        }
    }
}
