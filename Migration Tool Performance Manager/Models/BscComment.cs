using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_comments")]
public partial class BscComment
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("scorecard_id", TypeName = "text")]
    public string ScorecardId { get; set; }

    [Column("measure_id", TypeName = "text")]
    public string MeasureId { get; set; }

    [Column("scope", TypeName = "text")]
    public string Scope { get; set; }

    [Column("comment", TypeName = "text")]
    public string Comment { get; set; }

    [Column("supervisor_comment", TypeName = "text")]
    public string SupervisorComment { get; set; }

    [Column("sender", TypeName = "text")]
    public string Sender { get; set; }

    [Column("period")]
    public DateOnly? Period { get; set; }

    [Column("date", TypeName = "timestamp")]
    public DateTime? Date { get; set; }

    [Column("updated_time", TypeName = "timestamp")]
    public DateTime? UpdatedTime { get; set; }

    [Column("status")]
    public int Status { get; set; }
}
