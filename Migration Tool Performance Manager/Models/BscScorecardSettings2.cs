using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_scorecard_settings2")]
public partial class BscScorecardSettings2
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("client_id")]
    public int ClientId { get; set; }

    [Column("department_id")]
    public int DepartmentId { get; set; }

    [Required]
    [Column("status")]
    [StringLength(5)]
    public string Status { get; set; }
}
