using CaseManagement.Models;

namespace CaseManagement.Services;

public class AddErrorCommentService
{
    public async Task CreateErrorCommentAsync()
    {
        var errorReportComment = new ErrorReportCommentModel();
        Console.Clear();

        Console.Write("Ange Felanmälningsnummer: ");
        var answer = Console.ReadLine();
        int id; 

        if(int.TryParse(answer, out id))
        {
            errorReportComment.Id = id;

            Console.WriteLine("Din kommentar på felanmälan: ");
            errorReportComment.ErrorReportDescription = Console.ReadLine() ?? "";
        }

        await ErrorCommentServiceDB.SaveErrorCommentAsync(errorReportComment);
    }

    public async Task ListAllErrorCommentsAsync()
    {
        var errorReportComments = await ErrorCommentServiceDB.GetAllErrorReportswithComments();
        Console.Clear();

        if(errorReportComments != null)
        {
            foreach(var errorReportComment in errorReportComments)
            {
                Console.WriteLine($"Felanmälningsnummer: {errorReportComment.Id}");
                Console.WriteLine($"Beskrivning av felanmälan: {errorReportComment.ErrorReportDescription}");
                Console.WriteLine($"Felanmälningsstatus: {errorReportComment.ErrorReportStatus}");
                Console.WriteLine("");
                Console.WriteLine($"Kommentaren skapades: {errorReportComment.ErrorReportCommentDate}");
                Console.WriteLine($"Styrelsens kommentar: {errorReportComment.ErrorReportComment}");
                Console.WriteLine("\n-----------------------------------------------------------------------------------------\n");
            }
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine("Just nu finns det inga felanmälningar med kommentarer i bostadsföreningen.");
        }
    }

    public async Task GetOneErrorCommentAsync()
    {
        Console.Clear();
        Console.Write("Ange Felanmälningsnummer: ");
        var answer = Console.ReadLine();
        int id;

        if (int.TryParse(answer, out id))
        {
            var errorReportComment = await ErrorCommentServiceDB.GetErrorReportswithComments(id);
            if(errorReportComment != null)
            {
                Console.Clear();
                Console.WriteLine($"Felanmälningsnummer: {errorReportComment.Id}");
                Console.WriteLine($"När kommentaren är gjord: {errorReportComment.ErrorReportCommentDate}");
                Console.WriteLine($"Kommentar:");
                Console.Write($"{errorReportComment.ErrorReportComment}\n");
                Console.WriteLine("");
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
}
