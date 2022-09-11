using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class CourseCreate
    {
    public string Name { get; set; }
    public string FirstAndLastName { get; set; }
    public string Location { get; set; }
    [Range(1,10)]
    public int Rating { get; set; }
    [Range(1, 10)]
    public int difficulty { get; set; }
}

