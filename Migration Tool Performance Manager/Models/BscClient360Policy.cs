using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_client_360_policy")]
public partial class BscClient360Policy
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("client_id", TypeName = "text")]
    public string ClientId { get; set; }

    [Column("mandatory")]
    public int Mandatory { get; set; }
}
