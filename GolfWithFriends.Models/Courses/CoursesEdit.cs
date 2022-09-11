using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class CoursesEdit
    {
    public int Id { get; set; }
    [Range(1, 10)]
    public int Rating { get; set; }
    [Range(1, 10)]
    public int difficulty { get; set; }
}

