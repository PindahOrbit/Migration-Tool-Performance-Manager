using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_project_status")]
public partial class BscProjectStatus
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("status", TypeName = "text")]
    public string Status { get; set; }

    [Required]
    [Column("color", TypeName = "text")]
    public string Color { get; set; }
}
