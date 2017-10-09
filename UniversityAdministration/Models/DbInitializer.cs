using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityAdministration.Models.Entities;

namespace UniversityAdministration.Models
{
    internal class DbInitializer
    {
        internal static void Initialize(UniversityAdministrationContext context)
        {
            if (context.Student.Any())
            {
                return;
            }
            var students = new Student[]
            {
                new Student { FirstName = "Carson",   LastName = "Alexander",
                    EnrollMentDate = DateTime.Parse("2010-09-01") },
                new Student { FirstName = "Meredith", LastName = "Alonso",
                    EnrollMentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstName = "Arturo",   LastName = "Anand",
                    EnrollMentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstName = "Gytis",    LastName = "Barzdukas",
                    EnrollMentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstName = "Yan",      LastName = "Li",
                    EnrollMentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstName = "Peggy",    LastName = "Justice",
                    EnrollMentDate = DateTime.Parse("2011-09-01") },
                new Student { FirstName = "Laura",    LastName = "Norman",
                    EnrollMentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstName = "Nino",     LastName = "Olivetto",
                    EnrollMentDate = DateTime.Parse("2005-09-01") }
            };

            foreach (Student s in students)
            {
                context.Student.Add(s);
            }
            context.SaveChanges();


            var courses = new Course[]
            {
                new Course {CourseId = 1050, Title = "Chemistry", Etcs = 5},
                new Course {CourseId = 4022, Title = "Microeconomics", Etcs = 5 },
                new Course {CourseId = 4041, Title = "Computer Sciece", Etcs = 5 },
                new Course {CourseId = 1045, Title = "Calculus", Etcs = 5 },
            };

            foreach (Course c in courses)
            {
                context.Course.Add(c);
            }
            context.SaveChanges();

            var enrollments = new EnrollMent[]
            {
                new EnrollMent {
                    StudentId = students.Single(s => s.LastName == "Alexander").StudentId,
                    CourseId = courses.Single(c => c.Title == "Chemistry" ).CourseId,
                    Grade = 1
                },
                    new EnrollMent {
                    StudentId = students.Single(s => s.LastName == "Alexander").StudentId,
                    CourseId = courses.Single(c => c.Title == "Microeconomics" ).CourseId,
                    Grade = 1
                    },
                    new EnrollMent {
                    StudentId = students.Single(s => s.LastName == "Alexander").StudentId,
                    CourseId = courses.Single(c => c.Title == "Macroeconomics" ).CourseId,
                    Grade = 1
                    },
                    new EnrollMent {
                        StudentId = students.Single(s => s.LastName == "Alonso").StudentId,
                    CourseId = courses.Single(c => c.Title == "Calculus" ).CourseId,
                    Grade = 1
                    },
                    new EnrollMent {
                        StudentId = students.Single(s => s.LastName == "Alonso").StudentId,
                    CourseId = courses.Single(c => c.Title == "Trigonometry" ).CourseId,
                    Grade = 5
                    },
                    new EnrollMent {
                    StudentId = students.Single(s => s.LastName == "Alonso").StudentId,
                    CourseId = courses.Single(c => c.Title == "Composition" ).CourseId,
                    Grade = 4
                    },
                    new EnrollMent {
                    StudentId = students.Single(s => s.LastName == "Anand").StudentId,
                    CourseId = courses.Single(c => c.Title == "Chemistry" ).CourseId
                    },
                    new EnrollMent {
                    StudentId = students.Single(s => s.LastName == "Anand").StudentId,
                    CourseId = courses.Single(c => c.Title == "Microeconomics").CourseId,
                    Grade = 3
                    },
                new EnrollMent {
                    StudentId = students.Single(s => s.LastName == "Barzdukas").StudentId,
                    CourseId = courses.Single(c => c.Title == "Chemistry").CourseId,
                    Grade = 2
                    },
                    new EnrollMent {
                    StudentId = students.Single(s => s.LastName == "Li").StudentId,
                    CourseId = courses.Single(c => c.Title == "Composition").CourseId,
                    Grade = 7
                    },
                    new EnrollMent {
                    StudentId = students.Single(s => s.LastName == "Justice").StudentId,
                    CourseId = courses.Single(c => c.Title == "Literature").CourseId,
                    Grade = 8
                    }
            };

            foreach (EnrollMent e in enrollments)
            {
                var enrollmentInDataBase = context.EnrollMent.Where(
                    s =>
                            s.StudentId == e.StudentId &&
                            s.Course.CourseId == e.CourseId).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.EnrollMent.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
