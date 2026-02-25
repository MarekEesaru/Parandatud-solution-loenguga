using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abc.Soft.Web.Model;

namespace Abc.Soft.Web.Data
{
    public class AbcSoftWebContext : DbContext
    {
        public AbcSoftWebContext (DbContextOptions<AbcSoftWebContext> options)
            : base(options)
        {
        }

        public DbSet<Abc.Soft.Web.Model.Movie> Movie { get; set; } = default!;
    }
}
