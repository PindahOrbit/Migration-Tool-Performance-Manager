using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("subscriptions")]
public partial class Subscription
{
    [Key]
    [Column("company_id")]
    public int CompanyId { get; set; }

    [Column("user_id")]
    [StringLength(450)]
    public string UserId { get; set; } = null!;

    [Column("status")]
    [StringLength(20)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [ForeignKey("CompanyId")]
    [InverseProperty("Subscription")]
    public virtual Company Company { get; set; } = null!;

    [InverseProperty("Subscription")]
    public virtual ICollection<SubscriptionDate> SubscriptionDates { get; set; } = new List<SubscriptionDate>();

    [ForeignKey("UserId")]
    [InverseProperty("Subscriptions")]
    public virtual User User { get; set; } = null!;
}
