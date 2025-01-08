﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("ColleagueTestRecord")]
public partial class ColleagueTestRecord
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("Employee_Id")]
    [StringLength(450)]
    public string EmployeeId { get; set; } = null!;

    [Column("Colleague_Id")]
    [StringLength(450)]
    public string ColleagueId { get; set; } = null!;

    [Column("Assessment_Id")]
    public int AssessmentId { get; set; }

    [Column("Date_Taken", TypeName = "datetime")]
    public DateTime DateTaken { get; set; }

    [ForeignKey("AssessmentId")]
    [InverseProperty("ColleagueTestRecords")]
    public virtual Assessment Assessment { get; set; } = null!;

    [ForeignKey("ColleagueId")]
    [InverseProperty("ColleagueTestRecordColleagues")]
    public virtual User Colleague { get; set; } = null!;

    [InverseProperty("EmployeeTestRecord")]
    public virtual ICollection<ColleagueTestAnswer> ColleagueTestAnswers { get; set; } = new List<ColleagueTestAnswer>();

    [ForeignKey("EmployeeId")]
    [InverseProperty("ColleagueTestRecordEmployees")]
    public virtual User Employee { get; set; } = null!;
}