using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_360_responses")]
public partial class Bsc360Response
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("employee_id", TypeName = "text")]
    public string EmployeeId { get; set; }

    [Column("assessor_id")]
    public int AssessorId { get; set; }

    [Required]
    [Column("question_id", TypeName = "text")]
    public string QuestionId { get; set; }

    [Required]
    [Column("value", TypeName = "text")]
    public string Value { get; set; }

    [Required]
    [Column("comment", TypeName = "text")]
    public string Comment { get; set; }

    [Column("date", TypeName = "timestamp")]
    public DateTime Date { get; set; }

    [Column("start_date")]
    public DateOnly? StartDate { get; set; }

    [Column("end_date")]
    public DateOnly? EndDate { get; set; }
}
