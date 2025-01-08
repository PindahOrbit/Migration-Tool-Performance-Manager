using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_report_groups")]
[MySqlCharSet("utf8mb4")]
[MySqlCollation("utf8mb4_general_ci")]
public partial class BscReportGroup
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("report_id")]
    public int ReportId { get; set; }

    [Required]
    [Column("group_name", TypeName = "text")]
    public string GroupName { get; set; }

    [Required]
    [Column("participants", TypeName = "text")]
    public string Participants { get; set; }

    [Column("observations", TypeName = "text")]
    public string Observations { get; set; }

    [Column("recommendations", TypeName = "text")]
    public string Recommendations { get; set; }
}
