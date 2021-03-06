﻿namespace UniversityAdministration.Models.Entities
{
    public class EnrollMent
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int Grade { get; set; }

        //Navigation prop
        public Course Course{ get; set; }
        public Student Student { get; set; }
    }
}