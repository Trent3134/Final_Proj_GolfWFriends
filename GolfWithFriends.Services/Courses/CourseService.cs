using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class CourseService : ICourseService
    {
    private readonly ApplicationDbContext _context;
    public CourseService(ApplicationDbContext context)
    {
            _context = context;
    }

    public async Task<bool> CourseRate(CourseCreate model)
    {
        if (model == null) return false;
        var course = new Courses()
        {
            Name = model.Name,
            FirstAndLastName = model.FirstAndLastName,
            Location = model.Location,
            Rating = model.Rating,
            Difficulty = model.difficulty,
        };
        _context.Course.Add(course);
        await _context.SaveChangesAsync();
        return true;

    }
    public async Task<CourseListItem> GetCourseById(int id)
    {
        var courses = await _context.Course.FindAsync(id);
        return new CourseListItem
        {
            Id = courses.Id,
            Name = courses.Name,
            FirstAndLastName = courses.FirstAndLastName,
            Location = courses.Location,
            Rating = courses.Rating,
            Difficulty = courses.Difficulty,

        };

    }

    public async Task<IEnumerable<CourseListItem>> GetCourses()
    {
        var course = await _context.Course.Select(c => new CourseListItem
        {
            Id = c.Id,
            FirstAndLastName= c.FirstAndLastName,
            Name = c.Name,
            Location = c.Location,
            Rating = c.Rating,
            Difficulty = c.Difficulty,
        }).ToListAsync();
        return course;
    }
    public async Task<CoursesEdit> GetCoursesEdit(int id)
    {
        var course = await _context.Course.FindAsync(id);
        return new CoursesEdit
        {
            Id = course.Id,
            Rating = course.Rating,
           difficulty = course.Difficulty

        };
    }

    public async Task<bool> DeleteCourses(int id)
    {
        var courses = await _context.Course.FindAsync(id);

         _context.Remove(courses);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> UpdateCourses(int id, CoursesEdit model)
    {
        var course = await _context.Course.FindAsync(id);
        if(course == null) return false;

        course.Rating = model.Rating;
        course.Difficulty = model.difficulty;
        await _context.SaveChangesAsync();
        return true;


    }
}

