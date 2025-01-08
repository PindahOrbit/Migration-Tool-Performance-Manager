using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models;

[Table("bsc_project_tasks_update")]
public partial class BscProjectTasksUpdate
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("task_id")]
    public int TaskId { get; set; }

    [Column("old_value")]
    public int OldValue { get; set; }

    [Column("new_value")]
    public int NewValue { get; set; }

    [Required]
    [Column("reason", TypeName = "text")]
    public string Reason { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("date", TypeName = "timestamp")]
    public DateTime Date { get; set; }
}
