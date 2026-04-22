using System.ComponentModel.DataAnnotations;
using SyncSentinel.Domain.Enums;

namespace SyncSentinel.Application.DTOs.SyncJobs;

public class CreateSyncJobRequest
{
    [Required]
    public Guid? IncidentId { get; set; }

    [Required]
    public JobType JobType { get; set; }

    [Required]
    [MaxLength(100)]
    public string SourceSystem { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string TargetSystem { get; set; } = string.Empty;

    [Required]
    public string Payload { get; set; } = string.Empty;

    [Range(0, 20)]
    public int MaxRetries { get; set; } = 3;
}