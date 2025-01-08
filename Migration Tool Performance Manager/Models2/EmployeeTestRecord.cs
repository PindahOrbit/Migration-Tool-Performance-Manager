using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("EmployeeTestRecord")]
public partial class EmployeeTestRecord
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("Employee_Id")]
    [StringLength(450)]
    public string EmployeeId { get; set; } = null!;

    [Column("Assessment_Id")]
    public int AssessmentId { get; set; }

    [Column("Date_Taken", TypeName = "datetime")]
    public DateTime DateTaken { get; set; }

    [ForeignKey("AssessmentId")]
    [InverseProperty("EmployeeTestRecords")]
    public virtual Assessment Assessment { get; set; } = null!;

    [ForeignKey("EmployeeId")]
    [InverseProperty("EmployeeTestRecords")]
    public virtual User Employee { get; set; } = null!;

    [InverseProperty("EmployeeTestRecord")]
    public virtual ICollection<EmployeeTestAnswer> EmployeeTestAnswers { get; set; } = new List<EmployeeTestAnswer>();
}
