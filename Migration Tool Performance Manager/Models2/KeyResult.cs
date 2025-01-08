using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

public partial class KeyResult
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("creator_id")]
    [StringLength(450)]
    public string CreatorId { get; set; } = null!;

    [Column("delegate_id")]
    [StringLength(450)]
    public string? DelegateId { get; set; }

    [Column("objective_id")]
    public int? ObjectiveId { get; set; }

    [Column("team_id")]
    public int? TeamId { get; set; }

    [Column("title")]
    [StringLength(400)]
    public string Title { get; set; } = null!;

    [Column("type")]
    [StringLength(13)]
    public string Type { get; set; } = null!;

    [Column("period")]
    [StringLength(13)]
    public string Period { get; set; } = null!;

    [Column("description")]
    [StringLength(500)]
    public string? Description { get; set; }

    [Column("metric")]
    [StringLength(500)]
    public string? Metric { get; set; }

    [Column("metric_unit")]
    [StringLength(1)]
    public string MetricUnit { get; set; } = null!;

    [Column("target_should")]
    [StringLength(400)]
    public string TargetShould { get; set; } = null!;

    [Column("target_FROM")]
    public double TargetFrom { get; set; }

    [Column("target_TO")]
    public double TargetTo { get; set; }

    [Column("progress_number")]
    public double ProgressNumber { get; set; }

    [Column("progress")]
    [StringLength(13)]
    public string Progress { get; set; } = null!;

    [Column("actual")]
    public double Actual { get; set; }

    [ForeignKey("CreatorId")]
    [InverseProperty("KeyResultCreators")]
    public virtual User Creator { get; set; } = null!;

    [ForeignKey("DelegateId")]
    [InverseProperty("KeyResultDelegates")]
    public virtual User? Delegate { get; set; }

    [ForeignKey("ObjectiveId")]
    [InverseProperty("KeyResults")]
    public virtual Objective? Objective { get; set; }

    [ForeignKey("TeamId")]
    [InverseProperty("KeyResults")]
    public virtual Teamsokr? Team { get; set; }
}
