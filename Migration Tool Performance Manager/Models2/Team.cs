using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

public partial class Team
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("department_id")]
    public int? DepartmentId { get; set; }

    [Column("company_id")]
    public int CompanyId { get; set; }

    [Column("team_name")]
    [StringLength(250)]
    public string TeamName { get; set; } = null!;

    [Column("leader_id")]
    [StringLength(450)]
    public string? LeaderId { get; set; }

    [ForeignKey("CompanyId")]
    [InverseProperty("Teams")]
    public virtual Company Company { get; set; } = null!;

    [ForeignKey("DepartmentId")]
    [InverseProperty("Teams")]
    public virtual Department? Department { get; set; }

    [InverseProperty("Team")]
    public virtual ICollection<EmployeeDetail> EmployeeDetails { get; set; } = new List<EmployeeDetail>();

    [ForeignKey("LeaderId")]
    [InverseProperty("Teams")]
    public virtual User? Leader { get; set; }

    [InverseProperty("Team")]
    public virtual ICollection<TeamGoal> TeamGoals { get; set; } = new List<TeamGoal>();

    [ForeignKey("TeamId")]
    [InverseProperty("Teams")]
    public virtual ICollection<ActionPlan> ActionPlans { get; set; } = new List<ActionPlan>();
}
