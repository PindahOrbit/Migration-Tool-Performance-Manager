using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_accounts_notifications")]
public partial class BscAccountsNotification
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user")]
    public int User { get; set; }

    [Required]
    [Column("subject", TypeName = "text")]
    public string Subject { get; set; }

    [Required]
    [Column("message", TypeName = "text")]
    public string Message { get; set; }

    [Column("status")]
    public int Status { get; set; }

    [Column("date_time", TypeName = "timestamp")]
    public DateTime DateTime { get; set; }
}
