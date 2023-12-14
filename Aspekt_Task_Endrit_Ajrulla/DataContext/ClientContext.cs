using Aspekt_Task_Endrit_Ajrulla.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Aspekt_Task_Endrit_Ajrulla.DataContext
{
    public class ClientContext : DbContext
        {
            public ClientContext(DbContextOptions options)
            :base (options)
            {

            }

       
            public DbSet<Company> Companies { get; set; }
            public DbSet<Contact> Contacts { get; set; }
            public DbSet<Country> Countries { get; set; }

       }
}
