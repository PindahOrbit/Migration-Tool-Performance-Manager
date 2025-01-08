using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_reports")]
[MySqlCharSet("utf8mb4")]
[MySqlCollation("utf8mb4_general_ci")]
public partial class BscReport
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("name", TypeName = "text")]
    public string Name { get; set; }

    [Required]
    [Column("start_date", TypeName = "text")]
    public string StartDate { get; set; }

    [Required]
    [Column("end_date", TypeName = "text")]
    public string EndDate { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [Column("date", TypeName = "timestamp")]
    public DateTime? Date { get; set; }
}
