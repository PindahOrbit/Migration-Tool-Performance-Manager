using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_client")]
public partial class BscClient
{
    [Key]
    [Column("client_id")]
    public int ClientId { get; set; }

    [Required]
    [Column("client", TypeName = "text")]
    public string Client { get; set; }

    [Required]
    [Column("profile")]
    [StringLength(500)]
    public string Profile { get; set; }
}
