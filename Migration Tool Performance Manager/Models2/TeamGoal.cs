using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

public partial class TeamGoal
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("company_id")]
    public int CompanyId { get; set; }

    [Column("department_id")]
    public int? DepartmentId { get; set; }

    [Column("team_id")]
    public int? TeamId { get; set; }

    [Column("goal_name")]
    [StringLength(250)]
    public string GoalName { get; set; } = null!;

    [ForeignKey("CompanyId")]
    [InverseProperty("TeamGoals")]
    public virtual Company Company { get; set; } = null!;

    [ForeignKey("DepartmentId")]
    [InverseProperty("TeamGoals")]
    public virtual Department? Department { get; set; }

    [ForeignKey("TeamId")]
    [InverseProperty("TeamGoals")]
    public virtual Team? Team { get; set; }
}
