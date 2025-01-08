using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("action_plan_checklist")]
public partial class ActionPlanChecklist
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("action_plan_id")]
    public int ActionPlanId { get; set; }

    [Column("task_name")]
    [StringLength(450)]
    public string TaskName { get; set; } = null!;

    [Column("created_date", TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("due_date", TypeName = "datetime")]
    public DateTime DueDate { get; set; }

    [Column("allocated_weight")]
    public double AllocatedWeight { get; set; }

    [Column("progress")]
    public double Progress { get; set; }

    [ForeignKey("ActionPlanId")]
    [InverseProperty("ActionPlanChecklists")]
    public virtual ActionPlan ActionPlan { get; set; } = null!;
}
