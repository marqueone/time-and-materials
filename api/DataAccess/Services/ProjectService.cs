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

        internal async Task<bool> Add(string name, ProjectType projectType, DateTime start, DateTime end, DateTime projectedEnd)
        {
            Projects.Add(new Project
            {
                Name = name,
                ProjectType = projectType,
                Start = start,
                End = end,
                ProjectedEnd = projectedEnd,
                IsComplete = false
            });

            return await _context.SaveChangesAsync() >= 0;
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
    }
}