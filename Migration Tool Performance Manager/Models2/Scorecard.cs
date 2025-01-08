using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("Scorecard")]
public partial class Scorecard
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("company_id")]
    public int CompanyId { get; set; }

    [Column("owner_id")]
    [StringLength(450)]
    public string OwnerId { get; set; } = null!;

    [Column("period_from", TypeName = "datetime")]
    public DateTime? PeriodFrom { get; set; }

    [Column("period_to", TypeName = "datetime")]
    public DateTime? PeriodTo { get; set; }

    [Column("score")]
    public double? Score { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; }

    [Column("activated")]
    public bool Activated { get; set; }

    [Column("is_locked")]
    public bool IsLocked { get; set; }

    [Column("supervisor_review")]
    public string? SupervisorReview { get; set; }

    [Column("reviewer_id")]
    [StringLength(450)]
    public string? ReviewerId { get; set; }

    [Column("date_reviewed", TypeName = "datetime")]
    public DateTime DateReviewed { get; set; }

    [Column("my_review")]
    public string? MyReview { get; set; }

    [Column("submitted")]
    public bool Submitted { get; set; }

    [InverseProperty("Scorecard")]
    public virtual ICollection<ActionPlan> ActionPlans { get; set; } = new List<ActionPlan>();

    [ForeignKey("CompanyId")]
    [InverseProperty("Scorecards")]
    public virtual Company Company { get; set; } = null!;

    [InverseProperty("Scorecard")]
    public virtual ICollection<EmployeePerspective> EmployeePerspectives { get; set; } = new List<EmployeePerspective>();

    [InverseProperty("Scorecard")]
    public virtual ICollection<Goal> Goals { get; set; } = new List<Goal>();

    [InverseProperty("Scorecard")]
    public virtual ICollection<Kpiactual> Kpiactuals { get; set; } = new List<Kpiactual>();

    [InverseProperty("Scorecard")]
    public virtual ICollection<MeasureUnit> MeasureUnits { get; set; } = new List<MeasureUnit>();

    [InverseProperty("Scorecard")]
    public virtual ICollection<Measure> Measures { get; set; } = new List<Measure>();

    [ForeignKey("OwnerId")]
    [InverseProperty("ScorecardOwners")]
    public virtual User Owner { get; set; } = null!;

    [ForeignKey("ReviewerId")]
    [InverseProperty("ScorecardReviewers")]
    public virtual User? Reviewer { get; set; }

    [InverseProperty("Scorecard")]
    public virtual ICollection<WorkLoad> WorkLoads { get; set; } = new List<WorkLoad>();
}
