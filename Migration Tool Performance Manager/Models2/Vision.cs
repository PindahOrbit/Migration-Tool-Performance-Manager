using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("vision")]
[Index("CompanyId", Name = "UQ__vision__3E26723408EAF00A", IsUnique = true)]
public partial class Vision
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("company_id")]
    public int CompanyId { get; set; }

    [ForeignKey("CompanyId")]
    [InverseProperty("Vision")]
    public virtual Company Company { get; set; } = null!;
}
