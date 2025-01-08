using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[PrimaryKey("RoleId", "CompanyId")]
public partial class CompanyRole
{
    [Key]
    [Column("Role_ID")]
    public string RoleId { get; set; } = null!;

    [Key]
    [Column("Company_ID")]
    public int CompanyId { get; set; }

    [Column("rolename")]
    [StringLength(250)]
    [Unicode(false)]
    public string? Rolename { get; set; }

    [ForeignKey("CompanyId")]
    [InverseProperty("CompanyRoles")]
    public virtual Company Company { get; set; } = null!;

    [ForeignKey("RoleId")]
    [InverseProperty("CompanyRoles")]
    public virtual Role Role { get; set; } = null!;
}
