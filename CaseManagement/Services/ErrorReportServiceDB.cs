using CaseManagement.Contexts;
using CaseManagement.Models;
using CaseManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaseManagement.Services;

internal class ErrorReportServiceDB
{
    private static DataContext _dataContext = new DataContext();

    public static async Task SaveErrorReportAsync(ErrorReportModel errorReportModel)
    {

        var errorReportEntity = new ErrorReportEntity
        {
            ErrorReportId = errorReportModel.Id,
            ErrorReportDate = errorReportModel.ErrorReportDate,
            ErrorReportDueDate = errorReportModel.ErrorReportDueDate,
            ErrorReportDescription = errorReportModel.ErrorReportDescription,
            ErrorReportStatus = errorReportModel.ErrorReportStatus,
        };


        var memberEntity = await _dataContext.Members.FirstOrDefaultAsync(x => x.Email == errorReportModel.Email);
        if(memberEntity != null)
        {
            errorReportEntity.MemberId = memberEntity.MemberId;
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"Finns ingen med E-postadress: {errorReportModel.Email}. \nVänligen ange en befintlig E-postadress eller lägg till en ny hyresgäst! ");
        }

        _dataContext.Add(errorReportEntity);
        await _dataContext.SaveChangesAsync();
    }

    public static async Task<IEnumerable<ErrorReportModel>> GetAllErrorReportsAsync()
    {
        var errorReports = new List<ErrorReportModel>();

        foreach (var errorReport in await _dataContext.ErrorReports.Include(x => x.Member).ToListAsync())
            errorReports.Add(new ErrorReportModel
            {
                FirstName = errorReport.Member.FirstName,
                LastName = errorReport.Member.LastName,
                Email = errorReport.Member.Email,
                Phone = errorReport.Member.Phone,

                Id = errorReport.ErrorReportId,
                ErrorReportDate = errorReport.ErrorReportDate,
                ErrorReportDescription = errorReport.ErrorReportDescription,
                ErrorReportStatus = errorReport.ErrorReportStatus,
                ErrorReportDueDate = (DateTime)errorReport.ErrorReportDueDate
            });

        return errorReports;
    } 

    public static async Task<ErrorReportModel> GetErrorReportAsync(int id)
    {
        var errorReport = await _dataContext.ErrorReports.Include(x => x.Member).FirstOrDefaultAsync(x => x.ErrorReportId == id);
        if (errorReport != null)
        {
            return new ErrorReportModel
            {
                Id = errorReport.ErrorReportId,
                ErrorReportDate = errorReport.ErrorReportDate,
                ErrorReportDescription = errorReport.ErrorReportDescription,
                ErrorReportStatus = errorReport.ErrorReportStatus,
                ErrorReportDueDate = (DateTime)errorReport.ErrorReportDueDate,

                FirstName = errorReport.Member.FirstName,
                LastName = errorReport.Member.LastName,
                Email = errorReport.Member.Email,
                Phone = errorReport.Member.Phone
            };
        }
        else
            return null!;
    } 
}



