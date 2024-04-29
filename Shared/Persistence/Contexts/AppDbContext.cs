using Microsoft.EntityFrameworkCore;
using MindWell_TreatmentValidation.Shared.Extensions;
using MindWell_TreatmentValidation.TreatmentValidation.Domain.Models;

namespace MindWell_TreatmentValidation.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<TreatmentValidation.Domain.Models.TreatmentValidation> TreatmentValidations { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<TreatmentValidation.Domain.Models.TreatmentValidation>().ToTable("TreatmentMonitorings");
        builder.Entity<TreatmentValidation.Domain.Models.TreatmentValidation>().HasKey(x => x.Id);
        builder.Entity<TreatmentValidation.Domain.Models.TreatmentValidation>().Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<TreatmentValidation.Domain.Models.TreatmentValidation>().Property(x => x.Lifespan).IsRequired();
        builder.Entity<TreatmentValidation.Domain.Models.TreatmentValidation>().Property(x => x.Counter).IsRequired();
        builder.Entity<TreatmentValidation.Domain.Models.TreatmentValidation>().Property(x => x.Recommendaton_Id).IsRequired();

        // Apply Snake Case Naming Convention
        builder.UseSnakeCaseNamingConvention();
    }
}