using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_pep")]
public partial class BscPep
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [Required]
    [Column("scorecard_id", TypeName = "text")]
    public string ScorecardId { get; set; }

    [Required]
    [Column("reason", TypeName = "text")]
    public string Reason { get; set; }

    [Required]
    [Column("description", TypeName = "text")]
    public string Description { get; set; }

    [Column("date", TypeName = "timestamp")]
    public DateTime Date { get; set; }
}
