using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("departments")]
public partial class Department
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("company_id")]
    public int CompanyId { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("manager_id")]
    [StringLength(450)]
    public string? ManagerId { get; set; }

    [InverseProperty("Department")]
    public virtual ICollection<BusinessUnit> BusinessUnits { get; set; } = new List<BusinessUnit>();

    [ForeignKey("CompanyId")]
    [InverseProperty("Departments")]
    public virtual Company Company { get; set; } = null!;

    [InverseProperty("Department")]
    public virtual ICollection<EmployeeDetail> EmployeeDetails { get; set; } = new List<EmployeeDetail>();

    [ForeignKey("ManagerId")]
    [InverseProperty("Departments")]
    public virtual User? Manager { get; set; }

    [InverseProperty("Department")]
    public virtual ICollection<TeamGoal> TeamGoals { get; set; } = new List<TeamGoal>();

    [InverseProperty("Department")]
    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
