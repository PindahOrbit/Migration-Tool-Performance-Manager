using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_approvals")]
public partial class BscApproval
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("scorecard_id")]
    public int? ScorecardId { get; set; }

    [Column("owner_comment", TypeName = "text")]
    public string OwnerComment { get; set; }

    [Column("comment", TypeName = "text")]
    public string Comment { get; set; }

    [Column("status")]
    public int? Status { get; set; }

    [Column("start_date")]
    public DateOnly? StartDate { get; set; }

    [Column("end_date")]
    public DateOnly? EndDate { get; set; }

    [Column("created_at", TypeName = "timestamp")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp")]
    public DateTime? UpdatedAt { get; set; }
}
