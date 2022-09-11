using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public interface ICourseService
    {
    Task<bool> CourseRate(CourseCreate model);
    Task<IEnumerable<CourseListItem>> GetCourses();
    Task<bool> DeleteCourses(int id);
    Task<CourseListItem> GetCourseById(int id);
    Task<bool> UpdateCourses(int id, CoursesEdit model);
    Task<CoursesEdit> GetCoursesEdit(int id);

    }

