using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

public partial class Goal
{
    [Key]
    public int Id { get; set; }

    [Column("datecreated")]
    public DateOnly Datecreated { get; set; }

    [Column("Company_id")]
    public int? CompanyId { get; set; }

    [Column("User_Id")]
    [StringLength(450)]
    public string? UserId { get; set; }

    [Column("Perspective_id")]
    public int? PerspectiveId { get; set; }

    public string Name { get; set; } = null!;

    [Column("approved")]
    public bool Approved { get; set; }

    [Column("parent_goal")]
    public int? ParentGoal { get; set; }

    [Column("scorecard_id")]
    public int? ScorecardId { get; set; }

    [Column("DESCRIPTION")]
    public string? Description { get; set; }

    [ForeignKey("CompanyId")]
    [InverseProperty("Goals")]
    public virtual Company? Company { get; set; }

    [InverseProperty("Goal")]
    public virtual ICollection<MeasureUnit> MeasureUnits { get; set; } = new List<MeasureUnit>();

    [InverseProperty("Goal")]
    public virtual ICollection<Measure> Measures { get; set; } = new List<Measure>();

    [ForeignKey("PerspectiveId")]
    [InverseProperty("Goals")]
    public virtual Perspective? Perspective { get; set; }

    [ForeignKey("ScorecardId")]
    [InverseProperty("Goals")]
    public virtual Scorecard? Scorecard { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Goals")]
    public virtual User? User { get; set; }

    [ForeignKey("GoalId")]
    [InverseProperty("Goals")]
    public virtual ICollection<ActionPlan> ActionPlans { get; set; } = new List<ActionPlan>();
}
