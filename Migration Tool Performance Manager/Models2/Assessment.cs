using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

public partial class Assessment
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    public string AssessmentName { get; set; } = null!;

    public string Description { get; set; } = null!;

    [Column("total")]
    public double Total { get; set; }

    [Column("Body_Responsible")]
    public string BodyResponsible { get; set; } = null!;

    [InverseProperty("Assessment")]
    public virtual ICollection<AssessmentQuestion> AssessmentQuestions { get; set; } = new List<AssessmentQuestion>();

    [InverseProperty("Assessment")]
    public virtual ICollection<ColleagueTestRecord> ColleagueTestRecords { get; set; } = new List<ColleagueTestRecord>();

    [InverseProperty("Assessment")]
    public virtual ICollection<EmployeeTestRecord> EmployeeTestRecords { get; set; } = new List<EmployeeTestRecord>();

    [InverseProperty("Assessment")]
    public virtual ICollection<SubordinateTestRecord> SubordinateTestRecords { get; set; } = new List<SubordinateTestRecord>();
}
