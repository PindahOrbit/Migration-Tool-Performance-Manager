using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

public partial class Perspective
{
    [Key]
    public int Id { get; set; }

    [Column("Company_id")]
    public int? CompanyId { get; set; }

    [Unicode(false)]
    public string? Name { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string Type { get; set; } = null!;

    [Column("priority")]
    public int Priority { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [InverseProperty("Perspective")]
    public virtual ICollection<ActionPlan> ActionPlans { get; set; } = new List<ActionPlan>();

    [ForeignKey("CompanyId")]
    [InverseProperty("Perspectives")]
    public virtual Company? Company { get; set; }

    [InverseProperty("Perspective")]
    public virtual ICollection<CompanyGoal> CompanyGoals { get; set; } = new List<CompanyGoal>();

    [InverseProperty("Perspective")]
    public virtual ICollection<EmployeePerspective> EmployeePerspectives { get; set; } = new List<EmployeePerspective>();

    [InverseProperty("Perspective")]
    public virtual ICollection<Goal> Goals { get; set; } = new List<Goal>();

    [InverseProperty("Perspective")]
    public virtual ICollection<MeasureUnit> MeasureUnits { get; set; } = new List<MeasureUnit>();

    [InverseProperty("Perspective")]
    public virtual ICollection<Measure> Measures { get; set; } = new List<Measure>();

    [InverseProperty("StrategicFocusArea")]
    public virtual ICollection<Objective> Objectives { get; set; } = new List<Objective>();

    [InverseProperty("Perspective")]
    public virtual ICollection<PerspectiveAllocation> PerspectiveAllocations { get; set; } = new List<PerspectiveAllocation>();
}
