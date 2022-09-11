using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class GolferDetails
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Location { get; set; }
    public int Handicap { get; set; }
    public string PhoneNumber { get; set; }
    //[Display(Name ="UserPhoto")]
    //public byte[] UserPhoto { get; set; }
    public List<Golfers_Friends> Friends { get; set; }

}

