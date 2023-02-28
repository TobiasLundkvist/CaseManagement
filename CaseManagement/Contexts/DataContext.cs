using CaseManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaseManagement.Contexts;

internal class DataContext : DbContext
{
    private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Tobias Lundkvist\Documents\2Webbutveckling\Datalagring\CaseManagement\CaseManagement\Contexts\local_caseManagement_sql.mdf"";Integrated Security=True;Connect Timeout=30";

    public DataContext()
    {
        
    }

    public DataContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(_connectionString);
    }

    public DbSet<AddressEntity> Addresses { get; set; } = null!;
    public DbSet<MemberEntity> Members { get; set; } = null!;
    public DbSet<ErrorReportEntity> ErrorReports { get; set; } = null!;
}
