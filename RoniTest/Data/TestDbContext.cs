using Microsoft.EntityFrameworkCore;
using RoniTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoniTest.Data
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<RoomType> RoomTypes { get; set; }
    }
}
