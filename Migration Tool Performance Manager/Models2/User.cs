using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Index("NormalizedEmail", Name = "EmailIndex")]
public partial class User
{
    [Key]
    public string Id { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? ProfilePictureLocation { get; set; }

    [StringLength(256)]
    public string? UserName { get; set; }

    [StringLength(256)]
    public string? NormalizedUserName { get; set; }

    [StringLength(256)]
    public string? Email { get; set; }

    [StringLength(256)]
    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    [Column("company_id")]
    public int CompanyId { get; set; }

    [StringLength(100)]
    public string Model { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string UserType { get; set; } = null!;

    [Column("gender")]
    [StringLength(10)]
    public string? Gender { get; set; }

    [Column("date_joined", TypeName = "datetime")]
    public DateTime DateJoined { get; set; }

    [Column("date_of_birth", TypeName = "datetime")]
    public DateTime? DateOfBirth { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<ActionPlanComment> ActionPlanComments { get; set; } = new List<ActionPlanComment>();

    [InverseProperty("User")]
    public virtual ICollection<ActionPlan> ActionPlans { get; set; } = new List<ActionPlan>();

    [InverseProperty("Manager")]
    public virtual ICollection<BusinessUnit> BusinessUnits { get; set; } = new List<BusinessUnit>();

    [InverseProperty("Receiver")]
    public virtual ICollection<Chatmessage> ChatmessageReceivers { get; set; } = new List<Chatmessage>();

    [InverseProperty("Sender")]
    public virtual ICollection<Chatmessage> ChatmessageSenders { get; set; } = new List<Chatmessage>();

    [InverseProperty("Colleague")]
    public virtual ICollection<ColleagueTestAnswer> ColleagueTestAnswerColleagues { get; set; } = new List<ColleagueTestAnswer>();

    [InverseProperty("Employee")]
    public virtual ICollection<ColleagueTestAnswer> ColleagueTestAnswerEmployees { get; set; } = new List<ColleagueTestAnswer>();

    [InverseProperty("Colleague")]
    public virtual ICollection<ColleagueTestRecord> ColleagueTestRecordColleagues { get; set; } = new List<ColleagueTestRecord>();

    [InverseProperty("Employee")]
    public virtual ICollection<ColleagueTestRecord> ColleagueTestRecordEmployees { get; set; } = new List<ColleagueTestRecord>();

    [ForeignKey("CompanyId")]
    [InverseProperty("Users")]
    public virtual Company Company { get; set; } = null!;

    [InverseProperty("Receiver")]
    public virtual ICollection<Conversation> ConversationReceivers { get; set; } = new List<Conversation>();

    [InverseProperty("Sender")]
    public virtual ICollection<Conversation> ConversationSenders { get; set; } = new List<Conversation>();

    [InverseProperty("Manager")]
    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    [InverseProperty("Employee")]
    public virtual EmployeeDetail? EmployeeDetailEmployee { get; set; }

    [InverseProperty("Supervisor")]
    public virtual ICollection<EmployeeDetail> EmployeeDetailSupervisors { get; set; } = new List<EmployeeDetail>();

    [InverseProperty("Employee")]
    public virtual ICollection<EmployeePerspective> EmployeePerspectives { get; set; } = new List<EmployeePerspective>();

    [InverseProperty("Employee")]
    public virtual ICollection<EmployeeTestAnswer> EmployeeTestAnswers { get; set; } = new List<EmployeeTestAnswer>();

    [InverseProperty("Employee")]
    public virtual ICollection<EmployeeTestRecord> EmployeeTestRecords { get; set; } = new List<EmployeeTestRecord>();

    [InverseProperty("User")]
    public virtual ICollection<Goal> Goals { get; set; } = new List<Goal>();

    [InverseProperty("Creator")]
    public virtual ICollection<KeyResult> KeyResultCreators { get; set; } = new List<KeyResult>();

    [InverseProperty("Delegate")]
    public virtual ICollection<KeyResult> KeyResultDelegates { get; set; } = new List<KeyResult>();

    [InverseProperty("Employee")]
    public virtual ICollection<Kpiactual> Kpiactuals { get; set; } = new List<Kpiactual>();

    [InverseProperty("SourceUserNavigation")]
    public virtual ICollection<Notification> NotificationSourceUserNavigations { get; set; } = new List<Notification>();

    [InverseProperty("TargetUserNavigation")]
    public virtual ICollection<Notification> NotificationTargetUserNavigations { get; set; } = new List<Notification>();

    [InverseProperty("Creator")]
    public virtual ICollection<Objective> ObjectiveCreators { get; set; } = new List<Objective>();

    [InverseProperty("Delegate")]
    public virtual ICollection<Objective> ObjectiveDelegates { get; set; } = new List<Objective>();

    [InverseProperty("Creator")]
    public virtual ICollection<Project> ProjectCreators { get; set; } = new List<Project>();

    [InverseProperty("Delegate")]
    public virtual ICollection<Project> ProjectDelegates { get; set; } = new List<Project>();

    [InverseProperty("Owner")]
    public virtual ICollection<Scorecard> ScorecardOwners { get; set; } = new List<Scorecard>();

    [InverseProperty("Reviewer")]
    public virtual ICollection<Scorecard> ScorecardReviewers { get; set; } = new List<Scorecard>();

    [InverseProperty("Champion")]
    public virtual ICollection<SubActionPlan> SubActionPlans { get; set; } = new List<SubActionPlan>();

    [InverseProperty("Employee")]
    public virtual ICollection<SubordinateTestAnswer> SubordinateTestAnswerEmployees { get; set; } = new List<SubordinateTestAnswer>();

    [InverseProperty("Supervisor")]
    public virtual ICollection<SubordinateTestAnswer> SubordinateTestAnswerSupervisors { get; set; } = new List<SubordinateTestAnswer>();

    [InverseProperty("Employee")]
    public virtual ICollection<SubordinateTestRecord> SubordinateTestRecordEmployees { get; set; } = new List<SubordinateTestRecord>();

    [InverseProperty("Supervisor")]
    public virtual ICollection<SubordinateTestRecord> SubordinateTestRecordSupervisors { get; set; } = new List<SubordinateTestRecord>();

    [InverseProperty("User")]
    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();

    [InverseProperty("Leader")]
    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

    [InverseProperty("OwnerNavigation")]
    public virtual ICollection<Teamsokr> Teamsokrs { get; set; } = new List<Teamsokr>();

    [InverseProperty("User")]
    public virtual ICollection<UserClaim> UserClaims { get; set; } = new List<UserClaim>();

    [InverseProperty("User")]
    public virtual ICollection<UserLogin> UserLogins { get; set; } = new List<UserLogin>();

    [InverseProperty("User")]
    public virtual ICollection<UserToken> UserTokens { get; set; } = new List<UserToken>();

    [ForeignKey("UserId")]
    [InverseProperty("Users")]
    public virtual ICollection<ActionPlan> ActionPlansNavigation { get; set; } = new List<ActionPlan>();

    [ForeignKey("OwnerId")]
    [InverseProperty("Owners")]
    public virtual ICollection<Summaryreport> Reports { get; set; } = new List<Summaryreport>();

    [ForeignKey("UserId")]
    [InverseProperty("Users")]
    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
