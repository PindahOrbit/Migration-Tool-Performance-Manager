using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("settings_color_codes")]
public partial class SettingsColorCode
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("range_from")]
    public double RangeFrom { get; set; }

    [Column("description")]
    [StringLength(50)]
    public string Description { get; set; } = null!;

    [Column("range_to")]
    public double RangeTo { get; set; }

    [Column("color")]
    [StringLength(50)]
    public string Color { get; set; } = null!;

    [Column("company_id")]
    public int CompanyId { get; set; }

    [ForeignKey("CompanyId")]
    [InverseProperty("SettingsColorCodes")]
    public virtual Company Company { get; set; } = null!;
}
