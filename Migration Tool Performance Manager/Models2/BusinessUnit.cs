using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("businessUnit")]
public partial class BusinessUnit
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("company_id")]
    public int? CompanyId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    public string? Description { get; set; }

    [Column("Department_ID")]
    public int? DepartmentId { get; set; }

    [Column("Manager_ID")]
    [StringLength(450)]
    public string? ManagerId { get; set; }

    [ForeignKey("CompanyId")]
    [InverseProperty("BusinessUnits")]
    public virtual Company? Company { get; set; }

    [ForeignKey("DepartmentId")]
    [InverseProperty("BusinessUnits")]
    public virtual Department? Department { get; set; }

    [InverseProperty("BusinessUnitNavigation")]
    public virtual ICollection<EmployeeDetail> EmployeeDetails { get; set; } = new List<EmployeeDetail>();

    [ForeignKey("ManagerId")]
    [InverseProperty("BusinessUnits")]
    public virtual User? Manager { get; set; }
}
