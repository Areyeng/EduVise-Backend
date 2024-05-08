using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using EduVise.Authorization.Roles;
using EduVise.Authorization.Users;
using EduVise.MultiTenancy;
using AutoMapper.Execution;
using EduVise.Domain;

namespace EduVise.EntityFrameworkCore
{
    public class EduViseDbContext : AbpZeroDbContext<Tenant, Role, User, EduViseDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Learner> Learners { get; set; }
        public DbSet<Institution> Institutions{ get; set; }
        public DbSet<LearnerInstitution> LearnerInstitutions { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<LearnerCourse> LearnerCourses { get; set; }
        public DbSet<Funding> Fundings { get; set; }
        public DbSet<LearnerFunding> LearnerFundings { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<LearnerEvent> LearnerEvents { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<LearnerSkill> LearnerSkills { get; set; }
        public DbSet<SavedResponse> SavedResponses { get; set; }
        public DbSet<Question> Questions { get; set; }
        public EduViseDbContext(DbContextOptions<EduViseDbContext> options)
            : base(options)
        {
        }
    }
}
