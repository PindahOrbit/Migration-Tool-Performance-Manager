using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

public partial class SubordinateTestAnswer
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("EmployeeTestRecord_Id")]
    public int EmployeeTestRecordId { get; set; }

    [Column("Question_Id")]
    public int QuestionId { get; set; }

    public string Choice { get; set; } = null!;

    public int ChoiceId { get; set; }

    public bool Correct { get; set; }

    [Column("Employee_Id")]
    [StringLength(450)]
    public string EmployeeId { get; set; } = null!;

    [Column("Supervisor_Id")]
    [StringLength(450)]
    public string SupervisorId { get; set; } = null!;

    [ForeignKey("EmployeeId")]
    [InverseProperty("SubordinateTestAnswerEmployees")]
    public virtual User Employee { get; set; } = null!;

    [ForeignKey("EmployeeTestRecordId")]
    [InverseProperty("SubordinateTestAnswers")]
    public virtual SubordinateTestRecord EmployeeTestRecord { get; set; } = null!;

    [ForeignKey("QuestionId")]
    [InverseProperty("SubordinateTestAnswers")]
    public virtual AssessmentQuestion Question { get; set; } = null!;

    [ForeignKey("SupervisorId")]
    [InverseProperty("SubordinateTestAnswerSupervisors")]
    public virtual User Supervisor { get; set; } = null!;
}
