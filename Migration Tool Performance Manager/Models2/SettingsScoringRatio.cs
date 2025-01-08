using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("settings_scoring_ratios")]
public partial class SettingsScoringRatio
{
    [Key]
    [Column("company_id")]
    public int CompanyId { get; set; }

    [Column("scorecard")]
    public double Scorecard { get; set; }

    [Column("actions")]
    public double Actions { get; set; }

    [Column("behavior")]
    public double Behavior { get; set; }

    [ForeignKey("CompanyId")]
    [InverseProperty("SettingsScoringRatio")]
    public virtual Company Company { get; set; } = null!;
}
