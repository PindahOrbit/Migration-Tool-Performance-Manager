using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_scorecard_settings")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_general_ci")]
public partial class BscScorecardSetting
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("client_id")]
    public int? ClientId { get; set; }

    [Column("status")]
    public int? Status { get; set; }
}
