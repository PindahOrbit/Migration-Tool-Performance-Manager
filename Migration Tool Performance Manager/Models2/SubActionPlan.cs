using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

public partial class SubActionPlan
{
    [Key]
    public int Id { get; set; }

    [Column("Action_plan_id")]
    public int? ActionPlanId { get; set; }

    public string Name { get; set; } = null!;

    public double Weight { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeadLine { get; set; }

    public bool IsDone { get; set; }

    [Column("champion_id")]
    [StringLength(450)]
    public string? ChampionId { get; set; }

    [ForeignKey("ActionPlanId")]
    [InverseProperty("SubActionPlans")]
    public virtual ActionPlan? ActionPlan { get; set; }

    [ForeignKey("ChampionId")]
    [InverseProperty("SubActionPlans")]
    public virtual User? Champion { get; set; }
}
