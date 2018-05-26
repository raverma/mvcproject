using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SampleMVC.Models
{
	public class Movie
	{
		public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name="Movie Name")]
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        [MaxLength(50)]
        [Display(Name="Movie Genre")]
        public string Genre { get; set; }
    }
}