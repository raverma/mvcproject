using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleMVC.Models;
namespace SampleMVC.ViewModel
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }

        public string Title { get; set; }
    }
}