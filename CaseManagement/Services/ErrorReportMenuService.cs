namespace CaseManagement.Services;

public class ErrorReportMenuService
{
    public async Task ErrorReportMenu()
    {
        var errorReport = new AddErrorReportService();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Skapa en felanmälan ");
            Console.WriteLine("2. Visa alla felanmälningar ");
            Console.WriteLine("3. Visa en felanmälan ");
            Console.WriteLine("4. Ändra status på felanmälan ");
            Console.WriteLine("5. Återgå till huvudmenyn");

            string answer = Console.ReadLine() ?? "";

            switch (answer)
            {
                case "1":
                    Console.Clear();
                    await errorReport.CreateErrorReportAsync();
                    Console.WriteLine("Tryck på valfri knapp för att fortsätta...");
                    break;

                case "2":
                    Console.Clear();
                    await errorReport.ListAllErrorReportsAsync();
                    Console.WriteLine("Tryck på valfri knapp för att fortsätta...");
                    break;

                case "3":
                    Console.Clear();
                    await errorReport.GetOneErrorReportAsync();
                    Console.WriteLine("Tryck på valfri knapp för att fortsätta...");
                    break;

                case "4":
                    Console.Clear();
                    await errorReport.UpdateErrorReportAsync();
                    Console.WriteLine("Tryck på valfri knapp för att fortsätta...");
                    break;

                default:
                    Console.WriteLine("Välj alternativ 1-5: ");
                    Console.WriteLine("Tryck på valfri knapp för att fortsätta...");
                    break;
            }
            if (answer == "5")
            {
                break;
            }
            Console.ReadKey();
        }
    }
}
