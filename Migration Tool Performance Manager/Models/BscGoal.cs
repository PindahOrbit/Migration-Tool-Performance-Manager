using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_goals")]
public partial class BscGoal
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("scorecard_id", TypeName = "text")]
    public string ScorecardId { get; set; }

    [Column("perspective_id", TypeName = "text")]
    public string PerspectiveId { get; set; }

    [Required]
    [Column("strategic_goal", TypeName = "text")]
    public string StrategicGoal { get; set; }

    [Column("goal", TypeName = "text")]
    public string Goal { get; set; }

    [Column("goal_explanation", TypeName = "text")]
    public string GoalExplanation { get; set; }

    [Column("tracker_period_id", TypeName = "text")]
    public string TrackerPeriodId { get; set; }

    [Column("cumulative")]
    public int? Cumulative { get; set; }
}
