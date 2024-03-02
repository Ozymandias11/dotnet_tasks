using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {

        //The following code is used for data seeding
        var serviceProvider = new ServiceCollection()
            .AddDbContext<SchoolDbContext>()
            .BuildServiceProvider();

        using (var context = serviceProvider.GetRequiredService<SchoolDbContext>())
        {

            context.Database.EnsureCreated();


            SeedData(context);
        }



        // I have modified the data such that two teachers John and Jane are teaching
        // student named Giorgi
        using (var context = new SchoolDbContext())
        {
            // Call the function to get teachers for the student named "Giorgi"
            var teachersForGeorge = GetTeachersForStudent(context, "Giorgi");

           
            Console.WriteLine("Teachers who teach the student named 'Giorgi':");
            foreach (var teacher in teachersForGeorge)
            {
                Console.WriteLine($"{teacher.Name} {teacher.Surname}");
            }
        }
    }


    //Include here basically means Joining two tables
    static List<Teacher> GetTeachersForStudent(SchoolDbContext context, string studentName)
    {
        var teachersForStudent = context.Teachers
            .Include(teacher => teacher.Teaches)
            .ThenInclude(teach => teach.Pupil)
            .Where(teacher => teacher.Teaches.Any(teach => teach.Pupil.Name == studentName))
            .ToList();

        return teachersForStudent;
    }


    private static void SeedData(SchoolDbContext context)
    {
        // Check if data already exists
        if (context.Teachers.Any() || context.Pupils.Any() || context.Teaches.Any())
        {
            Console.WriteLine("Data already seeded.");
            return;
        }

        // Seed teachers
        var teachers = new List<Teacher>
        {
            new Teacher { Name = "John", Surname = "Doe", Gender = "Male", Subject = "Math" },
            new Teacher { Name = "Jane", Surname = "Smith", Gender = "Female", Subject = "English" }
            
        };
        context.Teachers.AddRange(teachers);

        // Seed pupils
        var pupils = new List<Pupil>
        {
            new Pupil { Name = "Alice", Surname = "Johnson", Gender = "Female", Class = "A" },
            new Pupil { Name = "Giorgi", Surname = "Sakhelashvili", Gender = "Male", Class = "B" }
            
        };
        context.Pupils.AddRange(pupils);

       
        context.SaveChanges();

        // Seed Teaches (Teacher-Pupil relationship)
        var teaches = new List<Teach>
        {
            new Teach { TeacherId = teachers[0].Id, PupilId = pupils[0].Id },
            new Teach { TeacherId = teachers[1].Id, PupilId = pupils[1].Id },
            new Teach {TeacherId = teachers[0].Id, PupilId= pupils[1].Id},
            
            
        };
        context.Teaches.AddRange(teaches);

      
        context.SaveChanges();

        Console.WriteLine("Data seeded successfully.");
    }


    // Models
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Subject { get; set; }

        public ICollection<Teach> Teaches { get; set; }
    }

    public class Pupil
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Class { get; set; }

        public ICollection<Teach> Teaches { get; set; }
    }

    public class Teach
    {
        public int TeacherId { get; set; }
        public int PupilId { get; set; }

        public Teacher Teacher { get; set; }
        public Pupil Pupil { get; set; }
    }

    public class SchoolDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-G0PQF5H\SQLEXPRESS;Initial Catalog=task_7_database;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        //defining foreign keys
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teach>()
                .HasKey(t => new { t.TeacherId, t.PupilId });

            modelBuilder.Entity<Teach>()
                .HasOne(t => t.Teacher)
                .WithMany(t => t.Teaches)
                .HasForeignKey(t => t.TeacherId);

            modelBuilder.Entity<Teach>()
                .HasOne(t => t.Pupil)
                .WithMany(p => p.Teaches)
                .HasForeignKey(t => t.PupilId);
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<Teach> Teaches { get; set; }
    }
}
