using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

public partial class PendingActionPlanChange
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("userid")]
    [StringLength(450)]
    public string Userid { get; set; } = null!;

    [Column("action_plan_id")]
    public int ActionPlanId { get; set; }

    [Column("pending_value")]
    [StringLength(250)]
    public string? PendingValue { get; set; }

    [Column("approved")]
    public bool Approved { get; set; }

    [ForeignKey("ActionPlanId")]
    [InverseProperty("PendingActionPlanChanges")]
    public virtual ActionPlan ActionPlan { get; set; } = null!;
}
