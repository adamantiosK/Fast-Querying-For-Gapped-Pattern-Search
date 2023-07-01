using FSGPM.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;


public class DTUcontext : DbContext
{
    public DTUcontext()
    {
    }

    public DTUcontext(DbContextOptions<DTUcontext> options) : base(options)
    {
    }

    public DbSet<ReportStatus> ReportStatuses { get; set; }
    public DbSet<Constraint> Constraints { get; set; }
    public DbSet<ConstraintCount> ConstraintCounts { get; set; }
    public DbSet<DataSet> DataSets { get; set; }
    public DbSet<Pattern> Patterns { get; set; }
    public DbSet<AlgoDataSetResult> AlgoDataSetResults { get; set; }
    public DbSet<AlgoDataSetResultApproved> AlgoDataSetResultsApproved { get; set; }
    public DbSet<SuffixArraySet> SuffixArraySets { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // configure the data model here
    }
}