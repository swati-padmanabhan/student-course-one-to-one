using FluentNHibernate.Mapping;
using StudentCourseOneToOne.Models;

namespace StudentCourseOneToOne.Mappings
{
    public class CourseMap : ClassMap<Course>
    {
        public CourseMap()
        {
            Table("Courses");
            Id(c => c.CourseId).GeneratedBy.Identity();
            Map(c => c.CourseName);
            Map(c => c.Duration);
            References(c => c.Student).Column("student_id").Unique().Cascade.None();
        }
    }
}