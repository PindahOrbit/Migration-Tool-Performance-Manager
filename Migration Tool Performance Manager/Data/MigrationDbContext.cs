using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Migration_Tool_Performance_Manager.Models;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Migration_Tool_Performance_Manager.Data;

public partial class MigrationDbContext : DbContext
{
    public MigrationDbContext()
    {
    }

    public MigrationDbContext(DbContextOptions<MigrationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bsc360AnswerScale> Bsc360AnswerScales { get; set; }

    public virtual DbSet<Bsc360Question> Bsc360Questions { get; set; }

    public virtual DbSet<Bsc360Response> Bsc360Responses { get; set; }

    public virtual DbSet<Bsc360Step> Bsc360Steps { get; set; }

    public virtual DbSet<BscAccount> BscAccounts { get; set; }

    public virtual DbSet<BscAccountType> BscAccountTypes { get; set; }

    public virtual DbSet<BscAccountsNotification> BscAccountsNotifications { get; set; }

    public virtual DbSet<BscAchievementWeight> BscAchievementWeights { get; set; }

    public virtual DbSet<BscApproval> BscApprovals { get; set; }

    public virtual DbSet<BscAudit> BscAudits { get; set; }

    public virtual DbSet<BscBusinessUnit> BscBusinessUnits { get; set; }

    public virtual DbSet<BscClient> BscClients { get; set; }

    public virtual DbSet<BscClient360Policy> BscClient360Policies { get; set; }

    public virtual DbSet<BscClientNotification> BscClientNotifications { get; set; }

    public virtual DbSet<BscComment> BscComments { get; set; }

    public virtual DbSet<BscDepartment> BscDepartments { get; set; }

    public virtual DbSet<BscGoal> BscGoals { get; set; }

    public virtual DbSet<BscIndividualReport> BscIndividualReports { get; set; }

    public virtual DbSet<BscLock> BscLocks { get; set; }

    public virtual DbSet<BscMaxScorecard> BscMaxScorecards { get; set; }

    public virtual DbSet<BscModel> BscModels { get; set; }

    public virtual DbSet<BscMonthly> BscMonthlies { get; set; }

    public virtual DbSet<BscNotificationStatus> BscNotificationStatuses { get; set; }

    public virtual DbSet<BscPGrade> BscPGrades { get; set; }

    public virtual DbSet<BscPep> BscPeps { get; set; }

    public virtual DbSet<BscPepCheckList> BscPepCheckLists { get; set; }

    public virtual DbSet<BscPerspective> BscPerspectives { get; set; }

    public virtual DbSet<BscProject> BscProjects { get; set; }

    public virtual DbSet<BscProjectStatus> BscProjectStatuses { get; set; }

    public virtual DbSet<BscProjectTask> BscProjectTasks { get; set; }

    public virtual DbSet<BscProjectTasksUpdate> BscProjectTasksUpdates { get; set; }

    public virtual DbSet<BscReport> BscReports { get; set; }

    public virtual DbSet<BscReportGroup> BscReportGroups { get; set; }

    public virtual DbSet<BscReportingPeriod> BscReportingPeriods { get; set; }

    public virtual DbSet<BscScore> BscScores { get; set; }

    public virtual DbSet<BscScorecard> BscScorecards { get; set; }

    public virtual DbSet<BscScorecardDeletion> BscScorecardDeletions { get; set; }

    public virtual DbSet<BscScorecardSetting> BscScorecardSettings { get; set; }

    public virtual DbSet<BscScorecardSettings2> BscScorecardSettings2s { get; set; }

    public virtual DbSet<BscScorecardStatus> BscScorecardStatuses { get; set; }

    public virtual DbSet<BscSignature> BscSignatures { get; set; }

    public virtual DbSet<BscStrategy> BscStrategies { get; set; }

    public virtual DbSet<BscSummaryRating> BscSummaryRatings { get; set; }

    public virtual DbSet<BscTarget> BscTargets { get; set; }

    public virtual DbSet<BscTaskComment> BscTaskComments { get; set; }

    public virtual DbSet<BscUrl> BscUrls { get; set; }

    public virtual DbSet<BscWatchList> BscWatchLists { get; set; }

    public virtual DbSet<BscYear> BscYears { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("name=migrationConn", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.40-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Bsc360AnswerScale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Bsc360Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Bsc360Response>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Date).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<Bsc360Step>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<BscAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.BusinessUnit).HasDefaultValueSql("'1'");
            entity.Property(e => e.Date).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Model).HasDefaultValueSql("'1'");
            entity.Property(e => e.Status).HasDefaultValueSql("'1'");
        });

        modelBuilder.Entity<BscAccountType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Model).HasDefaultValueSql("'1'");
        });

        modelBuilder.Entity<BscAccountsNotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.DateTime).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<BscAchievementWeight>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.ActionplanWeight).HasDefaultValueSql("'0'");
            entity.Property(e => e.BehavioralWeight).HasDefaultValueSql("'0'");
            entity.Property(e => e.ScorecardWeight).HasDefaultValueSql("'100'");
        });

        modelBuilder.Entity<BscApproval>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Status).HasDefaultValueSql("'1'");
            entity.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate();
        });

        modelBuilder.Entity<BscAudit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Date).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<BscBusinessUnit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<BscClient>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PRIMARY");
        });

        modelBuilder.Entity<BscClient360Policy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Mandatory).HasDefaultValueSql("'1'");
        });

        modelBuilder.Entity<BscClientNotification>(entity =>
        {
            entity.HasKey(e => e.NotificationsId).HasName("PRIMARY");

            entity.Property(e => e.DateTime).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Status).HasDefaultValueSql("'1'");
        });

        modelBuilder.Entity<BscComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Date).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedTime)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<BscDepartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<BscGoal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Cumulative).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<BscIndividualReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate();
        });

        modelBuilder.Entity<BscLock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedTime)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<BscMaxScorecard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.LastUpdated)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<BscModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<BscMonthly>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Date)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<BscNotificationStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<BscPGrade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<BscPep>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Date).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<BscPepCheckList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Date).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.LastUpdated)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<BscPerspective>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<BscProject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate();
        });

        modelBuilder.Entity<BscProjectStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<BscProjectTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Completion).HasDefaultValueSql("'0'");
            entity.Property(e => e.LastUpdated)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.StartDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<BscProjectTasksUpdate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Date).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<BscReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Date).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<BscReportGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<BscReportingPeriod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Date).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<BscScore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Date).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedOn)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<BscScorecard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Date).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.LastUpdate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Lock1).HasDefaultValueSql("'0'");
            entity.Property(e => e.Status).HasDefaultValueSql("'1'");
        });

        modelBuilder.Entity<BscScorecardDeletion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate();
        });

        modelBuilder.Entity<BscScorecardSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Status).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<BscScorecardSettings2>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Status).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<BscScorecardStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<BscStrategy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate();
        });

        modelBuilder.Entity<BscSummaryRating>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<BscTarget>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Direction).HasDefaultValueSql("'1'");
            entity.Property(e => e.ReportingFrequency).HasDefaultValueSql("'M'");
            entity.Property(e => e.TargetPeriod).HasDefaultValueSql("'Y'");
            entity.Property(e => e.Unit).HasDefaultValueSql("'#'");
        });

        modelBuilder.Entity<BscTaskComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Date).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedTime)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<BscUrl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<BscWatchList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.LastUpdate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<BscYear>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("'0000-00-00 00:00:00'");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
