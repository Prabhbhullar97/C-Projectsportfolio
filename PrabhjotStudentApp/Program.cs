using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore; // Required for DbContext and UseSqlServer

namespace StudentDatabaseApp
{
    // 1. Create a basic Student class (The Model)
    public class Student
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
    }

    // 2. Create the Database Context (The Code-First Bridge)
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connects to a local database named 'StudentDb'
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=StudentDb;Trusted_Connection=True;");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SchoolContext())
            {
                Console.WriteLine("Final Assignment: Creating database and adding student...");

                // 2. Add one student to the database
                var student = new Student { StudentName = "Prabhjot Singh Bhullar" };
                db.Students.Add(student);
                db.SaveChanges(); // This triggers the database creation and data insertion

                Console.WriteLine("Success! Student has been added to the database.");

                // Verify the entry
                var studentList = db.Students.ToList();
                foreach (var s in studentList)
                {
                    Console.WriteLine($"ID: {s.StudentId}, Name: {s.StudentName}");
                }

                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
        }
    }
}