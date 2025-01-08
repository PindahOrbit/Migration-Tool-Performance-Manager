using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("Measure_units")]
public partial class MeasureUnit
{
    [Key]
    [Column("Measure_id")]
    public int MeasureId { get; set; }

    [Column("Company_id")]
    public int CompanyId { get; set; }

    [Column("Perspective_id")]
    public int PerspectiveId { get; set; }

    [Column("Goal_id")]
    public int GoalId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Unit { get; set; }

    [Column("Recording_frequency")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RecordingFrequency { get; set; }

    [Column("Target_period")]
    [StringLength(50)]
    [Unicode(false)]
    public string? TargetPeriod { get; set; }

    [Column("Base_target")]
    public double BaseTarget { get; set; }

    [Column("Stretched_target")]
    public double StretchedTarget { get; set; }

    [Column("Allocated_weight")]
    public double AllocatedWeight { get; set; }

    public bool? Approved { get; set; }

    [Column("scorecard_id")]
    public int ScorecardId { get; set; }

    [ForeignKey("CompanyId")]
    [InverseProperty("MeasureUnits")]
    public virtual Company Company { get; set; } = null!;

    [ForeignKey("GoalId")]
    [InverseProperty("MeasureUnits")]
    public virtual Goal Goal { get; set; } = null!;

    [InverseProperty("MeasureUnit")]
    public virtual ICollection<Kpiactual> Kpiactuals { get; set; } = new List<Kpiactual>();

    [ForeignKey("MeasureId")]
    [InverseProperty("MeasureUnit")]
    public virtual Measure Measure { get; set; } = null!;

    [ForeignKey("PerspectiveId")]
    [InverseProperty("MeasureUnits")]
    public virtual Perspective Perspective { get; set; } = null!;

    [ForeignKey("ScorecardId")]
    [InverseProperty("MeasureUnits")]
    public virtual Scorecard Scorecard { get; set; } = null!;
}
