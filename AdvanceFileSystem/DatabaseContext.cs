using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AdvanceFileSystem.Models;

namespace AdvanceFileSystem
{
    class DatabaseContext :DbContext
    {
        public DatabaseContext ()
            : base("Server=127.0.0.1; Database=FileSystem; User Id =sa ; Password=1234; Integrated Security = True")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addersses { get; set; }
        
    }
}
