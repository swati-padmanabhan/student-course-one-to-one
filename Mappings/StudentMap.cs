using FluentNHibernate.Mapping;
using StudentCourseOneToOne.Models;

namespace StudentCourseOneToOne.Mappings
{
    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Table("Students");
            Id(s => s.StudentId).GeneratedBy.Identity();
            Map(s => s.Name);
            Map(s => s.Age);
            Map(s => s.Email);
            HasOne(s => s.Course).Cascade.All().PropertyRef(c => c.Student)
                .Constrained();
        }
    }
}