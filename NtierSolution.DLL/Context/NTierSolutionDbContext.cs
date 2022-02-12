using NTierSolution.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSolution.DLL.Context
{
    public class NTierSolutionDbContext : DbContext
    {
        public DbSet<Students>? Students { get; set; }
    }
}
