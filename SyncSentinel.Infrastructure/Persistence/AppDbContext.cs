using Microsoft.EntityFrameworkCore;
using SyncSentinel.Domain.Entities;

namespace SyncSentinel.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Incident> Incidents => Set<Incident>();
    public DbSet<IncidentRcaNote> IncidentRcaNotes => Set<IncidentRcaNote>();
    public DbSet<SyncJob> SyncJobs => Set<SyncJob>();
    public DbSet<IntegrationEventLog> IntegrationEventLogs => Set<IntegrationEventLog>();
    public DbSet<AiInsight> AiInsights => Set<AiInsight>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Incident>(entity =>
        {
            entity.ToTable("Incidents");
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Title)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(x => x.Description)
                .HasMaxLength(4000)
                .IsRequired();

            entity.Property(x => x.SourceSystem)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(x => x.ExternalReference)
                .HasMaxLength(100);

            entity.Property(x => x.Priority)
                .HasConversion<int>()
                .IsRequired();

            entity.Property(x => x.Status)
                .HasConversion<int>()
                .IsRequired();

            entity.Property(x => x.CreatedUtc)
                .IsRequired();

            entity.HasIndex(x => x.Status);
            entity.HasIndex(x => x.Priority);
            entity.HasIndex(x => x.SourceSystem);
        });

        modelBuilder.Entity<IncidentRcaNote>(entity =>
        {
            entity.ToTable("IncidentRcaNotes");
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Note)
                .HasMaxLength(2000)
                .IsRequired();

            entity.Property(x => x.CreatedBy)
                .HasMaxLength(100)
                .IsRequired();

            entity.HasOne(x => x.Incident)
                .WithMany(x => x.RcaNotes)
                .HasForeignKey(x => x.IncidentId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<SyncJob>(entity =>
        {
            entity.ToTable("SyncJobs");
            entity.HasKey(x => x.Id);

            entity.Property(x => x.JobType)
                .HasConversion<int>()
                .IsRequired();

            entity.Property(x => x.Status)
                .HasConversion<int>()
                .IsRequired();

            entity.Property(x => x.SourceSystem)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(x => x.TargetSystem)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(x => x.Payload)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            entity.Property(x => x.LastError)
                .HasMaxLength(4000);

            entity.HasIndex(x => x.Status);
            entity.HasIndex(x => x.JobType);

            entity.HasOne(x => x.Incident)
                .WithMany(x => x.SyncJobs)
                .HasForeignKey(x => x.IncidentId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<IntegrationEventLog>(entity =>
        {
            entity.ToTable("IntegrationEventLogs");
            entity.HasKey(x => x.Id);

            entity.Property(x => x.EventType)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(x => x.RoutingKey)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(x => x.Payload)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            entity.Property(x => x.Status)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(x => x.Error)
                .HasMaxLength(4000);

            entity.HasIndex(x => x.Status);
            entity.HasIndex(x => x.CreatedUtc);
        });

        modelBuilder.Entity<AiInsight>(entity =>
        {
            entity.ToTable("AiInsights");
            entity.HasKey(x => x.Id);

            entity.Property(x => x.InsightType)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(x => x.Content)
                .HasMaxLength(4000)
                .IsRequired();

            entity.Property(x => x.ConfidenceScore)
                .HasColumnType("decimal(5,2)");

            entity.HasOne(x => x.Incident)
                .WithMany(x => x.AiInsights)
                .HasForeignKey(x => x.IncidentId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}