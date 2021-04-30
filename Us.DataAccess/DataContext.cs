using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using UsApplication.Models;

namespace Us.DataAccess
{
    public class DataContext: IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Message> Message { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Connection> Connection { get; set; }

      
    }
}
