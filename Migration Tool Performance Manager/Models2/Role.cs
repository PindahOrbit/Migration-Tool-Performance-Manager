using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

public partial class Role
{
    [Key]
    public string Id { get; set; } = null!;

    [StringLength(256)]
    public string? Name { get; set; }

    [StringLength(256)]
    public string? NormalizedName { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? Description { get; set; }

    [Column("level")]
    public int Level { get; set; }

    [InverseProperty("Role")]
    public virtual ICollection<CompanyRole> CompanyRoles { get; set; } = new List<CompanyRole>();

    [InverseProperty("Role")]
    public virtual ICollection<RoleClaim> RoleClaims { get; set; } = new List<RoleClaim>();

    [InverseProperty("ManagerRoleNavigation")]
    public virtual ICollection<SupervisoryRole> SupervisoryRoleManagerRoleNavigations { get; set; } = new List<SupervisoryRole>();

    [InverseProperty("SubordinateRoleNavigation")]
    public virtual ICollection<SupervisoryRole> SupervisoryRoleSubordinateRoleNavigations { get; set; } = new List<SupervisoryRole>();

    [ForeignKey("RoleId")]
    [InverseProperty("Roles")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
