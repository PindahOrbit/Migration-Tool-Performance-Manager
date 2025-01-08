using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

public partial class EmployeeTestAnswer
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

    [ForeignKey("EmployeeId")]
    [InverseProperty("EmployeeTestAnswers")]
    public virtual User Employee { get; set; } = null!;

    [ForeignKey("EmployeeTestRecordId")]
    [InverseProperty("EmployeeTestAnswers")]
    public virtual EmployeeTestRecord EmployeeTestRecord { get; set; } = null!;

    [ForeignKey("QuestionId")]
    [InverseProperty("EmployeeTestAnswers")]
    public virtual AssessmentQuestion Question { get; set; } = null!;
}
