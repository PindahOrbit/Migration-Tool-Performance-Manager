using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("TEAMSOKR")]
public partial class Teamsokr
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("TITLE")]
    [StringLength(400)]
    public string Title { get; set; } = null!;

    [Column("TYPE")]
    [StringLength(400)]
    public string? Type { get; set; }

    [Column("OWNER")]
    [StringLength(450)]
    public string Owner { get; set; } = null!;

    [Column("DETAILS")]
    [StringLength(450)]
    public string? Details { get; set; }

    [InverseProperty("Team")]
    public virtual ICollection<KeyResult> KeyResults { get; set; } = new List<KeyResult>();

    [InverseProperty("Team")]
    public virtual ICollection<Objective> Objectives { get; set; } = new List<Objective>();

    [ForeignKey("Owner")]
    [InverseProperty("Teamsokrs")]
    public virtual User OwnerNavigation { get; set; } = null!;
}
