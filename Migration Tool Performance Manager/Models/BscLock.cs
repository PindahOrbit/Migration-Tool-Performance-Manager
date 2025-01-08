using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_locks")]
public partial class BscLock
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("scorecard_id")]
    public int? ScorecardId { get; set; }

    [Column("admin_id")]
    public int? AdminId { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("date_created", TypeName = "timestamp")]
    public DateTime? DateCreated { get; set; }

    [Column("updated_time", TypeName = "timestamp")]
    public DateTime? UpdatedTime { get; set; }
}
