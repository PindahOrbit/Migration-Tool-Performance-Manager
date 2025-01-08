using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Migration_Tool_Performance_Manager.Models2;

namespace Migration_Tool_Performance_Manager.Data2;

public partial class ServerDbContext : DbContext
{
    public ServerDbContext()
    {
    }

    public ServerDbContext(DbContextOptions<ServerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActionPlan> ActionPlans { get; set; }

    public virtual DbSet<ActionPlanAttachment> ActionPlanAttachments { get; set; }

    public virtual DbSet<ActionPlanChecklist> ActionPlanChecklists { get; set; }

    public virtual DbSet<ActionPlanComment> ActionPlanComments { get; set; }

    public virtual DbSet<ActionPlanStage> ActionPlanStages { get; set; }

    public virtual DbSet<Assessment> Assessments { get; set; }

    public virtual DbSet<AssessmentQuestion> AssessmentQuestions { get; set; }

    public virtual DbSet<BusinessUnit> BusinessUnits { get; set; }

    public virtual DbSet<Chatmessage> Chatmessages { get; set; }

    public virtual DbSet<ColleagueTestAnswer> ColleagueTestAnswers { get; set; }

    public virtual DbSet<ColleagueTestRecord> ColleagueTestRecords { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompanyAccountRequest> CompanyAccountRequests { get; set; }

    public virtual DbSet<CompanyActionStage> CompanyActionStages { get; set; }

    public virtual DbSet<CompanyGoal> CompanyGoals { get; set; }

    public virtual DbSet<CompanyRole> CompanyRoles { get; set; }

    public virtual DbSet<Conversation> Conversations { get; set; }

    public virtual DbSet<DefaultPerspective> DefaultPerspectives { get; set; }

    public virtual DbSet<DefaultSetting> DefaultSettings { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }

    public virtual DbSet<EmployeePerspective> EmployeePerspectives { get; set; }

    public virtual DbSet<EmployeeTestAnswer> EmployeeTestAnswers { get; set; }

    public virtual DbSet<EmployeeTestRecord> EmployeeTestRecords { get; set; }

    public virtual DbSet<Faq> Faqs { get; set; }

    public virtual DbSet<Feature> Features { get; set; }

    public virtual DbSet<FeatureCost> FeatureCosts { get; set; }

    public virtual DbSet<Goal> Goals { get; set; }

    public virtual DbSet<KeyResult> KeyResults { get; set; }

    public virtual DbSet<Kpiactual> Kpiactuals { get; set; }

    public virtual DbSet<Measure> Measures { get; set; }

    public virtual DbSet<MeasureUnit> MeasureUnits { get; set; }

    public virtual DbSet<Mention> Mentions { get; set; }

    public virtual DbSet<Mision> Misions { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Objective> Objectives { get; set; }

    public virtual DbSet<Parenttable> Parenttables { get; set; }

    public virtual DbSet<PendingActionPlanChange> PendingActionPlanChanges { get; set; }

    public virtual DbSet<Perspective> Perspectives { get; set; }

    public virtual DbSet<PerspectiveAllocation> PerspectiveAllocations { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleClaim> RoleClaims { get; set; }

    public virtual DbSet<Scorecard> Scorecards { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<SettingsColorCode> SettingsColorCodes { get; set; }

    public virtual DbSet<SettingsScoringRatio> SettingsScoringRatios { get; set; }

    public virtual DbSet<StrategyMap> StrategyMaps { get; set; }

    public virtual DbSet<SubActionPlan> SubActionPlans { get; set; }

    public virtual DbSet<SubordinateTestAnswer> SubordinateTestAnswers { get; set; }

    public virtual DbSet<SubordinateTestRecord> SubordinateTestRecords { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public virtual DbSet<SubscriptionDate> SubscriptionDates { get; set; }

    public virtual DbSet<Summaryreport> Summaryreports { get; set; }

    public virtual DbSet<SupervisoryRole> SupervisoryRoles { get; set; }

    public virtual DbSet<SystemPayment> SystemPayments { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamGoal> TeamGoals { get; set; }

    public virtual DbSet<Teammember> Teammembers { get; set; }

    public virtual DbSet<Teamsokr> Teamsokrs { get; set; }

    public virtual DbSet<TestAnswerChoice> TestAnswerChoices { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserClaim> UserClaims { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    public virtual DbSet<UserToken> UserTokens { get; set; }

    public virtual DbSet<Vision> Visions { get; set; }

    public virtual DbSet<WorkLoad> WorkLoads { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=serverConn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActionPlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ActionPl__3214EC0750844740");

            entity.Property(e => e.Code).HasDefaultValue("self-directed");
            entity.Property(e => e.Impact).HasDefaultValue("medium");
            entity.Property(e => e.ImpactHorizon).HasDefaultValue("medium-term");
            entity.Property(e => e.IsDone).HasDefaultValue(false);
            entity.Property(e => e.Priority).HasDefaultValue("Not-Urgent");
            entity.Property(e => e.ProgressNumber).HasDefaultValue(0.0);
            entity.Property(e => e.Quality).HasDefaultValue("fair");
            entity.Property(e => e.Resourcing).HasDefaultValue("not-budgeted");

            entity.HasOne(d => d.Company).WithMany(p => p.ActionPlans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ActionPlanToCompany");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent).HasConstraintName("fk_action_plan_sub_plans");

            entity.HasOne(d => d.Perspective).WithMany(p => p.ActionPlans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ActionPlanToPerspective");

            entity.HasOne(d => d.ProgressNavigation).WithMany(p => p.ActionPlans)
                .HasPrincipalKey(p => p.Name)
                .HasForeignKey(d => d.Progress)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProgressToDefaults");

            entity.HasOne(d => d.Scorecard).WithMany(p => p.ActionPlans)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_scorecard_action_plans");

            entity.HasOne(d => d.User).WithMany(p => p.ActionPlans).HasConstraintName("fk_action_plan_owner");

            entity.HasOne(d => d.Workload).WithMany(p => p.ActionPlans).HasConstraintName("fk_action_workload");

            entity.HasMany(d => d.Goals).WithMany(p => p.ActionPlans)
                .UsingEntity<Dictionary<string, object>>(
                    "GoalsAndPlan",
                    r => r.HasOne<Goal>().WithMany()
                        .HasForeignKey("GoalId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_goal_action_goal"),
                    l => l.HasOne<ActionPlan>().WithMany()
                        .HasForeignKey("ActionPlanId")
                        .HasConstraintName("fk_goal_action_plan"),
                    j =>
                    {
                        j.HasKey("ActionPlanId", "GoalId").HasName("PK__goals_an__EA4D21EBB5EC9EF0");
                        j.ToTable("goals_and_plans");
                        j.IndexerProperty<int>("ActionPlanId").HasColumnName("ACTION_plan_id");
                        j.IndexerProperty<int>("GoalId").HasColumnName("goal_id");
                    });

            entity.HasMany(d => d.Teams).WithMany(p => p.ActionPlans)
                .UsingEntity<Dictionary<string, object>>(
                    "TeamActionPlan",
                    r => r.HasOne<Team>().WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_team_action_plan"),
                    l => l.HasOne<ActionPlan>().WithMany()
                        .HasForeignKey("ActionPlanId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_actionplans_"),
                    j =>
                    {
                        j.HasKey("ActionPlanId", "TeamId").HasName("PK__team_act__AF271CE0F764B245");
                        j.ToTable("team_action_plans");
                        j.IndexerProperty<int>("ActionPlanId").HasColumnName("action_plan_id");
                        j.IndexerProperty<int>("TeamId").HasColumnName("team_id");
                    });

            entity.HasMany(d => d.Users).WithMany(p => p.ActionPlansNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "ActionPlanAssignee",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ActionPlanAssignees_Champions"),
                    l => l.HasOne<ActionPlan>().WithMany()
                        .HasForeignKey("ActionPlanId")
                        .HasConstraintName("ActionPlanTableFK"),
                    j =>
                    {
                        j.HasKey("ActionPlanId", "UserId").HasName("PK__ActionPl__9B3E214B98C0C059");
                        j.ToTable("ActionPlanAssignees");
                        j.IndexerProperty<int>("ActionPlanId").HasColumnName("action_plan_id");
                        j.IndexerProperty<string>("UserId").HasColumnName("user_id");
                    });
        });

        modelBuilder.Entity<ActionPlanAttachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__action_p__3213E83F44B54DC3");

            entity.Property(e => e.DateAttached).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.ActionPlan).WithMany(p => p.ActionPlanAttachments).HasConstraintName("FK__action_pl__actio__58DC1D15");
        });

        modelBuilder.Entity<ActionPlanChecklist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__action_p__3213E83FD71ED2D2");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DueDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.ActionPlan).WithMany(p => p.ActionPlanChecklists).HasConstraintName("fk_action_checklist");
        });

        modelBuilder.Entity<ActionPlanComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__action_p__3213E83F6056AF88");

            entity.Property(e => e.Date).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.ActionPlan).WithMany(p => p.ActionPlanComments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__action_pl__actio__338A9CD5");

            entity.HasOne(d => d.User).WithMany(p => p.ActionPlanComments).HasConstraintName("FK__action_pl__user___347EC10E");
        });

        modelBuilder.Entity<ActionPlanStage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ActionPl__3214EC07EEFE3DF2");

            entity.Property(e => e.Color).HasDefaultValue("#000000");
        });

        modelBuilder.Entity<Assessment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Assessme__3213E83F7C0A2AA0");

            entity.Property(e => e.BodyResponsible).HasDefaultValue("IPC Consultants");
        });

        modelBuilder.Entity<AssessmentQuestion>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__Assessme__B0B2E4E67F45F45D");

            entity.HasOne(d => d.Assessment).WithMany(p => p.AssessmentQuestions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Assessmen__Asses__1EE485AA");
        });

        modelBuilder.Entity<BusinessUnit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__business__3213E83FBCC7D021");

            entity.HasOne(d => d.Company).WithMany(p => p.BusinessUnits).HasConstraintName("FK_businessUnit_ToCompany");

            entity.HasOne(d => d.Department).WithMany(p => p.BusinessUnits).HasConstraintName("FK_businessUnit_ToDepartment");

            entity.HasOne(d => d.Manager).WithMany(p => p.BusinessUnits).HasConstraintName("FK_businessUnit_ToManager");
        });

        modelBuilder.Entity<Chatmessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__chatmess__3213E83FFD2EAE0C");

            entity.Property(e => e.DateSent).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Receiver).WithMany(p => p.ChatmessageReceivers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__chatmessa__recei__3FF073BA");

            entity.HasOne(d => d.Sender).WithMany(p => p.ChatmessageSenders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__chatmessa__sende__40E497F3");
        });

        modelBuilder.Entity<ColleagueTestAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Colleagu__3213E83FC73DBF60");

            entity.HasOne(d => d.Colleague).WithMany(p => p.ColleagueTestAnswerColleagues)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Colleague__Colle__7AFC2AEF");

            entity.HasOne(d => d.Employee).WithMany(p => p.ColleagueTestAnswerEmployees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Colleague__Emplo__7BF04F28");

            entity.HasOne(d => d.EmployeeTestRecord).WithMany(p => p.ColleagueTestAnswers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Colleague__Emplo__22B5168E");

            entity.HasOne(d => d.Question).WithMany(p => p.ColleagueTestAnswers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Colleague__Quest__1BD30ED5");
        });

        modelBuilder.Entity<ColleagueTestRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Colleagu__3213E83F9C77249D");

            entity.Property(e => e.DateTaken).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Assessment).WithMany(p => p.ColleagueTestRecords)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Colleague__Asses__249D5F00");

            entity.HasOne(d => d.Colleague).WithMany(p => p.ColleagueTestRecordColleagues)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Colleague__Colle__7CE47361");

            entity.HasOne(d => d.Employee).WithMany(p => p.ColleagueTestRecordEmployees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Colleague__Emplo__7DD8979A");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__company__3213E83F4EA0BEFC");

            entity.Property(e => e.FiscalEnd).HasDefaultValue(new DateOnly(2024, 12, 31));
            entity.Property(e => e.FiscalStart).HasDefaultValue(new DateOnly(2024, 1, 1));
            entity.Property(e => e.Model).IsFixedLength();
            entity.Property(e => e.ScoringModel).HasDefaultValue(1);
        });

        modelBuilder.Entity<CompanyAccountRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CompanyA__3213E83FB2BE5D57");

            entity.Property(e => e.DateRequested).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<CompanyActionStage>(entity =>
        {
            entity.HasKey(e => new { e.CompanyId, e.StageId }).HasName("PK__company___22DA0A4324E8FF45");

            entity.HasOne(d => d.Company).WithMany(p => p.CompanyActionStages).HasConstraintName("fk_company_stage");

            entity.HasOne(d => d.Stage).WithMany(p => p.CompanyActionStages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_stage_id");
        });

        modelBuilder.Entity<CompanyGoal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CompanyG__3213E83FC2B40D0B");

            entity.HasOne(d => d.Company).WithMany(p => p.CompanyGoals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Company_Goal");

            entity.HasOne(d => d.Perspective).WithMany(p => p.CompanyGoals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompanyGoals_ToPerspective");
        });

        modelBuilder.Entity<CompanyRole>(entity =>
        {
            entity.HasKey(e => new { e.RoleId, e.CompanyId }).HasName("PK__CompanyR__EDFF65083BFD237B");

            entity.HasOne(d => d.Company).WithMany(p => p.CompanyRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CompanyRo__Compa__52EE3995");

            entity.HasOne(d => d.Role).WithMany(p => p.CompanyRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CompanyRo__Role___2E26C93A");
        });

        modelBuilder.Entity<Conversation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Conversa__3214EC07506F1479");

            entity.HasOne(d => d.Company).WithMany(p => p.Conversations).HasConstraintName("FK__Conversation__Company");

            entity.HasOne(d => d.Receiver).WithMany(p => p.ConversationReceivers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Conversation__Receiver");

            entity.HasOne(d => d.Sender).WithMany(p => p.ConversationSenders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Conversation__Sender");
        });

        modelBuilder.Entity<DefaultPerspective>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DefaultP__3213E83F2592E2B8");
        });

        modelBuilder.Entity<DefaultSetting>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__DefaultS__357D4CF821FFDA31");

            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Editable).HasDefaultValue(true);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__departme__3213E83F8F9F61D3");

            entity.HasOne(d => d.Company).WithMany(p => p.Departments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__departmen__compa__33DFA290");

            entity.HasOne(d => d.Manager).WithMany(p => p.Departments).HasConstraintName("FK_departments_ToManagers");
        });

        modelBuilder.Entity<EmployeeDetail>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK_employee_id");

            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.BusinessUnitNavigation).WithMany(p => p.EmployeeDetails).HasConstraintName("FK__EmployeeD__busin__5C4299A5");

            entity.HasOne(d => d.Company).WithMany(p => p.EmployeeDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployeeD__compa__5D36BDDE");

            entity.HasOne(d => d.Department).WithMany(p => p.EmployeeDetails).HasConstraintName("FK__EmployeeD__depar__511AFFBC");

            entity.HasOne(d => d.Employee).WithOne(p => p.EmployeeDetailEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employee_user_id");

            entity.HasOne(d => d.Supervisor).WithMany(p => p.EmployeeDetailSupervisors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeSupervisor");

            entity.HasOne(d => d.Team).WithMany(p => p.EmployeeDetails).HasConstraintName("FK__EmployeeD__team___520F23F5");
        });

        modelBuilder.Entity<EmployeePerspective>(entity =>
        {
            entity.HasKey(e => new { e.EmployeeId, e.PerspectiveId, e.ScorecardId }).HasName("PK__Employee__D7B73FA2849103DC");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeePerspectives)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Perspective");

            entity.HasOne(d => d.Perspective).WithMany(p => p.EmployeePerspectives)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Perspective_Employee");

            entity.HasOne(d => d.Scorecard).WithMany(p => p.EmployeePerspectives)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployeeP__score__4AE30379");
        });

        modelBuilder.Entity<EmployeeTestAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3213E83F743554A7");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeTestAnswers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployeeT__Emplo__029D4CB7");

            entity.HasOne(d => d.EmployeeTestRecord).WithMany(p => p.EmployeeTestAnswers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployeeT__Emplo__3A8CA01F");

            entity.HasOne(d => d.Question).WithMany(p => p.EmployeeTestAnswers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployeeT__Quest__3C74E891");
        });

        modelBuilder.Entity<EmployeeTestRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3213E83FB685C1CB");

            entity.Property(e => e.DateTaken).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Assessment).WithMany(p => p.EmployeeTestRecords)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployeeT__Asses__3D690CCA");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeTestRecords)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployeeT__Emplo__039170F0");
        });

        modelBuilder.Entity<Faq>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__faqs__3213E83F21548CA3");

            entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Updated).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Company).WithMany(p => p.Faqs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Company_FAQ");
        });

        modelBuilder.Entity<Feature>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Features__3213E83F50CE2325");
        });

        modelBuilder.Entity<FeatureCost>(entity =>
        {
            entity.HasKey(e => e.FeatureName).HasName("PK__Feature___96AE15E99F4A08C8");
        });

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Goals__3214EC07ADD2B64F");

            entity.Property(e => e.Approved).HasDefaultValue(true);
            entity.Property(e => e.Datecreated).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Company).WithMany(p => p.Goals).HasConstraintName("FK__Goals__Company_i__71FCD09A");

            entity.HasOne(d => d.Perspective).WithMany(p => p.Goals).HasConstraintName("FK__Goals__Perspecti__70148828");

            entity.HasOne(d => d.Scorecard).WithMany(p => p.Goals).HasConstraintName("FK__Goals__scorecard__7108AC61");

            entity.HasOne(d => d.User).WithMany(p => p.Goals).HasConstraintName("User_Goal");
        });

        modelBuilder.Entity<KeyResult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KeyResul__3213E83FECB5E1CF");

            entity.Property(e => e.MetricUnit).HasDefaultValue("$");
            entity.Property(e => e.Period).HasDefaultValue("Current Year");
            entity.Property(e => e.Progress).HasDefaultValue("NOT-STARTED");
            entity.Property(e => e.Type).HasDefaultValue("Individual");

            entity.HasOne(d => d.Creator).WithMany(p => p.KeyResultCreators)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KeyResult__creat__388F4914");

            entity.HasOne(d => d.Delegate).WithMany(p => p.KeyResultDelegates).HasConstraintName("FK__KeyResult__deleg__39836D4D");

            entity.HasOne(d => d.Objective).WithMany(p => p.KeyResults).HasConstraintName("FK__KeyResult__objec__7C4554E3");

            entity.HasOne(d => d.Team).WithMany(p => p.KeyResults).HasConstraintName("FK__KeyResult__team___3B6BB5BF");
        });

        modelBuilder.Entity<Kpiactual>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KPIActua__3213E83FF2F7E9CF");

            entity.Property(e => e.DateRecorded).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DateUpdated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Frequency).IsFixedLength();
            entity.Property(e => e.Tp).IsFixedLength();

            entity.HasOne(d => d.Company).WithMany(p => p.Kpiactuals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KPIActual__compa__46F27704");

            entity.HasOne(d => d.Employee).WithMany(p => p.Kpiactuals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KPIActual__emplo__492FC531");

            entity.HasOne(d => d.MeasureUnit).WithMany(p => p.Kpiactuals).HasConstraintName("fk_measureunit_actuals");

            entity.HasOne(d => d.Scorecard).WithMany(p => p.Kpiactuals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KPIActual__score__7CAF6937");
        });

        modelBuilder.Entity<Measure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Measures__3214EC07D54F13F7");

            entity.HasOne(d => d.Company).WithMany(p => p.Measures).HasConstraintName("FK__Measures__Compan__5634BA94");

            entity.HasOne(d => d.Goal).WithMany(p => p.Measures).HasConstraintName("FK__Measures__Goal_ID");

            entity.HasOne(d => d.Perspective).WithMany(p => p.Measures).HasConstraintName("FK__Measures__Perspe__5911273F");

            entity.HasOne(d => d.Scorecard).WithMany(p => p.Measures)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Measures__scorec__7E97B1A9");
        });

        modelBuilder.Entity<MeasureUnit>(entity =>
        {
            entity.HasKey(e => e.MeasureId).HasName("PK__Measure___7C59D2D9800C97E1");

            entity.Property(e => e.MeasureId).ValueGeneratedNever();
            entity.Property(e => e.Approved).HasDefaultValue(false);

            entity.HasOne(d => d.Company).WithMany(p => p.MeasureUnits)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Measure_u__Compa__4F87BD05");

            entity.HasOne(d => d.Goal).WithMany(p => p.MeasureUnits)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Measure_u__Goal___76C185B7");

            entity.HasOne(d => d.Measure).WithOne(p => p.MeasureUnit).HasConstraintName("fk_measure_units");

            entity.HasOne(d => d.Perspective).WithMany(p => p.MeasureUnits)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Measure_u__Persp__544C7222");

            entity.HasOne(d => d.Scorecard).WithMany(p => p.MeasureUnits)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Measure_u__score__7DA38D70");
        });

        modelBuilder.Entity<Mention>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__mentions__3213E83FD96FF304");

            entity.Property(e => e.MentionType).HasDefaultValue("measure");

            entity.HasOne(d => d.Company).WithMany(p => p.Mentions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_mentions_in_company");

            entity.HasOne(d => d.Conversation).WithMany(p => p.Mentions)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_conversations_mentions");
        });

        modelBuilder.Entity<Mision>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__mision__3213E83F872364D3");

            entity.HasOne(d => d.Company).WithOne(p => p.Mision)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__mision__company___5AF96FB1");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__notifica__3213E83F2D0AF79E");

            entity.Property(e => e.Datecreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Seen).HasDefaultValue(false);

            entity.HasOne(d => d.SourceUserNavigation).WithMany(p => p.NotificationSourceUserNavigations).HasConstraintName("FK__notificat__source");

            entity.HasOne(d => d.TargetUserNavigation).WithMany(p => p.NotificationTargetUserNavigations).HasConstraintName("FK__notificat__target");
        });

        modelBuilder.Entity<Objective>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__objectiv__3213E83F14FF3C9B");

            entity.Property(e => e.Datecreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Period).HasDefaultValue("Current Year");
            entity.Property(e => e.Periodfrom).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Periodto).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Progress).HasDefaultValue("NOT-STARTED");
            entity.Property(e => e.Type).HasDefaultValue("Individual");

            entity.HasOne(d => d.Creator).WithMany(p => p.ObjectiveCreators)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__objective__creat__7F21C18E");

            entity.HasOne(d => d.Delegate).WithMany(p => p.ObjectiveDelegates).HasConstraintName("FK__objective__deleg__0015E5C7");

            entity.HasOne(d => d.ParentObjectiveNavigation).WithMany(p => p.InverseParentObjectiveNavigation).HasConstraintName("FK__objective__paren__01FE2E39");

            entity.HasOne(d => d.StrategicFocusArea).WithMany(p => p.Objectives).HasConstraintName("FK__objective__strat__7EE1CA6C");

            entity.HasOne(d => d.Team).WithMany(p => p.Objectives).HasConstraintName("FK__objective__team___010A0A00");
        });

        modelBuilder.Entity<Parenttable>(entity =>
        {
            entity.HasOne(d => d.ParentTeamNavigation).WithMany().HasConstraintName("FK__parenttab__PAREN__257C74A0");

            entity.HasOne(d => d.Team).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__parenttab__TEAM___267098D9");
        });

        modelBuilder.Entity<PendingActionPlanChange>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PendingA__3213E83F81C5D347");

            entity.HasOne(d => d.ActionPlan).WithMany(p => p.PendingActionPlanChanges)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PendingAc__actio__30641767");
        });

        modelBuilder.Entity<Perspective>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Perspect__3214EC07FA2365C5");

            entity.Property(e => e.Priority).HasDefaultValue(1);
            entity.Property(e => e.Type).IsFixedLength();

            entity.HasOne(d => d.Company).WithMany(p => p.Perspectives).HasConstraintName("FK_PerspectiveCompanyToCompany");
        });

        modelBuilder.Entity<PerspectiveAllocation>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.PerspectiveId }).HasName("PK__Perspect__30D6917FB88844D5");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Company).WithMany(p => p.PerspectiveAllocations).HasConstraintName("FK_AllocationToCompany");

            entity.HasOne(d => d.Perspective).WithMany(p => p.PerspectiveAllocations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AllocationToPerspective");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PROJECTS__3214EC273A9B7770");

            entity.Property(e => e.Period).HasDefaultValue("Current Year");
            entity.Property(e => e.Progress).HasDefaultValue("NOT-STARTED");
            entity.Property(e => e.Type).HasDefaultValue("Individual");

            entity.HasOne(d => d.Creator).WithMany(p => p.ProjectCreators)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PROJECTS__creato__47D18CA4");

            entity.HasOne(d => d.Delegate).WithMany(p => p.ProjectDelegates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PROJECTS__delega__48C5B0DD");

            entity.HasOne(d => d.Objective).WithMany(p => p.Projects).HasConstraintName("FK__PROJECTS__object__7D39791C");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AspNetRoles");

            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Level).HasDefaultValue(100);
        });

        modelBuilder.Entity<RoleClaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AspNetRoleClaims");

            entity.HasOne(d => d.Role).WithMany(p => p.RoleClaims)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
        });

        modelBuilder.Entity<Scorecard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Scorecar__3213E83FF71F892C");

            entity.Property(e => e.Activated).HasDefaultValue(true);
            entity.Property(e => e.DateReviewed).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Score).HasDefaultValue(0.0);

            entity.HasOne(d => d.Company).WithMany(p => p.Scorecards)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Scorecard__compa__7F8BD5E2");

            entity.HasOne(d => d.Owner).WithMany(p => p.ScorecardOwners)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Scorecard__owner__7AC720C5");

            entity.HasOne(d => d.Reviewer).WithMany(p => p.ScorecardReviewers).HasConstraintName("fk_scorecard_commenter");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__settings__3213E83F1CD58AE3");

            entity.Property(e => e.Editable).HasDefaultValue(true);

            entity.HasOne(d => d.Company).WithMany(p => p.Settings).HasConstraintName("company_settings_FK");

            entity.HasOne(d => d.Defaultsetting).WithMany(p => p.Settings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_default_settings");
        });

        modelBuilder.Entity<SettingsColorCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__settings__3213E83FEB58B3F0");

            entity.HasOne(d => d.Company).WithMany(p => p.SettingsColorCodes).HasConstraintName("FK_Company_color_codes");
        });

        modelBuilder.Entity<SettingsScoringRatio>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__settings__3E267235F362527E");

            entity.Property(e => e.CompanyId).ValueGeneratedNever();
            entity.Property(e => e.Actions).HasDefaultValue(20.0);
            entity.Property(e => e.Behavior).HasDefaultValue(100.0);
            entity.Property(e => e.Scorecard).HasDefaultValue(70.0);

            entity.HasOne(d => d.Company).WithOne(p => p.SettingsScoringRatio).HasConstraintName("fk_company_scoring_details");
        });

        modelBuilder.Entity<StrategyMap>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("pk_company_strategy");

            entity.Property(e => e.CompanyId).ValueGeneratedNever();

            entity.HasOne(d => d.Company).WithOne(p => p.StrategyMap)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_company_strategy");
        });

        modelBuilder.Entity<SubActionPlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SubActio__3214EC07A715422C");

            entity.Property(e => e.DeadLine).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Weight).HasDefaultValue(100.0);

            entity.HasOne(d => d.ActionPlan).WithMany(p => p.SubActionPlans)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_SubActionToActionPlan");

            entity.HasOne(d => d.Champion).WithMany(p => p.SubActionPlans).HasConstraintName("FK_SubActionToChampion");
        });

        modelBuilder.Entity<SubordinateTestAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subordin__3213E83F7273C8E7");

            entity.HasOne(d => d.Employee).WithMany(p => p.SubordinateTestAnswerEmployees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Subordina__Emplo__0D1ADB2A");

            entity.HasOne(d => d.EmployeeTestRecord).WithMany(p => p.SubordinateTestAnswers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Subordina__Emplo__7C255952");

            entity.HasOne(d => d.Question).WithMany(p => p.SubordinateTestAnswers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Subordina__Quest__7854C86E");

            entity.HasOne(d => d.Supervisor).WithMany(p => p.SubordinateTestAnswerSupervisors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Subordina__Super__0C26B6F1");
        });

        modelBuilder.Entity<SubordinateTestRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subordin__3213E83FD1D3E010");

            entity.Property(e => e.DateTaken).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Assessment).WithMany(p => p.SubordinateTestRecords)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Subordina__Asses__73901351");

            entity.HasOne(d => d.Employee).WithMany(p => p.SubordinateTestRecordEmployees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Subordina__Emplo__094A4A46");

            entity.HasOne(d => d.Supervisor).WithMany(p => p.SubordinateTestRecordSupervisors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Subordina__Super__0856260D");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__subscrip__3E267235B92144F1");

            entity.Property(e => e.CompanyId).ValueGeneratedNever();
            entity.Property(e => e.Status).HasDefaultValue("suspended");

            entity.HasOne(d => d.Company).WithOne(p => p.Subscription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__subscript__compa__1D66518C");

            entity.HasOne(d => d.User).WithMany(p => p.Subscriptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__subscript__user___1E5A75C5");
        });

        modelBuilder.Entity<SubscriptionDate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__subscrip__3213E83F210500CE");

            entity.Property(e => e.Status).HasDefaultValue("suspended");

            entity.HasOne(d => d.FeatureNameNavigation).WithMany(p => p.SubscriptionDates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__subscript__featu__1B7E091A");

            entity.HasOne(d => d.Subscription).WithMany(p => p.SubscriptionDates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_subscription_dates_sub");
        });

        modelBuilder.Entity<Summaryreport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__summaryr__3213E83F165DC62F");

            entity.Property(e => e.Datecreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Periodfrom).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Periodto).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Company).WithMany(p => p.Summaryreports)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__summaryre__compa__7A92169B");

            entity.HasMany(d => d.Owners).WithMany(p => p.Reports)
                .UsingEntity<Dictionary<string, object>>(
                    "Summaryreportslist",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__summaryre__owner__07EC11B9"),
                    l => l.HasOne<Summaryreport>().WithMany()
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__summaryre__repor__06F7ED80"),
                    j =>
                    {
                        j.HasKey("ReportId", "OwnerId");
                        j.ToTable("summaryreportslist");
                        j.IndexerProperty<int>("ReportId").HasColumnName("report_id");
                        j.IndexerProperty<string>("OwnerId").HasColumnName("owner_id");
                    });
        });

        modelBuilder.Entity<SupervisoryRole>(entity =>
        {
            entity.HasKey(e => new { e.ManagerRole, e.SubordinateRole }).HasName("PK__Supervis__EDEDA63F579FD060");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.ManagerRoleNavigation).WithMany(p => p.SupervisoryRoleManagerRoleNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Superviso__Manag__6576FE24");

            entity.HasOne(d => d.SubordinateRoleNavigation).WithMany(p => p.SupervisoryRoleSubordinateRoleNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Superviso__Subor__666B225D");
        });

        modelBuilder.Entity<SystemPayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SystemPa__3213E83F1EB4FEB9");

            entity.Property(e => e.Datemade).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teams__3213E83F3C8CECC0");

            entity.HasOne(d => d.Company).WithMany(p => p.Teams)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Teams__company_i__01DE32A8");

            entity.HasOne(d => d.Department).WithMany(p => p.Teams).HasConstraintName("FK__Teams__departmen__00EA0E6F");

            entity.HasOne(d => d.Leader).WithMany(p => p.Teams).HasConstraintName("FK__Teams__Leader");
        });

        modelBuilder.Entity<TeamGoal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TeamGoal__3213E83F60D31F0B");

            entity.HasOne(d => d.Company).WithMany(p => p.TeamGoals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TeamGoals__compa__04BA9F53");

            entity.HasOne(d => d.Department).WithMany(p => p.TeamGoals).HasConstraintName("FK__TeamGoals__depar__05AEC38C");

            entity.HasOne(d => d.Team).WithMany(p => p.TeamGoals).HasConstraintName("FK__TeamGoals__team___06A2E7C5");
        });

        modelBuilder.Entity<Teammember>(entity =>
        {
            entity.HasOne(d => d.Memeber).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TEAMMEMBE__MEMEB__294D0584");

            entity.HasOne(d => d.Team).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TEAMMEMBE__TEAM___2858E14B");
        });

        modelBuilder.Entity<Teamsokr>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TEAMSOKR__3214EC2714854D96");

            entity.HasOne(d => d.OwnerNavigation).WithMany(p => p.Teamsokrs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TEAMSOKR__OWNER__23942C2E");
        });

        modelBuilder.Entity<TestAnswerChoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TestAnsw__3213E83F9E38CB7F");

            entity.HasOne(d => d.Question).WithMany(p => p.TestAnswerChoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TestAnswe__Quest__675F4696");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AspNetUsers");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.DateJoined).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UserType).HasDefaultValue("Member");

            entity.HasOne(d => d.Company).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AspNetUse__compa__7913E27D");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK_AspNetUserRoles");
                        j.ToTable("UserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<UserClaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AspNetUserClaims");

            entity.HasOne(d => d.User).WithMany(p => p.UserClaims)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey }).HasName("PK_AspNetUserLogins");

            entity.HasOne(d => d.User).WithMany(p => p.UserLogins)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
        });

        modelBuilder.Entity<UserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name }).HasName("PK_AspNetUserTokens");

            entity.HasOne(d => d.User).WithMany(p => p.UserTokens)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
        });

        modelBuilder.Entity<Vision>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__vision__3213E83F78CC3A0B");

            entity.HasOne(d => d.Company).WithOne(p => p.Vision)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__vision__company___6B2FD77A");
        });

        modelBuilder.Entity<WorkLoad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__work_loa__3213E83F304357C8");

            entity.HasOne(d => d.Scorecard).WithMany(p => p.WorkLoads).HasConstraintName("fk_scorecard_workloads");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
