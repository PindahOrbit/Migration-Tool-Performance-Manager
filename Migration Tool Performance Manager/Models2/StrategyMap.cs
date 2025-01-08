using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

public partial class StrategyMap
{
    [Key]
    [Column("company_id")]
    public int CompanyId { get; set; }

    [Column("location")]
    [StringLength(450)]
    public string Location { get; set; } = null!;

    [ForeignKey("CompanyId")]
    [InverseProperty("StrategyMap")]
    public virtual Company Company { get; set; } = null!;
}
