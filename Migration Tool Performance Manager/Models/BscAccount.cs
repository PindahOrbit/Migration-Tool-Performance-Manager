using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_accounts")]
public partial class BscAccount
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("full_name", TypeName = "text")]
    public string FullName { get; set; }

    [Column("profile_pic", TypeName = "text")]
    public string ProfilePic { get; set; }

    [Column("email", TypeName = "text")]
    public string Email { get; set; }

    [Column("password", TypeName = "text")]
    public string Password { get; set; }

    [Column("supervisor", TypeName = "text")]
    public string Supervisor { get; set; }

    [Column("department_id", TypeName = "text")]
    public string DepartmentId { get; set; }

    [Column("position", TypeName = "text")]
    public string Position { get; set; }

    [Column("account_type", TypeName = "text")]
    public string AccountType { get; set; }

    [Column("admin")]
    public int Admin { get; set; }

    [Column("special")]
    public int Special { get; set; }

    [Column("business_unit")]
    public int BusinessUnit { get; set; }

    [Column("model")]
    public int Model { get; set; }

    [Column("status")]
    public int? Status { get; set; }

    [Column("date", TypeName = "timestamp")]
    public DateTime Date { get; set; }

    [Column("reset_link")]
    [StringLength(64)]
    public string ResetLink { get; set; }
}
