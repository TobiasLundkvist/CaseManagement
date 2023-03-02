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
            Console.WriteLine("5. Ta bort en felanmälan");
            Console.WriteLine("6. Återgå till huvudmenyn");

            string answer = Console.ReadLine() ?? "";

            switch (answer)
            {
                case "1":
                    await errorReport.CreateErrorReportAsync();
                    break;

                case "2":
                    await errorReport.ListAllErrorReportsAsync();
                    break;

                case "3":
                    await errorReport.GetOneErrorReportAsync();
                    break;

                case "4":
                    await errorReport.UpdateErrorReportAsync();
                    break;

                case "5":
                    Console.WriteLine("Radera en");
                    break;

                default:
                    Console.WriteLine("Välj alternativ 1-6: ");
                    break;
            }
            if (answer == "6")
            {
                break;
            }
            Console.ReadKey();
        }
    }
}
