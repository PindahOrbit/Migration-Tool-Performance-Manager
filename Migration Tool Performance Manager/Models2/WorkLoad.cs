using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("work_loads")]
public partial class WorkLoad
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(500)]
    public string Name { get; set; } = null!;

    [Column("scorecard_id")]
    public int ScorecardId { get; set; }

    [Column("color_code")]
    [StringLength(50)]
    public string ColorCode { get; set; } = null!;

    [InverseProperty("Workload")]
    public virtual ICollection<ActionPlan> ActionPlans { get; set; } = new List<ActionPlan>();

    [ForeignKey("ScorecardId")]
    [InverseProperty("WorkLoads")]
    public virtual Scorecard Scorecard { get; set; } = null!;
}
