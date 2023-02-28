using Spectre.Console;
using System;
using System.Threading.Tasks;

namespace PremierLeagueData
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            bool exit = false;
            
            AnsiConsole.Write(
                new FigletText("Football Data")
                    .Centered()
                    .Color(Color.Aqua));

            do
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Main Menu")
                        .AddChoices(new[] {
                            "League Standings", "Fixture Results", "Top Scorers",
                            "Top Assistors", "Exit",
                        }));

                switch (option)
                {
                    case "League Standings":
                        await ChooseLeague.PromptForLeagueStandings();
                        break;
                    case "Fixture Results":
                        try
                        {
                            await ChooseLeague.PromptForFixtureResults();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            //throw;
                        }
                        break;
                    case "Top Scorers":
                        await ChooseLeague.LeagueforTopScorers();
                        break;
                    case "Top Assistors":
                        await ChooseLeague.LeagueforTopAssistors();
                        break;
                    case "Exit":
                        exit = true;
                        break;
                }
            }
            while (!exit);
        }
    }
}
