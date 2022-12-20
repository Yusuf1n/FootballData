using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeagueData
{
    public class ChooseLeague
    {
        static bool exit = false;

        public static async Task LeagueforLeagueStandings()
        {
            do
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Which Leagues standings would you like to see?")
                        .AddChoices(new[] {
                            "Premier League (England)", "La Liga (Spain)", "Serie A (Italy)",
                            "Bundesliga (Germany)", "Ligue 1 (France)", "Exit",
                        }));

                switch (option)
                {
                    case "Premier League (England)":
                        await APIRequests.LeagueStandings("Premier League");
                        break;
                    
                    case "La Liga (Spain)":
                        await APIRequests.LeagueStandings("La Liga");
                        break;
                    
                    case "Serie A (Italy)":
                        await APIRequests.LeagueStandings("Serie A");
                        break;
                    
                    case "Bundesliga (Germany)":
                        await APIRequests.LeagueStandings("Bundesliga");
                        break;
                    
                    case "Ligue 1 (France)":
                        await APIRequests.LeagueStandings("Ligue 1");
                        break;
                    
                    case "Exit":
                        exit = true;
                        break;
                }
            }
            while (!exit);

            //Console.WriteLine("Which Leagues standings would you like to see?");
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
        }

        public static async Task LeagueAndGWforFixtureResults()
        {
            int gameweek;
            
            do
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Which Leagues Fixture Results would you like to see?")
                        .AddChoices(new[] {
                            "Premier League (England)", "La Liga (Spain)", "Serie A (Italy)",
                            "Bundesliga (Germany)", "Ligue 1 (France)", "Exit",
                        }));

                switch (option)
                {
                    case "Premier League (England)":
                        Console.WriteLine("Which Gameweeks Fixture Results would you like to see?");
                        Console.Write("Gameweek: ");
                        gameweek = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        await APIRequests.FixtureResults("Premier League", gameweek);
                        break;
                    
                    case "La Liga (Spain)":
                        Console.WriteLine("Which Gameweeks Fixture Results would you like to see?");
                        Console.Write("Gameweek: ");
                        gameweek = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        await APIRequests.FixtureResults("La Liga", gameweek);
                        break;
                    
                    case "Serie A (Italy)":
                        Console.WriteLine("Which Gameweeks Fixture Results would you like to see?");
                        Console.Write("Gameweek: ");
                        gameweek = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        await APIRequests.FixtureResults("Serie A", gameweek);
                        break;
                    case "Bundesliga (Germany)":
                        Console.WriteLine("Which Gameweeks Fixture Results would you like to see?");
                        Console.Write("Gameweek: ");
                        gameweek = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        await APIRequests.FixtureResults("Bundesliga", gameweek);
                        break;
                    
                    case "Ligue 1 (France)":
                        Console.WriteLine("Which Gameweeks Fixture Results would you like to see?");
                        Console.Write("Gameweek: ");
                        gameweek = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        await APIRequests.FixtureResults("Ligue 1", gameweek);
                        break;
                    
                    case "Exit":
                        exit = true;
                        break;
                }
            }
            while (!exit);
            
            // Console.WriteLine("Which Leagues Fixture Results would you like to see?");
            // Console.WriteLine("1. Premier League (England)");
            // Console.WriteLine("2. La Liga (Spain)");
            // Console.WriteLine("3. Serie A (Italy)");
            // Console.WriteLine("4. Bundesliga (Germany)");
            // Console.WriteLine("5. Ligue 1 (France)");
            // Console.WriteLine();
            // Console.Write("Please enter 1-5: ");
            // int league_ = Convert.ToInt32(Console.ReadLine());
            // Console.WriteLine();

            // Console.WriteLine("Which Gameweeks Fixture Results would you like to see?");
            // Console.Write("Gameweek: ");
            // int gameweek = Convert.ToInt32(Console.ReadLine());
            // Console.WriteLine();
            // await APIRequests.FixtureResults(league_, gameweek);
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
