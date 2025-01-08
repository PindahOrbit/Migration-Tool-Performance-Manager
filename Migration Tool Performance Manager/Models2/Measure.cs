using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

public partial class Measure
{
    [Key]
    public int Id { get; set; }

    [Column("Company_id")]
    public int? CompanyId { get; set; }

    [Column("Perspective_id")]
    public int? PerspectiveId { get; set; }

    [Column("Goal_id")]
    public int GoalId { get; set; }

    public string Name { get; set; } = null!;

    [Column("scorecard_id")]
    public int ScorecardId { get; set; }

    [ForeignKey("CompanyId")]
    [InverseProperty("Measures")]
    public virtual Company? Company { get; set; }

    [ForeignKey("GoalId")]
    [InverseProperty("Measures")]
    public virtual Goal Goal { get; set; } = null!;

    [InverseProperty("Measure")]
    public virtual MeasureUnit? MeasureUnit { get; set; }

    [ForeignKey("PerspectiveId")]
    [InverseProperty("Measures")]
    public virtual Perspective? Perspective { get; set; }

    [ForeignKey("ScorecardId")]
    [InverseProperty("Measures")]
    public virtual Scorecard Scorecard { get; set; } = null!;
}
