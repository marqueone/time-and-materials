using System.Collections.Generic;
using System.Threading.Tasks;
using Marqueone.TimeAndMaterials.Api.Entities;
using Marqueone.TimeAndMaterials.Api.Entities.Relationships;
using Microsoft.EntityFrameworkCore;
using Transform = Marqueone.TimeAndMaterials.Api.Models.Transforms;
using Marqueone.TimeAndMaterials.Api.Extentions;
using System;
using Marqueone.TimeAndMaterials.Api.Models;
using System.Linq;

namespace Marqueone.TimeAndMaterials.Api.DataAccess.Services
{
    public class ProjectService
    {
        private TamContext _context { get; set; }

        private DbSet<Project> Projects => _context.Projects;
        private DbSet<WorkOrder> WorkOrders => _context.WorkOrders;
        private DbSet<TimeEntry> TimeEntries => _context.TimeEntries;
        private DbSet<MaterialWorkOrder> MaterialWorkOrders => _context.MaterialWorkOrders;
        private DbSet<Company> Companies => _context.Companies;

        public ProjectService(TamContext context)
        {
            _context = context;
        }

        internal async Task<IList<Transform.Project>> GetProjects()
        {
            var projects = new List<Transform.Project>();

            foreach (var project in await Projects.ToListAsync())
            {
                projects.Add(project.ToProject());
            }

            return projects;
        }

        internal async Task<Transform.Project> GetById(int id)
        {
            var project = await Projects.SingleAsync(p => p.Id == id);
            return project.ToProject();
        }

        internal async Task<IList<Transform.Project>> GetByType(ProjectType type)
        {
            return await Projects.Where(p => p.ProjectType == type).Select(p => p.ToProject()).ToListAsync();
        }

        internal async Task<IList<Transform.Project>> GetByCompany(int id)
        {
            var company = await Companies
                                    .Include(c => c.Projects)
                                    .Include(c => c.Addresses)
                                    .SingleOrDefaultAsync(c => c.Id == id);
            if(company != null)
            {
                return company.Projects?.Select(p => p.ToProject()).ToList() ?? new List<Transform.Project>();
            }

            return new List<Transform.Project>();
        }

        internal async Task<bool> Add(int companyId, string name, ProjectType projectType, DateTime start, DateTime end, DateTime projectedEnd)
        {
            var company = await Companies.SingleOrDefaultAsync(c => c.Id == companyId);

            if (company != null)
            {
                var project = new Project
                {
                    Name = name,
                    ProjectType = projectType,
                    Start = start,
                    End = end,
                    ProjectedEnd = projectedEnd,
                    IsComplete = false
                };

                Projects.Add(project);
                await _context.SaveChangesAsync();

                if (company.Projects == null)
                {
                    company.Projects = new List<Project>
                    {
                        project
                    };
                }
                else
                {
                    company.Projects.Add(project);
                }

                return await _context.SaveChangesAsync() >= 0;
            }

            return false;
        }

        internal async Task<bool> Update(int id, string name, ProjectType projectType, DateTime start, DateTime end, DateTime projectedEnd, bool isComplete)
        {
            var project = await Projects.SingleOrDefaultAsync(s => s.Id == id);

            if (project != null)
            {
                project.Name = name;
                project.ProjectType = projectType;
                project.Start = start;
                project.End = end;
                project.ProjectedEnd = projectedEnd;
                project.IsComplete = isComplete;

                return await _context.SaveChangesAsync() >= 0;
            }

            return false;
        }

        #region workorders
        internal async Task<IList<Transform.WorkOrder>> GetWorkOrders()
        {
            return await WorkOrders.Select(wo => wo.ToWorkOrder()).ToListAsync();
        }

        internal async Task<Transform.WorkOrder> GetWorkOrdersById(int id)
        {
            var workOrder = await WorkOrders.SingleAsync(wo => wo.Id == id);
            return workOrder.ToWorkOrder();
        }

        internal async Task<IList<Transform.WorkOrder>> GetWorkOrderByProjectId(int id)
        {
            return await WorkOrders.Where(wo => wo.Project.Id == id).Select(wo => wo.ToWorkOrder()).ToListAsync();
        }

        internal async Task<bool> AddProjectWorkOrder(string workOrderId, int projectId)
        {
            WorkOrders.Add(new WorkOrder
            {
                WorkOrderId = workOrderId,
                Project = Projects.Single(p => p.Id == projectId)
            });

            return await _context.SaveChangesAsync() >= 0;
        }

        internal async Task<bool> AddWorkOrderTime(int id, int employeeId, DateTime start, DateTime end, bool isWeekend, bool isHoliday, bool hasOverTime)
        {
            var workOrder = await WorkOrders.SingleOrDefaultAsync(wo => wo.Id == id);
            if(workOrder != null)
            {
                var timeEntry = new TimeEntry
                {
                    EmployeeId = employeeId,
                    Start = start,
                    End = end,
                    IsWeekEnd = isWeekend,
                    IsHoliday = isHoliday,
                    HasOverTime = hasOverTime
                };
                TimeEntries.Add(timeEntry);
                
                var result = await _context.SaveChangesAsync() >= 0;
                if(result)
                {
                    if(workOrder.TimeEntries != null)
                    {
                        workOrder.TimeEntries.Add(timeEntry);
                    } 
                    {
                        workOrder.TimeEntries = new List<TimeEntry>{ timeEntry };
                    }
                }
            }

            return false;
        }

        #endregion
    }
}