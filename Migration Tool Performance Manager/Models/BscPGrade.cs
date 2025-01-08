using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_p_grades")]
public partial class BscPGrade
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("name", TypeName = "text")]
    public string Name { get; set; }

    [Required]
    [Column("color", TypeName = "text")]
    public string Color { get; set; }
}
