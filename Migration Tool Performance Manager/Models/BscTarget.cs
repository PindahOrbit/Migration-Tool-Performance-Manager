using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_targets")]
public partial class BscTarget
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("goal_id", TypeName = "text")]
    public string GoalId { get; set; }

    [Column("measure", TypeName = "text")]
    public string Measure { get; set; }

    [Column("unit")]
    [StringLength(10)]
    public string Unit { get; set; }

    [Column("reporting_frequency")]
    [StringLength(10)]
    public string ReportingFrequency { get; set; }

    [Column("target_period")]
    [StringLength(10)]
    public string TargetPeriod { get; set; }

    [Column("direction")]
    public int? Direction { get; set; }

    [Column("base_target", TypeName = "text")]
    public string BaseTarget { get; set; }

    [Column("stretch_target", TypeName = "text")]
    public string StretchTarget { get; set; }

    [Column("actual", TypeName = "text")]
    public string Actual { get; set; }

    [Column("score", TypeName = "double(11,2)")]
    public double Score { get; set; }

    [Column("allocated_weight", TypeName = "text")]
    public string AllocatedWeight { get; set; }

    [Column("trend_indicator", TypeName = "text")]
    public string TrendIndicator { get; set; }
}
