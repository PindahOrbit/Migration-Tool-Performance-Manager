using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_pep_check_list")]
public partial class BscPepCheckList
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("pep_id")]
    public int PepId { get; set; }

    [Required]
    [Column("list", TypeName = "text")]
    public string List { get; set; }

    [Required]
    [Column("due_date", TypeName = "text")]
    public string DueDate { get; set; }

    [Column("last_updated", TypeName = "timestamp")]
    public DateTime LastUpdated { get; set; }

    [Column("status")]
    public int Status { get; set; }

    [Column("date", TypeName = "timestamp")]
    public DateTime Date { get; set; }
}
