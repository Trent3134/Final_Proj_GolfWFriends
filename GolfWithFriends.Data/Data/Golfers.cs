using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Golfers: IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Handicap { get; set; }
    public string Location { get; set; }
    //public string PhoneNumber { get; set; }

    //public byte[] UserPhoto { get; set; }
    [NotMapped]
    public List<Golfers_Friends> Friends { get; set; } = new List<Golfers_Friends>();



  


}

