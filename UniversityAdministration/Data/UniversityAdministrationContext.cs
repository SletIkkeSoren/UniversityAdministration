using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityAdministration.Models.Entities;

namespace UniversityAdministration.Models
{
    public class UniversityAdministrationContext : DbContext
    {
        public UniversityAdministrationContext (DbContextOptions<UniversityAdministrationContext> options)
            : base(options)
        {
        }

        public DbSet<UniversityAdministration.Models.Entities.Student> Student { get; set; }

        public DbSet<UniversityAdministration.Models.Entities.Course> Course { get; set; }

        public DbSet<UniversityAdministration.Models.Entities.EnrollMent> EnrollMent { get; set; }
    }
}
