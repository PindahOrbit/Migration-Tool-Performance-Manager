using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

public partial class EmployeeDetail
{
    [Column("company_id")]
    public int CompanyId { get; set; }

    [Key]
    [Column("employee_id")]
    public string EmployeeId { get; set; } = null!;

    [Column("supervisor_id")]
    [StringLength(450)]
    public string SupervisorId { get; set; } = null!;

    [Column("position")]
    public string? Position { get; set; }

    [Column("businessUnit")]
    public int? BusinessUnit { get; set; }

    public bool IsCooperate { get; set; }

    [Column("defaultlogin")]
    public bool Defaultlogin { get; set; }

    [Column("signature")]
    [Unicode(false)]
    public string? Signature { get; set; }

    [Column("workforcenumber")]
    [StringLength(50)]
    public string? Workforcenumber { get; set; }

    [Column("team_id")]
    public int? TeamId { get; set; }

    [Column("date_created", TypeName = "datetime")]
    public DateTime DateCreated { get; set; }

    [Column("department_id")]
    public int? DepartmentId { get; set; }

    [Column("see_watchlist")]
    public bool SeeWatchlist { get; set; }

    [Column("see_home_only")]
    public int SeeHomeOnly { get; set; }

    [Column("see_all_homes")]
    public bool SeeAllHomes { get; set; }

    [ForeignKey("BusinessUnit")]
    [InverseProperty("EmployeeDetails")]
    public virtual BusinessUnit? BusinessUnitNavigation { get; set; }

    [ForeignKey("CompanyId")]
    [InverseProperty("EmployeeDetails")]
    public virtual Company Company { get; set; } = null!;

    [ForeignKey("DepartmentId")]
    [InverseProperty("EmployeeDetails")]
    public virtual Department? Department { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("EmployeeDetailEmployee")]
    public virtual User Employee { get; set; } = null!;

    [ForeignKey("SupervisorId")]
    [InverseProperty("EmployeeDetailSupervisors")]
    public virtual User Supervisor { get; set; } = null!;

    [ForeignKey("TeamId")]
    [InverseProperty("EmployeeDetails")]
    public virtual Team? Team { get; set; }
}
