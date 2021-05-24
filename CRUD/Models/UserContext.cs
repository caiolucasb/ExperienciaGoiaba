using System;
using Microsoft.EntityFrameworkCore;
using User.Model;

namespace User.Context
{
    class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            
        }
        public DbSet<UserModel> Users{get;set;}
    }
}