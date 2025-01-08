using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("summaryreports")]
public partial class Summaryreport
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("company_id")]
    public int CompanyId { get; set; }

    [Column("datecreated", TypeName = "datetime")]
    public DateTime Datecreated { get; set; }

    [Column("periodfrom", TypeName = "datetime")]
    public DateTime Periodfrom { get; set; }

    [Column("periodto", TypeName = "datetime")]
    public DateTime Periodto { get; set; }

    [Column("purpose")]
    public string? Purpose { get; set; }

    [Column("name")]
    public string Name { get; set; } = null!;

    [ForeignKey("CompanyId")]
    [InverseProperty("Summaryreports")]
    public virtual Company Company { get; set; } = null!;

    [ForeignKey("ReportId")]
    [InverseProperty("Reports")]
    public virtual ICollection<User> Owners { get; set; } = new List<User>();
}
