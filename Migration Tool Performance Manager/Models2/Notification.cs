using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("notifications")]
public partial class Notification
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("datecreated", TypeName = "datetime")]
    public DateTime Datecreated { get; set; }

    [Column("source_user")]
    [StringLength(450)]
    public string? SourceUser { get; set; }

    [Column("target_user")]
    [StringLength(450)]
    public string? TargetUser { get; set; }

    [Column("company_id")]
    public int CompanyId { get; set; }

    [Column("message")]
    public string? Message { get; set; }

    [Column("seen")]
    public bool? Seen { get; set; }

    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("item_type")]
    [StringLength(50)]
    public string ItemType { get; set; } = null!;

    [Column("urgency")]
    [StringLength(50)]
    public string Urgency { get; set; } = null!;

    [ForeignKey("SourceUser")]
    [InverseProperty("NotificationSourceUserNavigations")]
    public virtual User? SourceUserNavigation { get; set; }

    [ForeignKey("TargetUser")]
    [InverseProperty("NotificationTargetUserNavigations")]
    public virtual User? TargetUserNavigation { get; set; }
}
