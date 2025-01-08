using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_business_units")]
public partial class BscBusinessUnit
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("client_id", TypeName = "text")]
    public string ClientId { get; set; }

    [Required]
    [Column("name", TypeName = "text")]
    public string Name { get; set; }

    [Column("head", TypeName = "text")]
    public string Head { get; set; }
}
