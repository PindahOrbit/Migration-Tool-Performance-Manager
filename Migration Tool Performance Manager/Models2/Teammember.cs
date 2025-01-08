using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Keyless]
[Table("TEAMMEMBERS")]
public partial class Teammember
{
    [Column("TEAM_ID")]
    public int TeamId { get; set; }

    [Column("MEMEBER_ID")]
    [StringLength(450)]
    public string MemeberId { get; set; } = null!;

    [ForeignKey("MemeberId")]
    public virtual User Memeber { get; set; } = null!;

    [ForeignKey("TeamId")]
    public virtual Teamsokr Team { get; set; } = null!;
}
