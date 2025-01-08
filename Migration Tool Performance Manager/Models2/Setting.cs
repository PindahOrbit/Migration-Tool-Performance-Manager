using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("settings")]
public partial class Setting
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("company_id")]
    public int CompanyId { get; set; }

    [Column("defaultsetting_id")]
    public int DefaultsettingId { get; set; }

    [Column("content")]
    public string? Content { get; set; }

    [Column("editable")]
    public bool Editable { get; set; }

    [ForeignKey("CompanyId")]
    [InverseProperty("Settings")]
    public virtual Company Company { get; set; } = null!;

    [ForeignKey("DefaultsettingId")]
    [InverseProperty("Settings")]
    public virtual DefaultSetting Defaultsetting { get; set; } = null!;
}
