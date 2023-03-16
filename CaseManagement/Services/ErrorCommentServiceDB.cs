using CaseManagement.Contexts;
using CaseManagement.Models;
using CaseManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaseManagement.Services;

internal class ErrorCommentServiceDB
{

    private static DataContext _dataContext = new DataContext();

    public static async Task SaveErrorCommentAsync(ErrorReportCommentModel errorReportCommentModel)
    {
        var errorReportCommentEntity = new ErrorReportCommentEntity
        {
            ErrorReportCommentDate = errorReportCommentModel.ErrorReportCommentDate,
            ErrorReportComment = errorReportCommentModel.ErrorReportDescription,
        };

        var errorReportEntity = await _dataContext.ErrorReports.FirstOrDefaultAsync(x => x.ErrorReportId == errorReportCommentModel.Id);
        if(errorReportEntity != null)
        {
            errorReportCommentEntity.ErrorReportId = errorReportEntity.ErrorReportId;

            _dataContext.Add(errorReportCommentEntity);
            await _dataContext.SaveChangesAsync();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine($"Finns ingen med E-postadress: {errorReportCommentModel.Id}. \nVänligen ange en befintlig E-postadress eller lägg till ny medlem i föreningen! ");
        }
    }

    public static async Task<IEnumerable<ErrorReportCommentModel>> GetAllErrorReportswithComments()
    {
        var errorReportComments = new List<ErrorReportCommentModel>();

        foreach (var errorReportComment in await _dataContext.ErrorReportsComments.Include(x => x.ErrorReport).ThenInclude(x => x.Member).ToListAsync())
            errorReportComments.Add(new ErrorReportCommentModel
            {
                ErrorReportDescription = errorReportComment.ErrorReport.ErrorReportDescription,
                ErrorReportStatus = errorReportComment.ErrorReport.ErrorReportStatus,
                FirstName = errorReportComment.ErrorReport.Member.FirstName,
                LastName = errorReportComment.ErrorReport.Member.LastName,
                Email = errorReportComment.ErrorReport.Member.Email,

                Id = errorReportComment.ErrorReport.ErrorReportId,
                ErrorReportCommentDate = errorReportComment.ErrorReportCommentDate,
                ErrorReportComment = errorReportComment.ErrorReportComment
            });

        return errorReportComments;
    }
    
    public static async Task<ErrorReportCommentModel> GetErrorReportswithComments(int id)
    {
        var errorReportComment = await _dataContext.ErrorReportsComments.Include(x => x.ErrorReport).ThenInclude(x => x.Member).FirstOrDefaultAsync(x => x.ErrorReportId == id);
        if (errorReportComment != null)
        {
            return new ErrorReportCommentModel
            {
                ErrorReportDescription = errorReportComment.ErrorReport.ErrorReportDescription,
                ErrorReportStatus = errorReportComment.ErrorReport.ErrorReportStatus,
                FirstName = errorReportComment.ErrorReport.Member.FirstName,
                LastName = errorReportComment.ErrorReport.Member.LastName,
                Email = errorReportComment.ErrorReport.Member.Email,

                Id = errorReportComment.ErrorReport.ErrorReportId,
                ErrorReportComment = errorReportComment.ErrorReportComment,
                ErrorReportCommentDate = errorReportComment.ErrorReportCommentDate
            };
        }
        else
            return null!;
    }

} 
