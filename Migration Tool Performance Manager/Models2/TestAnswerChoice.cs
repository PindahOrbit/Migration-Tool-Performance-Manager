using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

public partial class TestAnswerChoice
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("Question_Id")]
    public int QuestionId { get; set; }

    public string Description { get; set; } = null!;

    [ForeignKey("QuestionId")]
    [InverseProperty("TestAnswerChoices")]
    public virtual AssessmentQuestion Question { get; set; } = null!;
}
