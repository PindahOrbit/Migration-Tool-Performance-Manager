using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_monthly")]
public partial class BscMonthly
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("target_id", TypeName = "text")]
    public string TargetId { get; set; }

    [Column("month", TypeName = "text")]
    public string Month { get; set; }

    [Column("base_target", TypeName = "double(11,2)")]
    public double BaseTarget { get; set; }

    [Column("stretch_target", TypeName = "double(11,2)")]
    public double StretchTarget { get; set; }

    [Column("allocated_weight", TypeName = "double(10,5)")]
    public double AllocatedWeight { get; set; }

    [Column("amount", TypeName = "text")]
    public string Amount { get; set; }

    [Column("score", TypeName = "text")]
    public string Score { get; set; }

    [Column("variance", TypeName = "double(11,2)")]
    public double Variance { get; set; }

    [Column("evidence", TypeName = "text")]
    public string Evidence { get; set; }

    [Required]
    [Column("link", TypeName = "text")]
    public string Link { get; set; }

    [Column("date", TypeName = "timestamp")]
    public DateTime Date { get; set; }
}
