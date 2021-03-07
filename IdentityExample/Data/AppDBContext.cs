using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExample.Data
{
    //IdentityDbContext contains all the tables
    public class AppDBContext:IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options ):base(options)
        {

        }
    }
}
