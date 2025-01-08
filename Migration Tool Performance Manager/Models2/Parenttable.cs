using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Keyless]
[Table("parenttables")]
public partial class Parenttable
{
    [Column("PARENT_TEAM")]
    public int? ParentTeam { get; set; }

    [Column("TEAM_ID")]
    public int TeamId { get; set; }

    [ForeignKey("ParentTeam")]
    public virtual Teamsokr? ParentTeamNavigation { get; set; }

    [ForeignKey("TeamId")]
    public virtual Teamsokr Team { get; set; } = null!;
}
