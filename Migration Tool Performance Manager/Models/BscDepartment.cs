using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_departments")]
public partial class BscDepartment
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("department", TypeName = "text")]
    public string Department { get; set; }

    [Column("manager", TypeName = "text")]
    public string Manager { get; set; }
}
