using CaseManagement.Models;

namespace CaseManagement.Services;

public class AddErrorReportService
{
    public async Task CreateErrorReportAsync()
    {
        var errorReport = new ErrorReportModel();
        Console.Clear();

        Console.WriteLine("Beskriv kort din felanmälan: ");
        errorReport.ErrorReportDescription = Console.ReadLine() ?? "";

        Console.WriteLine("Vänligen ange din bostadsförenings email: ");
        errorReport.Email = Console.ReadLine() ?? "";

        errorReport.ErrorReportStatus = "Ej påbörjad";

        await ErrorReportServiceDB.SaveErrorReportAsync(errorReport);
    }

    public async Task ListAllErrorReportsAsync()
    {
        var errorReports = await ErrorReportServiceDB.GetAllErrorReportsAsync();
        Console.Clear();

        if(errorReports != null)
        {
            foreach(var errorReport in errorReports)
            {
                Console.WriteLine($"Felanmälningsnummer: {errorReport.Id}");
                Console.WriteLine($"Datum för felanmälan: {errorReport.ErrorReportDate}");
                Console.WriteLine($"\nFelanmälan:\n{errorReport.ErrorReportDescription}\n");
                Console.WriteLine($"Återkoppla till hyresgäst senast: {errorReport.ErrorReportDueDate}");
                Console.WriteLine($"Status på felanmälan: {errorReport.ErrorReportStatus}");
                Console.WriteLine($"\nFelanmälan är gjord av: {errorReport.FirstName} {errorReport.LastName}");
                Console.WriteLine($"E-postadress: {errorReport.Email}");
                Console.WriteLine($"Mobilnummer: {errorReport.Phone}");
                Console.WriteLine("\n-----------------------------------------------------------------------------------------\n");
            }
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine("Just nu finns det inga felanmälningar i bostadsföreningen.");
        }
    }

    public async Task GetOneErrorReportAsync()
    {
        Console.Clear();
        Console.WriteLine("Ange Felanmälningsnumret: ");
        var answer = Console.ReadLine();
        int id;

        if (int.TryParse(answer, out id))
        {
            var errorReport = await ErrorReportServiceDB.GetErrorReportAsync(id);
            if (errorReport != null)
            {
                Console.WriteLine($"Felanmälningsnummer: {errorReport.Id}");
                Console.WriteLine($"Datum för felanmälan: {errorReport.ErrorReportDate}");
                Console.WriteLine($"\nFelanmälan:\n{errorReport.ErrorReportDescription}\n");
                Console.WriteLine($"Återkoppla till hyresgäst senast: {errorReport.ErrorReportDueDate}");
                Console.WriteLine($"Status på felanmälan: {errorReport.ErrorReportStatus}");
                Console.WriteLine($"\nFelanmälan är gjord av: {errorReport.FirstName} {errorReport.LastName}");
                Console.WriteLine($"E-postadress: {errorReport.Email}");
                Console.WriteLine($"Mobilnummer: {errorReport.Phone}");
                Console.WriteLine("\n-----------------------------------------------------------------------------------------\n");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Finns ingen felanmälan med felanmälningsnummer: {id}");
                Console.WriteLine("");
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Vänligen ange ett korrekt felanmälningsnummer.");
            Console.WriteLine("");
        }
    }

    public async Task UpdateErrorReportAsync()
    {
        Console.Clear();
        Console.WriteLine("Ange Felanmälningsnumret: ");
        var answer = Console.ReadLine();
        int id;

        if (int.TryParse(answer, out id))
        {
            var errorReport = await ErrorReportServiceDB.GetErrorReportAsync(id);

            Console.WriteLine("Ändra status på felanmälning (Pågående/Avslutad): ");
            errorReport.ErrorReportStatus = Console.ReadLine();

            await ErrorReportServiceDB.UpdateErrorReportAsync(errorReport);
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"Finns ingen felanmälan med felanmälningsnummer: {id}");
            Console.WriteLine("");
        }
        
    }
}
