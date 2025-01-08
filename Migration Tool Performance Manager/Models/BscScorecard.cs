using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_scorecards")]
public partial class BscScorecard
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("client_id", TypeName = "text")]
    public string ClientId { get; set; }

    [Column("owner", TypeName = "text")]
    public string Owner { get; set; }

    [Column("reporting_period", TypeName = "text")]
    public string ReportingPeriod { get; set; }

    [Column("start", TypeName = "text")]
    public string Start { get; set; }

    [Column("status")]
    public int Status { get; set; }

    [Column("last_update", TypeName = "timestamp")]
    public DateTime LastUpdate { get; set; }

    [Column("date", TypeName = "timestamp")]
    public DateTime Date { get; set; }

    [Required]
    [Column("lock1")]
    [StringLength(5)]
    public string Lock1 { get; set; }
}
