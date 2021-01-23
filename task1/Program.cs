using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;


namespace task1
{
    public class Context : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Engineer> Engineers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Doctor>().Property(d => d.Specialization).IsRequired();
            modelBuilder.Entity<Employee>().Property(e => e.Name).HasMaxLength(128);
        }
    }
    public class GetAllDoctorsSpecializationInCity
    {
        public List<string> GetAllSpecializations(City city)
        {
            
            using (var ctx = new Context())
            {
                return ctx.Doctors.Where(d => d.CityId == city.Id).Select(d => d.Specialization).ToList();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("end");
        }
    }

}
