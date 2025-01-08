using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_360_answer_scale")]
public partial class Bsc360AnswerScale
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("value", TypeName = "text")]
    public string Value { get; set; }

    [Required]
    [Column("text", TypeName = "text")]
    public string Text { get; set; }
}
