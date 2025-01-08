using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[PrimaryKey("EmployeeId", "PerspectiveId", "ScorecardId")]
public partial class EmployeePerspective
{
    [Key]
    [Column("Employee_Id")]
    public string EmployeeId { get; set; } = null!;

    [Key]
    [Column("Perspective_Id")]
    public int PerspectiveId { get; set; }

    public double Weight { get; set; }

    [Key]
    [Column("scorecard_id")]
    public int ScorecardId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("EmployeePerspectives")]
    public virtual User Employee { get; set; } = null!;

    [ForeignKey("PerspectiveId")]
    [InverseProperty("EmployeePerspectives")]
    public virtual Perspective Perspective { get; set; } = null!;

    [ForeignKey("ScorecardId")]
    [InverseProperty("EmployeePerspectives")]
    public virtual Scorecard Scorecard { get; set; } = null!;
}
