using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[PrimaryKey("ManagerRole", "SubordinateRole")]
public partial class SupervisoryRole
{
    [Column("id")]
    public int Id { get; set; }

    [Key]
    public string ManagerRole { get; set; } = null!;

    [Key]
    public string SubordinateRole { get; set; } = null!;

    [ForeignKey("ManagerRole")]
    [InverseProperty("SupervisoryRoleManagerRoleNavigations")]
    public virtual Role ManagerRoleNavigation { get; set; } = null!;

    [ForeignKey("SubordinateRole")]
    [InverseProperty("SupervisoryRoleSubordinateRoleNavigations")]
    public virtual Role SubordinateRoleNavigation { get; set; } = null!;
}
