using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[PrimaryKey("Id", "PerspectiveId")]
[Table("Perspective_allocation")]
public partial class PerspectiveAllocation
{
    [Key]
    public int Id { get; set; }

    [Column("Company_id")]
    public int? CompanyId { get; set; }

    [Key]
    [Column("Perspective_id")]
    public int PerspectiveId { get; set; }

    [Column("Allocated_weight")]
    public double? AllocatedWeight { get; set; }

    [ForeignKey("CompanyId")]
    [InverseProperty("PerspectiveAllocations")]
    public virtual Company? Company { get; set; }

    [ForeignKey("PerspectiveId")]
    [InverseProperty("PerspectiveAllocations")]
    public virtual Perspective Perspective { get; set; } = null!;
}
