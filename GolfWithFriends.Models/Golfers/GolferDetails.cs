﻿using System;
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
    public int DegreeWedge { get; set; }
    public int DegreeWedge2 { get; set; }
    public int PitchingWedge { get; set; }
    public int NineIron { get; set; }
    public int EightIron { get; set; }
    public int SevenIron { get; set; }
    public int SixIron { get; set; }
    public int FiveIron { get; set; }
    public int FourIron { get; set; }
    public int ThreeIron { get; set; }
    public int TwoIron { get; set; }
    public int OneIron { get; set; }
    public int FiveWood { get; set; }
    public int ThreeWood { get; set; }
    public int Driver { get; set; }
    //[Display(Name ="UserPhoto")]
    //public byte[] UserPhoto { get; set; }
    public List<Golfers_Friends> Friends { get; set; }

}

