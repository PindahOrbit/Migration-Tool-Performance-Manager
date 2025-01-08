using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("action_plan_comments")]
public partial class ActionPlanComment
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("action_plan_id")]
    public int ActionPlanId { get; set; }

    [Column("user_id")]
    [StringLength(450)]
    public string? UserId { get; set; }

    [Column("comment")]
    public string? Comment { get; set; }

    [Column("date", TypeName = "datetime")]
    public DateTime Date { get; set; }

    [ForeignKey("ActionPlanId")]
    [InverseProperty("ActionPlanComments")]
    public virtual ActionPlan ActionPlan { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("ActionPlanComments")]
    public virtual User? User { get; set; }
}
