using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("subscription_dates")]
public partial class SubscriptionDate
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("feature_name")]
    [StringLength(10)]
    [Unicode(false)]
    public string FeatureName { get; set; } = null!;

    [Column("subscription_id")]
    public int SubscriptionId { get; set; }

    [Column("start_date")]
    public DateOnly StartDate { get; set; }

    [Column("end_date")]
    public DateOnly EndDate { get; set; }

    [Column("status")]
    [StringLength(20)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [Column("pollurl")]
    [Unicode(false)]
    public string? Pollurl { get; set; }

    [Column("linkurl")]
    [Unicode(false)]
    public string? Linkurl { get; set; }

    [ForeignKey("FeatureName")]
    [InverseProperty("SubscriptionDates")]
    public virtual FeatureCost FeatureNameNavigation { get; set; } = null!;

    [ForeignKey("SubscriptionId")]
    [InverseProperty("SubscriptionDates")]
    public virtual Subscription Subscription { get; set; } = null!;
}
