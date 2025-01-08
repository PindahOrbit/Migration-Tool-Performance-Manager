using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_project_tasks")]
public partial class BscProjectTask
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("project_id", TypeName = "text")]
    public string ProjectId { get; set; }

    [Column("assigned")]
    public int? Assigned { get; set; }

    [Required]
    [Column("task", TypeName = "text")]
    public string Task { get; set; }

    [Column("measure_of_success", TypeName = "text")]
    public string MeasureOfSuccess { get; set; }

    [Column("status")]
    public int Status { get; set; }

    [Column("completion")]
    public int? Completion { get; set; }

    [Column("document", TypeName = "text")]
    public string Document { get; set; }

    [Column("link", TypeName = "text")]
    public string Link { get; set; }

    [Column("start_date", TypeName = "timestamp")]
    public DateTime StartDate { get; set; }

    [Column("due_date")]
    public DateOnly? DueDate { get; set; }

    [Column("last_updated", TypeName = "timestamp")]
    public DateTime LastUpdated { get; set; }

    [Column("aw")]
    public int Aw { get; set; }

    [Column("impact", TypeName = "text")]
    public string Impact { get; set; }

    [Column("quality", TypeName = "text")]
    public string Quality { get; set; }

    [Column("budget")]
    public double? Budget { get; set; }

    [Column("actual_cost")]
    public double? ActualCost { get; set; }

    [Column("resourcing_status", TypeName = "text")]
    public string ResourcingStatus { get; set; }

    [Column("exceptions", TypeName = "text")]
    public string Exceptions { get; set; }

    [Column("comments", TypeName = "text")]
    public string Comments { get; set; }

    [Column("code", TypeName = "text")]
    public string Code { get; set; }

    [Column("completion_date")]
    public DateOnly? CompletionDate { get; set; }
}
