using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_watch_list")]
public partial class BscWatchList
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("maximum")]
    public int Maximum { get; set; }

    [Column("last_update", TypeName = "timestamp")]
    public DateTime LastUpdate { get; set; }
}
