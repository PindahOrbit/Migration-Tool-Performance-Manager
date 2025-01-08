using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_360_questions")]
public partial class Bsc360Question
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("step_id", TypeName = "text")]
    public string StepId { get; set; }

    [Required]
    [Column("dimension", TypeName = "text")]
    public string Dimension { get; set; }

    [Required]
    [Column("question", TypeName = "text")]
    public string Question { get; set; }
}
