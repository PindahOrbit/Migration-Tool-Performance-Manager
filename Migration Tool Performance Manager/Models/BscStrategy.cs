using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_strategy")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_general_ci")]
public partial class BscStrategy
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("vision", TypeName = "text")]
    public string Vision { get; set; }

    [Column("mission")]
    public string Mission { get; set; }

    [Column("our_values", TypeName = "text")]
    public string OurValues { get; set; }

    [Column("map")]
    public int? Map { get; set; }

    [Column("created_at", TypeName = "timestamp")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at", TypeName = "timestamp")]
    public DateTime? DeletedAt { get; set; }
}
