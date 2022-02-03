using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RPC_Autentication_Module.Models;

namespace RPC_Autentication_Module.Data
{
    public class RPC_Autentication_ModuleContext : DbContext
    {
        public RPC_Autentication_ModuleContext (DbContextOptions<RPC_Autentication_ModuleContext> options)
            : base(options)
        {
        }

        public DbSet<RPC_Autentication_Module.Models.User> User { get; set; }
    }
}
