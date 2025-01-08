using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("faqs")]
public partial class Faq
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("company_id")]
    public int CompanyId { get; set; }

    [Column("title")]
    public string Title { get; set; } = null!;

    [Column("body")]
    public string Body { get; set; } = null!;

    [Column("created", TypeName = "datetime")]
    public DateTime Created { get; set; }

    [Column("updated", TypeName = "datetime")]
    public DateTime Updated { get; set; }

    [ForeignKey("CompanyId")]
    [InverseProperty("Faqs")]
    public virtual Company Company { get; set; } = null!;
}
