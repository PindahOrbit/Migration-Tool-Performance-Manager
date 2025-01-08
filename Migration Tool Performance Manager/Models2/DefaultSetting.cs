using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

public partial class DefaultSetting
{
    [Key]
    [Column("code")]
    public int Code { get; set; }

    [Column("name")]
    [StringLength(450)]
    public string Name { get; set; } = null!;

    [Column("date_created", TypeName = "datetime")]
    public DateTime DateCreated { get; set; }

    [Column("structure")]
    public string Structure { get; set; } = null!;

    [Column("editable")]
    public bool Editable { get; set; }

    [InverseProperty("Defaultsetting")]
    public virtual ICollection<Setting> Settings { get; set; } = new List<Setting>();
}
