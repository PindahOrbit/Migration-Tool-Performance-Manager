using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("objectives")]
public partial class Objective
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("creator_id")]
    [StringLength(450)]
    public string CreatorId { get; set; } = null!;

    [Column("strategic_focus_area_id")]
    public int? StrategicFocusAreaId { get; set; }

    [Column("delegate_id")]
    [StringLength(450)]
    public string? DelegateId { get; set; }

    [Column("team_id")]
    public int? TeamId { get; set; }

    [Column("datecreated", TypeName = "datetime")]
    public DateTime Datecreated { get; set; }

    [Column("title")]
    [StringLength(400)]
    public string Title { get; set; } = null!;

    [Column("type")]
    [StringLength(13)]
    public string Type { get; set; } = null!;

    [Column("period")]
    [StringLength(13)]
    public string Period { get; set; } = null!;

    [Column("periodfrom", TypeName = "datetime")]
    public DateTime Periodfrom { get; set; }

    [Column("periodto", TypeName = "datetime")]
    public DateTime Periodto { get; set; }

    [Column("description")]
    [StringLength(500)]
    public string? Description { get; set; }

    [Column("parent_objective")]
    public int? ParentObjective { get; set; }

    [Column("progress_number")]
    public double ProgressNumber { get; set; }

    [Column("progress")]
    [StringLength(13)]
    public string Progress { get; set; } = null!;

    [ForeignKey("CreatorId")]
    [InverseProperty("ObjectiveCreators")]
    public virtual User Creator { get; set; } = null!;

    [ForeignKey("DelegateId")]
    [InverseProperty("ObjectiveDelegates")]
    public virtual User? Delegate { get; set; }

    [InverseProperty("ParentObjectiveNavigation")]
    public virtual ICollection<Objective> InverseParentObjectiveNavigation { get; set; } = new List<Objective>();

    [InverseProperty("Objective")]
    public virtual ICollection<KeyResult> KeyResults { get; set; } = new List<KeyResult>();

    [ForeignKey("ParentObjective")]
    [InverseProperty("InverseParentObjectiveNavigation")]
    public virtual Objective? ParentObjectiveNavigation { get; set; }

    [InverseProperty("Objective")]
    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    [ForeignKey("StrategicFocusAreaId")]
    [InverseProperty("Objectives")]
    public virtual Perspective? StrategicFocusArea { get; set; }

    [ForeignKey("TeamId")]
    [InverseProperty("Objectives")]
    public virtual Teamsokr? Team { get; set; }
}
