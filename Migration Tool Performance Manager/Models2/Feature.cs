using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

public partial class Feature
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("feature_name")]
    [StringLength(10)]
    [Unicode(false)]
    public string FeatureName { get; set; } = null!;

    [Column("feature_description")]
    public string FeatureDescription { get; set; } = null!;
}
