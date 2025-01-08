using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

public partial class SystemPayment
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("datemade", TypeName = "datetime")]
    public DateTime? Datemade { get; set; }

    [Column("reference")]
    public string? Reference { get; set; }

    [Column("cost")]
    public double? Cost { get; set; }

    [Column("pollurl")]
    public string? Pollurl { get; set; }

    [Column("link")]
    public string? Link { get; set; }
}
