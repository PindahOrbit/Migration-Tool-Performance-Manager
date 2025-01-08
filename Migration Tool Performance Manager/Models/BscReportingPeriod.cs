using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_reporting_periods")]
public partial class BscReportingPeriod
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("start_date", TypeName = "text")]
    public string StartDate { get; set; }

    [Required]
    [Column("end_date", TypeName = "text")]
    public string EndDate { get; set; }

    [Column("date", TypeName = "timestamp")]
    public DateTime Date { get; set; }
}
