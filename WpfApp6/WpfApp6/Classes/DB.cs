using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp6.Models;

namespace WpfApp6.Classes
{
    internal class DB
    {
        public static DemDbContext db = new DemDbContext();
        public DB() { }
    }
}
