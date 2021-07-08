using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RifatSirProjectAPI5.Models
{
    public class DatabaseContext : DbContext
    {
        //public AuthenticationContext(DbContext option)
        public const string ConnectionString = @"Server=LAPTOP-COS90VRD\SQLEXPRESS; Database=projectLite ; Trusted_Connection=true";

        public DbSet<StudentAuth> StudentAuthTable { get; set; }
        public DbSet<StudentBasicInfo> StudentBasicInfoTable { get; set; }
        public DbSet<AdminAuth> AdminAuthTable { get; set; }
        public DbSet<CoursePosts> CoursePostsTable { get; set; }
        public DbSet<Attendance> AttendanceTable { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
