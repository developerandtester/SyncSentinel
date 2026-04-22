using SyncSentinel.Domain.Enums;

namespace SyncSentinel.Application.DTOs.SyncJobs;

public class SyncJobDto
{
    public Guid Id { get; set; }
    public Guid? IncidentId { get; set; }
    public JobType JobType { get; set; }
    public SyncJobStatus Status { get; set; }
    public string SourceSystem { get; set; } = string.Empty;
    public string TargetSystem { get; set; } = string.Empty;
    public int RetryCount { get; set; }
    public int MaxRetries { get; set; }
    public string Payload { get; set; } = string.Empty;
    public string? LastError { get; set; }
    public DateTime CreatedUtc { get; set; }
    public DateTime? LastAttemptUtc { get; set; }
    public DateTime? CompletedUtc { get; set; }
}