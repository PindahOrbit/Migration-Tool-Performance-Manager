using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_notification_status")]
public partial class BscNotificationStatus
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("status")]
    public int Status { get; set; }

    [Required]
    [Column("status_name")]
    [StringLength(100)]
    public string StatusName { get; set; }
}
