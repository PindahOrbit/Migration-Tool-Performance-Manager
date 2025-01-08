using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_max_scorecards")]
public partial class BscMaxScorecard
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("client_id")]
    public int ClientId { get; set; }

    [Required]
    [Column("code", TypeName = "text")]
    public string Code { get; set; }

    [Required]
    [Column("start_date", TypeName = "text")]
    public string StartDate { get; set; }

    [Required]
    [Column("end_date", TypeName = "text")]
    public string EndDate { get; set; }

    [Required]
    [Column("max_scorecards", TypeName = "text")]
    public string MaxScorecards { get; set; }

    [Column("last_updated", TypeName = "timestamp")]
    public DateTime LastUpdated { get; set; }
}
