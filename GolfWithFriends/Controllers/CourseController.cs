using Microsoft.AspNetCore.Mvc;


    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public async Task<IActionResult> Index()
        {

            var course = await _courseService.GetCourses();
            return View(course);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseCreate model)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            if (await _courseService.CourseRate(model))
                return RedirectToAction(nameof(Index));

            else return UnprocessableEntity();

        }

    [HttpGet]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        var course = await _courseService.GetCourseById(id);
        if(course == null) return NotFound();
        return View(course);
    }
    [HttpPost]
    [ActionName("DeleteCourse")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteCoursePost(int id)
    {
        var course = await _courseService.GetCourseById(id);
        if (course == null) return NotFound();

        bool worked = await _courseService.DeleteCourses(id);
        return RedirectToAction(nameof(Index));
        if (!worked) return BadRequest();
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        if (id == null) return BadRequest();
        var course = await _courseService.GetCoursesEdit(id);
        return View(course);
    }

    [HttpPost]
    [ActionName("Edit")]
    public async Task<IActionResult> EditPost(int id, CoursesEdit model)
    {
        var course = await _courseService.GetCoursesEdit(id);

        if (await _courseService.UpdateCourses(id, model))
            return RedirectToAction(nameof(Index));
        else
            return UnprocessableEntity();

    }
    }

