namespace CaseManagement.Services;

public class ErrorReportMenuService
{
    public void ErrorReportMenu()
    {
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
                    Console.WriteLine("skapa");
                    break;

                case "2":
                    Console.WriteLine("Visa alla");
                    break;

                case "3":
                    Console.WriteLine("Visa en");
                    break;

                case "4":
                    Console.WriteLine("Uppdatera en");
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
