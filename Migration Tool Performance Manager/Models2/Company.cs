using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("company")]
public partial class Company
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("address")]
    public string? Address { get; set; }

    [Column("website")]
    public string? Website { get; set; }

    [Column("phone")]
    public string? Phone { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("model")]
    [StringLength(3)]
    [Unicode(false)]
    public string Model { get; set; } = null!;

    [Column("setup")]
    public bool Setup { get; set; }

    [Column("logo", TypeName = "image")]
    public byte[]? Logo { get; set; }

    [Column("scoring_model")]
    public int ScoringModel { get; set; }

    [Column("fiscal_start")]
    public DateOnly FiscalStart { get; set; }

    [Column("fiscal_end")]
    public DateOnly FiscalEnd { get; set; }

    [InverseProperty("Company")]
    public virtual ICollection<ActionPlan> ActionPlans { get; set; } = new List<ActionPlan>();

    [InverseProperty("Company")]
    public virtual ICollection<BusinessUnit> BusinessUnits { get; set; } = new List<BusinessUnit>();

    [InverseProperty("Company")]
    public virtual ICollection<CompanyActionStage> CompanyActionStages { get; set; } = new List<CompanyActionStage>();

    [InverseProperty("Company")]
    public virtual ICollection<CompanyGoal> CompanyGoals { get; set; } = new List<CompanyGoal>();

    [InverseProperty("Company")]
    public virtual ICollection<CompanyRole> CompanyRoles { get; set; } = new List<CompanyRole>();

    [InverseProperty("Company")]
    public virtual ICollection<Conversation> Conversations { get; set; } = new List<Conversation>();

    [InverseProperty("Company")]
    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    [InverseProperty("Company")]
    public virtual ICollection<EmployeeDetail> EmployeeDetails { get; set; } = new List<EmployeeDetail>();

    [InverseProperty("Company")]
    public virtual ICollection<Faq> Faqs { get; set; } = new List<Faq>();

    [InverseProperty("Company")]
    public virtual ICollection<Goal> Goals { get; set; } = new List<Goal>();

    [InverseProperty("Company")]
    public virtual ICollection<Kpiactual> Kpiactuals { get; set; } = new List<Kpiactual>();

    [InverseProperty("Company")]
    public virtual ICollection<MeasureUnit> MeasureUnits { get; set; } = new List<MeasureUnit>();

    [InverseProperty("Company")]
    public virtual ICollection<Measure> Measures { get; set; } = new List<Measure>();

    [InverseProperty("Company")]
    public virtual ICollection<Mention> Mentions { get; set; } = new List<Mention>();

    [InverseProperty("Company")]
    public virtual Mision? Mision { get; set; }

    [InverseProperty("Company")]
    public virtual ICollection<PerspectiveAllocation> PerspectiveAllocations { get; set; } = new List<PerspectiveAllocation>();

    [InverseProperty("Company")]
    public virtual ICollection<Perspective> Perspectives { get; set; } = new List<Perspective>();

    [InverseProperty("Company")]
    public virtual ICollection<Scorecard> Scorecards { get; set; } = new List<Scorecard>();

    [InverseProperty("Company")]
    public virtual ICollection<Setting> Settings { get; set; } = new List<Setting>();

    [InverseProperty("Company")]
    public virtual ICollection<SettingsColorCode> SettingsColorCodes { get; set; } = new List<SettingsColorCode>();

    [InverseProperty("Company")]
    public virtual SettingsScoringRatio? SettingsScoringRatio { get; set; }

    [InverseProperty("Company")]
    public virtual StrategyMap? StrategyMap { get; set; }

    [InverseProperty("Company")]
    public virtual Subscription? Subscription { get; set; }

    [InverseProperty("Company")]
    public virtual ICollection<Summaryreport> Summaryreports { get; set; } = new List<Summaryreport>();

    [InverseProperty("Company")]
    public virtual ICollection<TeamGoal> TeamGoals { get; set; } = new List<TeamGoal>();

    [InverseProperty("Company")]
    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

    [InverseProperty("Company")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();

    [InverseProperty("Company")]
    public virtual Vision? Vision { get; set; }
}
