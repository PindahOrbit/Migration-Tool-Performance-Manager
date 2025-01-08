using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

public partial class ActionPlan
{
    [Key]
    public int Id { get; set; }

    [Column("Company_id")]
    public int CompanyId { get; set; }

    [Column("Perspective_id")]
    public int PerspectiveId { get; set; }

    public string Name { get; set; } = null!;

    [Column("Start_date", TypeName = "datetime")]
    public DateTime? StartDate { get; set; }

    [Column("Due_date", TypeName = "datetime")]
    public DateTime? DueDate { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string Progress { get; set; } = null!;

    public double? ProgressNumber { get; set; }

    public bool? IsDone { get; set; }

    [Column("evidence")]
    public string? Evidence { get; set; }

    [Column("priority")]
    [StringLength(20)]
    [Unicode(false)]
    public string Priority { get; set; } = null!;

    [Column("impact")]
    [StringLength(10)]
    [Unicode(false)]
    public string Impact { get; set; } = null!;

    [Column("quality")]
    [StringLength(10)]
    [Unicode(false)]
    public string Quality { get; set; } = null!;

    [Column("resourcing")]
    [StringLength(12)]
    [Unicode(false)]
    public string Resourcing { get; set; } = null!;

    [Column("code")]
    [StringLength(20)]
    [Unicode(false)]
    public string Code { get; set; } = null!;

    [Column("exception")]
    public bool Exception { get; set; }

    [Column("impact_horizon")]
    [StringLength(20)]
    public string ImpactHorizon { get; set; } = null!;

    [Column("budget")]
    public double? Budget { get; set; }

    [Column("parent_id")]
    public int? ParentId { get; set; }

    [Column("user_id")]
    [StringLength(450)]
    public string? UserId { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("scorecard_id")]
    public int? ScorecardId { get; set; }

    [Column("workload_id")]
    public int? WorkloadId { get; set; }

    [Column("weight")]
    public int? Weight { get; set; }

    [Column("approved")]
    public bool Approved { get; set; }

    [InverseProperty("ActionPlan")]
    public virtual ICollection<ActionPlanAttachment> ActionPlanAttachments { get; set; } = new List<ActionPlanAttachment>();

    [InverseProperty("ActionPlan")]
    public virtual ICollection<ActionPlanChecklist> ActionPlanChecklists { get; set; } = new List<ActionPlanChecklist>();

    [InverseProperty("ActionPlan")]
    public virtual ICollection<ActionPlanComment> ActionPlanComments { get; set; } = new List<ActionPlanComment>();

    [ForeignKey("CompanyId")]
    [InverseProperty("ActionPlans")]
    public virtual Company Company { get; set; } = null!;

    [InverseProperty("Parent")]
    public virtual ICollection<ActionPlan> InverseParent { get; set; } = new List<ActionPlan>();

    [ForeignKey("ParentId")]
    [InverseProperty("InverseParent")]
    public virtual ActionPlan? Parent { get; set; }

    [InverseProperty("ActionPlan")]
    public virtual ICollection<PendingActionPlanChange> PendingActionPlanChanges { get; set; } = new List<PendingActionPlanChange>();

    [ForeignKey("PerspectiveId")]
    [InverseProperty("ActionPlans")]
    public virtual Perspective Perspective { get; set; } = null!;

    [ForeignKey("Progress")]
    [InverseProperty("ActionPlans")]
    public virtual ActionPlanStage ProgressNavigation { get; set; } = null!;

    [ForeignKey("ScorecardId")]
    [InverseProperty("ActionPlans")]
    public virtual Scorecard? Scorecard { get; set; }

    [InverseProperty("ActionPlan")]
    public virtual ICollection<SubActionPlan> SubActionPlans { get; set; } = new List<SubActionPlan>();

    [ForeignKey("UserId")]
    [InverseProperty("ActionPlans")]
    public virtual User? User { get; set; }

    [ForeignKey("WorkloadId")]
    [InverseProperty("ActionPlans")]
    public virtual WorkLoad? Workload { get; set; }

    [ForeignKey("ActionPlanId")]
    [InverseProperty("ActionPlans")]
    public virtual ICollection<Goal> Goals { get; set; } = new List<Goal>();

    [ForeignKey("ActionPlanId")]
    [InverseProperty("ActionPlans")]
    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

    [ForeignKey("ActionPlanId")]
    [InverseProperty("ActionPlansNavigation")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
