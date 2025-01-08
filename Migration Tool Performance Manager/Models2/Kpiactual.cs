using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("KPIActuals")]
public partial class Kpiactual
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("employee_id")]
    [StringLength(450)]
    public string EmployeeId { get; set; } = null!;

    [Column("MeasureUnit_Id")]
    public int MeasureUnitId { get; set; }

    [Column("company_id")]
    public int CompanyId { get; set; }

    public double? Actual { get; set; }

    public double Score { get; set; }

    [Column("date_recorded", TypeName = "datetime")]
    public DateTime DateRecorded { get; set; }

    [Column("frequency")]
    [StringLength(2)]
    public string Frequency { get; set; } = null!;

    [Column("bt")]
    public double Bt { get; set; }

    [Column("st")]
    public double St { get; set; }

    [Column("aw")]
    public double Aw { get; set; }

    [Column("tp")]
    [StringLength(3)]
    [Unicode(false)]
    public string? Tp { get; set; }

    [Column("scorecard_id")]
    public int ScorecardId { get; set; }

    [Column("evidence")]
    public string? Evidence { get; set; }

    [Column("is_template")]
    public bool IsTemplate { get; set; }

    [Column("date_updated", TypeName = "datetime")]
    public DateTime DateUpdated { get; set; }

    [ForeignKey("CompanyId")]
    [InverseProperty("Kpiactuals")]
    public virtual Company Company { get; set; } = null!;

    [ForeignKey("EmployeeId")]
    [InverseProperty("Kpiactuals")]
    public virtual User Employee { get; set; } = null!;

    [ForeignKey("MeasureUnitId")]
    [InverseProperty("Kpiactuals")]
    public virtual MeasureUnit MeasureUnit { get; set; } = null!;

    [ForeignKey("ScorecardId")]
    [InverseProperty("Kpiactuals")]
    public virtual Scorecard Scorecard { get; set; } = null!;
}
