using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Index("Name", Name = "UQ__ActionPl__737584F66DA6964A", IsUnique = true)]
public partial class ActionPlanStage
{
    [Key]
    public int Id { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    public int Priority { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Color { get; set; } = null!;

    [InverseProperty("ProgressNavigation")]
    public virtual ICollection<ActionPlan> ActionPlans { get; set; } = new List<ActionPlan>();

    [InverseProperty("Stage")]
    public virtual ICollection<CompanyActionStage> CompanyActionStages { get; set; } = new List<CompanyActionStage>();
}
