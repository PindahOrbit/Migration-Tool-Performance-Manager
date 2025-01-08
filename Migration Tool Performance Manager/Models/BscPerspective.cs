using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_perspectives")]
public partial class BscPerspective
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("name", TypeName = "text")]
    public string Name { get; set; }

    [Required]
    [Column("description", TypeName = "text")]
    public string Description { get; set; }

    [Required]
    [Column("graph_color", TypeName = "text")]
    public string GraphColor { get; set; }

    [Required]
    [Column("fill", TypeName = "text")]
    public string Fill { get; set; }
}
