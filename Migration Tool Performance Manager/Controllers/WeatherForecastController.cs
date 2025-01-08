using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Migration_Tool_Performance_Manager.Data;
using Migration_Tool_Performance_Manager.Data2;
using Migration_Tool_Performance_Manager.Models2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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

            
            var oldBusinessUnits = await _mysql_context.BscBusinessUnits.AsNoTracking()
                .AsSplitQuery()
                .ToListAsync();
            
            var oldDepartments = await _mysql_context.BscDepartments.AsNoTracking()
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
            foreach (var defaultPerspective in defaultPerspectives)
            {
                Perspective perspective = new Perspective()
                {
                    Name = defaultPerspective.Name,
                    CompanyId = company.Id,
                    Priority = counter++,
                    Type = "bsc",
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
                    ManagerOldId =   item.Supervisor,
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

                //look for supervisor using old id
                var supervisor  = users1.FirstOrDefault(f => f.OldId == item.ManagerOldId.ToString());

                //get business 
                var business =   oldBusinessUnits.FirstOrDefault(f => f.Id == item.BusinessUnit);

                //get departments 
                var department = oldDepartments.FirstOrDefault(f => f.Id == item.DepartmentId);


                item.EmployeeDetailEmployee = new EmployeeDetail()
                {
                    BusinessUnit = ,
                    DepartmentId = ,
                    Position = ,
                    CompanyId = company.Id,
                    SupervisorId = supervisor == null ? item.Id : supervisor.Id,

                };
            }

            //adding scorecards
            List<Scorecard> scorecards1 = new List<Scorecard>();
            foreach (var item in scorecards)
            {

                var owner = users1.FirstOrDefault(f => f.OldId == item.Owner.ToString());

                if(owner is null)
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
                    IsLocked = item.Lock1 == "0" ? false : true,
                    Submitted = true,
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

            return Ok(scorecards1.Count());


        }



    }
}
