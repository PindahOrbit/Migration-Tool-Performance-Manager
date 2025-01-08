using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_summary_ratings")]
public partial class BscSummaryRating
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("min_mark")]
    public int MinMark { get; set; }

    [Column("max_mark")]
    public int? MaxMark { get; set; }

    [Column("name", TypeName = "text")]
    public string Name { get; set; }

    [Required]
    [Column("description", TypeName = "text")]
    public string Description { get; set; }

    [Required]
    [Column("color", TypeName = "text")]
    public string Color { get; set; }
}
