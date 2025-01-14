using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Migration_Tool_Performance_Manager.Data;
using Migration_Tool_Performance_Manager.Data2;
using Migration_Tool_Performance_Manager.Models2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Migration_Tool_Performance_Manager.Controllers
{
    [ApiController]
    [Route("api")]
    public class Migration : ControllerBase
    {

        MigrationDbContext _mysql_context;
        ServerDbContext _context;
        public Migration(ServerDbContext context, MigrationDbContext new_context)
        {
            _context = context;
            _mysql_context = new_context;
        }
        [HttpGet("migrate")]
        public async Task<IActionResult> Migrate()
        {




            var scorecards = await _mysql_context.BscScorecards.AsNoTracking()
                .AsSplitQuery()
                .ToListAsync();


            var oldPerspectives = await _mysql_context.BscPerspectives.AsNoTracking()
                .AsSplitQuery()
                .OrderBy(d => d.Id)
                .ToListAsync();


            var oldBusinessUnits = await _mysql_context.BscBusinessUnits.AsNoTracking()
                .AsSplitQuery()
                .ToListAsync();

            var oldDepartments = await _mysql_context.BscDepartments.AsNoTracking()
                .AsSplitQuery()
                .ToListAsync();

            var oldGoals = await _mysql_context.BscGoals.AsNoTracking()
                .AsSplitQuery()
                .ToListAsync();

            var oldTargets = await _mysql_context.BscTargets.AsNoTracking()
                .AsSplitQuery()
                .ToListAsync();

            var oldActuals = await _mysql_context.BscMonthlies.AsNoTracking()
                .AsSplitQuery()
                .ToListAsync();



            var users = await _mysql_context.BscAccounts.AsNoTracking()
                .AsSplitQuery()
                .ToListAsync();




            //create connection

            Company company = new Company()
            {
                Name = "Aripo",
                Address = "Aripo",
                Website = "Aripo",
                Email = "admin@aripo.com",
                Phone = "1234567",
                Model = "bsc",
                FiscalEnd = new DateOnly(2025, 12, 31),
                FiscalStart = new DateOnly(2025, 1, 1),

            };


            _context.Add(company);

            int companyAdded = await _context.SaveChangesAsync();

            var defaultPerspectives = await _context.DefaultPerspectives.ToListAsync();

            List<Perspective> perspectives = new List<Perspective>();

            int counter = 1;
            foreach (var defaultPerspective in oldPerspectives)
            {
                Perspective perspective = new Perspective()
                {
                    Name = defaultPerspective.Name,
                    CompanyId = company.Id,
                    Priority = counter++,
                    Type = "bsc",
                    OldId = defaultPerspective.Id,
                    PerspectiveAllocations = new List<PerspectiveAllocation>()
                    {
                        new PerspectiveAllocation()
                        {
                            CompanyId = company.Id,
                            AllocatedWeight = 25,

                        }
                    }

                };
                perspectives.Add(perspective);
            }

            _context.AddRange(perspectives);

            await _context.SaveChangesAsync();


            //adding stages

            var actionPlanStages = await _context.ActionPlanStages.ToListAsync();
            foreach (var item in actionPlanStages)
            {
                CompanyActionStage companyActionStage = new CompanyActionStage()
                {
                    Color = item.Color,
                    CompanyId = company.Id,
                    StageId = item.Id,
                };
                _context.Add(companyActionStage);
            }

            // adding color codes
            PasswordHasher<string> hasher = new PasswordHasher<string>();
            List<User> users1 = new List<User>();

            foreach (var item in users)
            {
                //convert mysqlUsers to server users
                users1.Add(new Models2.User()
                {
                    Id = Guid.NewGuid().ToString(),
                    FullName = item.FullName,
                    ProfilePictureLocation = item.ProfilePic,
                    Email = item.Email,
                    NormalizedEmail = item.Email.ToUpper(),
                    NormalizedUserName = item.Email.ToUpper(),
                    UserName = item.Email,

                    CompanyId = company.Id,
                    PasswordHash = hasher.HashPassword(item.Email, item.Password),
                    OldId = item.Id.ToString(),
                    ManagerOldId = item.Supervisor,
                    /*  EmployeeDetailEmployee = new EmployeeDetail()
                      {
                          Position = item.Position,
                          CompanyId = company.Id,
                          IsCooperate = false,


                      },*/
                    Model = "bsc"

                });
            }

            _context.AddRange(users1);




            //create business units

            foreach (var item in oldBusinessUnits)
            {
                var businessUnit = new BusinessUnit()
                {
                    Name = item.Name,
                    CompanyId = company.Id,
                    OldId = item.Id,
                };
                _context.Add(businessUnit);
            }

            //create departments
            foreach (var item in oldDepartments)
            {
                var department = new Department()
                {
                    Name = item.Department,
                    CompanyId = company.Id,
                    OldId = item.Id,
                };
                _context.Add(department);
            }

            await _context.SaveChangesAsync();

            foreach (var item in users1)
            {
                //code yakamiriria izvozvo




            }

            //adding scorecards
            List<Scorecard> scorecards1 = new List<Scorecard>();
            foreach (var item in scorecards)
            {

                var owner = users1.FirstOrDefault(f => f.OldId == item.Owner.ToString());

                if (owner is null)
                {
                    continue;
                }

                scorecards1.Add(new Scorecard()
                {
                    OwnerId = owner.Id,
                    Activated = true,
                    IsActive = true,
                    PeriodFrom = DateTime.Parse(item.Start),
                    PeriodTo = DateTime.Parse(item.ReportingPeriod),
                    CompanyId = company.Id,
                    DateReviewed = item.LastUpdate,
                    IsLocked = item.Lock1 == "0" ? true : false,
                    Submitted = false,
                    OldId = item.Id,
                    EmployeePerspectives = perspectives.Select(f => new EmployeePerspective()
                    {
                        PerspectiveId = f.Id,
                        EmployeeId = owner.Id,
                        Weight = 25,
                    }).ToList()
                });


            }


            _context.AddRange(scorecards1);




            await _context.SaveChangesAsync();


            List<Goal> newGoals = new List<Goal>();

            foreach (var item in scorecards1)
            {
                //create goals

                var itsGoals = oldGoals.Where(f => f.ScorecardId == item.OldId.ToString()).ToList();

                if (!itsGoals.Any())
                {
                    continue;
                }

                var goals = itsGoals.Select(f => new Goal()
                {
                    Name = f.Goal,
                    ScorecardId = item.Id,
                    CompanyId = company.Id,
                    OldId = f.Id,
                    Datecreated = DateOnly.FromDateTime(DateTime.Now),
                    Approved = true,
                    Description = f.GoalExplanation,
                    UserId = item.OwnerId,
                    PerspectiveId = perspectives.FirstOrDefault(d => d.OldId.ToString() == f.PerspectiveId) == null ?
                                             null : perspectives.First(d => d.OldId.ToString() == f.PerspectiveId).Id,

                }).ToList();

                newGoals.AddRange(goals);
            }
            _context.AddRange(newGoals);
            await _context.SaveChangesAsync();

            List<Measure> newMeasures = new List<Measure>();
            foreach (var item in newGoals)
            {

                var scorecard = scorecards1.FirstOrDefault(d => d.Id == item.ScorecardId);

                var measures = oldTargets.Where(f => f.GoalId == item.OldId.ToString()).Select(f => new Measure()
                {
                    GoalId = item.Id,
                    CompanyId = company.Id,
                    OldId = f.Id,
                    Name = f.Measure,
                    PerspectiveId = item.PerspectiveId,
                    ScorecardId = item.ScorecardId.Value,

                    MeasureUnit = new MeasureUnit
                    {
                        CompanyId = company.Id,
                        MeasureId = item.Id,
                        AllocatedWeight =string.IsNullOrEmpty( f.AllocatedWeight) ? 0 : double.Parse(f.AllocatedWeight),
                        Approved = true,
                        BaseTarget =string.IsNullOrEmpty( f.BaseTarget  )? 0 : double.Parse(f.BaseTarget),
                        StretchedTarget =string.IsNullOrEmpty( f.StretchTarget) ? 0 : double.Parse(f.StretchTarget),
                        GoalId = item.Id,
                        PerspectiveId = item.PerspectiveId ==null? perspectives.FirstOrDefault().Id : item.PerspectiveId.Value,
                        RecordingFrequency = f.ReportingFrequency,
                        ScorecardId = scorecard.Id,
                        TargetPeriod = f.TargetPeriod,
                        Unit = f.Unit,


                    }

                }).ToList();

                newMeasures.AddRange(measures);
            }

            _context.AddRange(newMeasures);
            await _context.SaveChangesAsync();

            List<Kpiactual> newActuals = new List<Kpiactual>();
            foreach (var measure in newMeasures)
            {
                var itsActuals = oldActuals.Where(f => f.TargetId == measure.OldId.ToString()).ToList();

                if (!itsActuals.Any())
                {
                    continue;
                }

                var goal = newGoals.FirstOrDefault(f => f.Id == measure.GoalId);

                var actuals = itsActuals.Select(f => new Kpiactual()
                {
                    Actual = string.IsNullOrEmpty(f.Amount) ? 0 : double.Parse(f.Amount),
                    CompanyId = company.Id,
                    DateRecorded = f.Date,
                    MeasureUnitId = measure.Id,

                    ScorecardId = measure.ScorecardId,
                    Tp = measure.MeasureUnit.TargetPeriod,
                    St = measure.MeasureUnit.StretchedTarget,
                    Bt = measure.MeasureUnit.BaseTarget,
                    Aw = measure.MeasureUnit.AllocatedWeight,
                    Frequency = measure.MeasureUnit.RecordingFrequency,
                    EmployeeId = goal.UserId,
                    DateUpdated = DateTime.Now,
                    Evidence = "",
                    Score = string.IsNullOrEmpty(f.Score) ? 0 : double.Parse(f.Score),
                }).ToList();

                newActuals.AddRange(actuals);
            }

            _context.AddRange(newActuals);
            await _context.SaveChangesAsync();

            return Ok(scorecards1.Count());


        }



    }
}
