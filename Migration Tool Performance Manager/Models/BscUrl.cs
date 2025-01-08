using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_url")]
public partial class BscUrl
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("domainEmail", TypeName = "text")]
    public string DomainEmail { get; set; }

    [Required]
    [Column("url", TypeName = "text")]
    public string Url { get; set; }

    [Required]
    [Column("full_link", TypeName = "text")]
    public string FullLink { get; set; }
}
