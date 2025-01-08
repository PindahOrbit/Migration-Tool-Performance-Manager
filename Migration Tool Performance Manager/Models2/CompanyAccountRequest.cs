using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

public partial class CompanyAccountRequest
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("password")]
    public string? Password { get; set; }

    [Column("address")]
    public string? Address { get; set; }

    [Column("website")]
    public string? Website { get; set; }

    [Column("phone")]
    public string? Phone { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("date_requested", TypeName = "datetime")]
    public DateTime DateRequested { get; set; }
}
