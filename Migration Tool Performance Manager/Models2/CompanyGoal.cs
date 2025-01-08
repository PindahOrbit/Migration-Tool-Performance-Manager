using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

public partial class CompanyGoal
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("company_id")]
    public int CompanyId { get; set; }

    [Column("Perspective_Id")]
    public int PerspectiveId { get; set; }

    [Column("goal_name")]
    [StringLength(50)]
    public string GoalName { get; set; } = null!;

    [ForeignKey("CompanyId")]
    [InverseProperty("CompanyGoals")]
    public virtual Company Company { get; set; } = null!;

    [ForeignKey("PerspectiveId")]
    [InverseProperty("CompanyGoals")]
    public virtual Perspective Perspective { get; set; } = null!;
}
