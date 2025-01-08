using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_individual_reports")]
public partial class BscIndividualReport
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("owner")]
    public int? Owner { get; set; }

    [Column("scorecard_id")]
    public int? ScorecardId { get; set; }

    [Column("owner_signature", TypeName = "text")]
    public string OwnerSignature { get; set; }

    [Column("supervisor_signature", TypeName = "text")]
    public string SupervisorSignature { get; set; }

    [Column("hr_signature", TypeName = "text")]
    public string HrSignature { get; set; }

    [Column("created_at", TypeName = "timestamp")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp")]
    public DateTime? UpdatedAt { get; set; }

    [Column("owner_date_signed")]
    public DateOnly? OwnerDateSigned { get; set; }

    [Column("supervisor_date_signed")]
    public DateOnly? SupervisorDateSigned { get; set; }

    [Column("hr_date_signed")]
    public DateOnly? HrDateSigned { get; set; }
}
