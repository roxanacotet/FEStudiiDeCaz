using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FEStudiiDeCazLab
{
    class ModelBusiness: DbContext
    {
        public DbSet<Business> Businesses { get; set; }
    }
}
