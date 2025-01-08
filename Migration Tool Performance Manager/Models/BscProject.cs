using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_projects")]
public partial class BscProject
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("client_id", TypeName = "text")]
    public string ClientId { get; set; }

    [Column("goal_id", TypeName = "text")]
    public string GoalId { get; set; }

    [Required]
    [Column("name", TypeName = "text")]
    public string Name { get; set; }

    [Column("description", TypeName = "text")]
    public string Description { get; set; }

    [Column("measure_of_success", TypeName = "text")]
    public string MeasureOfSuccess { get; set; }

    [Required]
    [Column("manager", TypeName = "text")]
    public string Manager { get; set; }

    [Column("start_date", TypeName = "text")]
    public string StartDate { get; set; }

    [Column("end_date", TypeName = "text")]
    public string EndDate { get; set; }

    [Column("weight")]
    [Precision(10, 2)]
    public decimal? Weight { get; set; }

    [Column("priority", TypeName = "text")]
    public string Priority { get; set; }

    [Column("reason", TypeName = "text")]
    public string Reason { get; set; }

    [Column("status")]
    public int Status { get; set; }

    [Column("created_at", TypeName = "timestamp")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp")]
    public DateTime? UpdatedAt { get; set; }

    [Column("document", TypeName = "text")]
    public string Document { get; set; }
}
