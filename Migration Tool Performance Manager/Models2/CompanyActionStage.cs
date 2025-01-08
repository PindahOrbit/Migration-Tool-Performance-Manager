using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[PrimaryKey("CompanyId", "StageId")]
[Table("company_action_stages")]
public partial class CompanyActionStage
{
    [Key]
    [Column("company_id")]
    public int CompanyId { get; set; }

    [Key]
    [Column("stage_id")]
    public int StageId { get; set; }

    [Column("color")]
    [StringLength(50)]
    public string Color { get; set; } = null!;

    [ForeignKey("CompanyId")]
    [InverseProperty("CompanyActionStages")]
    public virtual Company Company { get; set; } = null!;

    [ForeignKey("StageId")]
    [InverseProperty("CompanyActionStages")]
    public virtual ActionPlanStage Stage { get; set; } = null!;
}
