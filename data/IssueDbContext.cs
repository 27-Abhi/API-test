using Microsoft.EntityFrameworkCore;
using trackingapi.Models;

namespace trackingapi.data
{
    public class IssueDbContext : DbContext  //inherits...it is from entity framework core package 
    {
        public IssueDbContext(DbContextOptions<IssueDbContext> options) //setting some options needed by dbcontext like connections string
            : base(options)
        {

        }
        public DbSet<Issue> Issues { get; set; } //representattion of the table in the database...helps us manipulate database

    }
}
