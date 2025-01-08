using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("SubordinateTestRecord")]
public partial class SubordinateTestRecord
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("Employee_Id")]
    [StringLength(450)]
    public string EmployeeId { get; set; } = null!;

    [Column("Supervisor_Id")]
    [StringLength(450)]
    public string SupervisorId { get; set; } = null!;

    [Column("Assessment_Id")]
    public int AssessmentId { get; set; }

    [Column("Date_Taken", TypeName = "datetime")]
    public DateTime DateTaken { get; set; }

    [ForeignKey("AssessmentId")]
    [InverseProperty("SubordinateTestRecords")]
    public virtual Assessment Assessment { get; set; } = null!;

    [ForeignKey("EmployeeId")]
    [InverseProperty("SubordinateTestRecordEmployees")]
    public virtual User Employee { get; set; } = null!;

    [InverseProperty("EmployeeTestRecord")]
    public virtual ICollection<SubordinateTestAnswer> SubordinateTestAnswers { get; set; } = new List<SubordinateTestAnswer>();

    [ForeignKey("SupervisorId")]
    [InverseProperty("SubordinateTestRecordSupervisors")]
    public virtual User Supervisor { get; set; } = null!;
}
