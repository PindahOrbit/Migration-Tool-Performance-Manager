using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

public partial class AssessmentQuestion
{
    [Key]
    [Column("Question_Id")]
    public int QuestionId { get; set; }

    [Column("Assessment_Id")]
    public int AssessmentId { get; set; }

    public string Details { get; set; } = null!;

    public string Answer { get; set; } = null!;

    [ForeignKey("AssessmentId")]
    [InverseProperty("AssessmentQuestions")]
    public virtual Assessment Assessment { get; set; } = null!;

    [InverseProperty("Question")]
    public virtual ICollection<ColleagueTestAnswer> ColleagueTestAnswers { get; set; } = new List<ColleagueTestAnswer>();

    [InverseProperty("Question")]
    public virtual ICollection<EmployeeTestAnswer> EmployeeTestAnswers { get; set; } = new List<EmployeeTestAnswer>();

    [InverseProperty("Question")]
    public virtual ICollection<SubordinateTestAnswer> SubordinateTestAnswers { get; set; } = new List<SubordinateTestAnswer>();

    [InverseProperty("Question")]
    public virtual ICollection<TestAnswerChoice> TestAnswerChoices { get; set; } = new List<TestAnswerChoice>();
}
