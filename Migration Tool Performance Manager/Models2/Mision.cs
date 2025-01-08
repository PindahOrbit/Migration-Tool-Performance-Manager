using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("mision")]
[Index("CompanyId", Name = "UQ__mision__3E267234E4FB611D", IsUnique = true)]
public partial class Mision
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("company_id")]
    public int CompanyId { get; set; }

    [ForeignKey("CompanyId")]
    [InverseProperty("Mision")]
    public virtual Company Company { get; set; } = null!;
}
