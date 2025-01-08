using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_client_notifications")]
public partial class BscClientNotification
{
    [Key]
    [Column("notifications_id")]
    public int NotificationsId { get; set; }

    [Required]
    [Column("client_id")]
    [StringLength(100)]
    public string ClientId { get; set; }

    [Column("user")]
    public int User { get; set; }

    [Required]
    [Column("subject")]
    [StringLength(200)]
    public string Subject { get; set; }

    [Required]
    [Column("message")]
    [StringLength(500)]
    public string Message { get; set; }

    [Column("status")]
    public int Status { get; set; }

    [Column("date_time", TypeName = "timestamp")]
    public DateTime DateTime { get; set; }
}
