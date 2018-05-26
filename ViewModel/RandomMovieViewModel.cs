using System.Collections.Generic;
using SampleMVC.Models;

namespace SampleMVC.ViewModel
{
    public class RandomMovieViewModel
	{
		public Movie Movie{ get; set; }
		public List<Customer> Customers { get; set; }
	}
}