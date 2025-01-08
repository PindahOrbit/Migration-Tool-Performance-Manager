using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("PROJECTS")]
public partial class Project
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("creator_id")]
    [StringLength(450)]
    public string CreatorId { get; set; } = null!;

    [Column("delegate_id")]
    [StringLength(450)]
    public string DelegateId { get; set; } = null!;

    [Column("objective_id")]
    public int? ObjectiveId { get; set; }

    [Column("title")]
    [StringLength(400)]
    public string Title { get; set; } = null!;

    [Column("type")]
    [StringLength(13)]
    public string Type { get; set; } = null!;

    [Column("period")]
    [StringLength(13)]
    public string Period { get; set; } = null!;

    [Column("description")]
    [StringLength(500)]
    public string? Description { get; set; }

    [Column("progress_number")]
    public double ProgressNumber { get; set; }

    [Column("progress")]
    [StringLength(13)]
    public string Progress { get; set; } = null!;

    [ForeignKey("CreatorId")]
    [InverseProperty("ProjectCreators")]
    public virtual User Creator { get; set; } = null!;

    [ForeignKey("DelegateId")]
    [InverseProperty("ProjectDelegates")]
    public virtual User Delegate { get; set; } = null!;

    [ForeignKey("ObjectiveId")]
    [InverseProperty("Projects")]
    public virtual Objective? Objective { get; set; }
}
