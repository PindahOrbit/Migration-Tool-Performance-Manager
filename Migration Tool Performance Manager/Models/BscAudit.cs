using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_audit")]
public partial class BscAudit
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("user_id", TypeName = "text")]
    public string UserId { get; set; }

    [Required]
    [Column("table_name", TypeName = "text")]
    public string TableName { get; set; }

    [Required]
    [Column("action", TypeName = "text")]
    public string Action { get; set; }

    [Column("old_value", TypeName = "text")]
    public string OldValue { get; set; }

    [Column("new_value", TypeName = "text")]
    public string NewValue { get; set; }

    [Column("date", TypeName = "timestamp")]
    public DateTime Date { get; set; }
}
