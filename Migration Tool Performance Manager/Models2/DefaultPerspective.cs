using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

public partial class DefaultPerspective
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [Unicode(false)]
    public string Name { get; set; } = null!;
}
