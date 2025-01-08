using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Keyless]
[Table("bsc_signatures")]
public partial class BscSignature
{
    [Column("id")]
    public int Id { get; set; }

    [Column("created_at")]
    public int CreatedAt { get; set; }

    [Column("updated_at")]
    public int UpdatedAt { get; set; }

    [Column("owner_signature")]
    public int OwnerSignature { get; set; }

    [Column("supervisor_signature")]
    public int SupervisorSignature { get; set; }

    [Column("hr_signature")]
    public int HrSignature { get; set; }
}
