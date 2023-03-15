using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseManagement.Migrations
{
    /// <inheritdoc />
    public partial class ErrorReportCommentAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ErrorReportsComments",
                columns: table => new
                {
                    ErrorReportCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErrorReportComment = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ErrorReportCommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ErrorReportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorReportsComments", x => x.ErrorReportCommentId);
                    table.ForeignKey(
                        name: "FK_ErrorReportsComments_ErrorReports_ErrorReportId",
                        column: x => x.ErrorReportId,
                        principalTable: "ErrorReports",
                        principalColumn: "ErrorReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ErrorReportsComments_ErrorReportId",
                table: "ErrorReportsComments",
                column: "ErrorReportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ErrorReportsComments");
        }
    }
}
