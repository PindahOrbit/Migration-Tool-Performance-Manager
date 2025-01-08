using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_task_comments")]
public partial class BscTaskComment
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("scorecard_id")]
    public int? ScorecardId { get; set; }

    [Column("project_id", TypeName = "text")]
    public string ProjectId { get; set; }

    [Column("scope", TypeName = "text")]
    public string Scope { get; set; }

    [Column("comment", TypeName = "text")]
    public string Comment { get; set; }

    [Column("sender")]
    public int? Sender { get; set; }

    [Column("date", TypeName = "timestamp")]
    public DateTime? Date { get; set; }

    [Column("updated_time", TypeName = "timestamp")]
    public DateTime? UpdatedTime { get; set; }

    [Column("status")]
    public int Status { get; set; }
}
