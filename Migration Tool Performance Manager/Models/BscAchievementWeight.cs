using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_achievement_weights")]
public partial class BscAchievementWeight
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("scorecard_weight")]
    public int ScorecardWeight { get; set; }

    [Column("actionplan_weight")]
    public int? ActionplanWeight { get; set; }

    [Column("behavioral_weight")]
    public int? BehavioralWeight { get; set; }
}
