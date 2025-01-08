using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("Feature_Costs")]
[Index("FeatureName", Name = "UQ__Feature___96AE15E8BE9AF474", IsUnique = true)]
public partial class FeatureCost
{
    [Key]
    [Column("feature_name")]
    [StringLength(10)]
    [Unicode(false)]
    public string FeatureName { get; set; } = null!;

    [Column("feature_cost")]
    public double FeatureCost1 { get; set; }

    [InverseProperty("FeatureNameNavigation")]
    public virtual ICollection<SubscriptionDate> SubscriptionDates { get; set; } = new List<SubscriptionDate>();
}
