using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_account_types")]
public partial class BscAccountType
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("level")]
    public int Level { get; set; }

    [Required]
    [Column("name", TypeName = "text")]
    public string Name { get; set; }

    [Required]
    [Column("model")]
    [StringLength(10)]
    public string Model { get; set; }

    [Required]
    [Column("group_name", TypeName = "text")]
    public string GroupName { get; set; }
}
