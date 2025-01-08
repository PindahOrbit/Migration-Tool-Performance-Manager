using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_scores")]
public partial class BscScore
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [Column("scorecard_id")]
    public int ScorecardId { get; set; }

    [Column("score", TypeName = "double(11,2)")]
    public double Score { get; set; }

    [Column("updated_on", TypeName = "timestamp")]
    public DateTime UpdatedOn { get; set; }

    [Column("date", TypeName = "timestamp")]
    public DateTime Date { get; set; }
}
