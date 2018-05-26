using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMVC.Models;
using SampleMVC.ViewModel;
namespace SampleMVC.Controllers
{
  public class MoviesController : Controller
  {
        AppDbContext _context;
        public MoviesController()
        {
            _context = new AppDbContext();
        }
            // GET: Movies/Random
        public ActionResult Random()
        {
			Movie movie = new Movie { Name = "Shrek" };

            var customers = _context.Customers.ToList();

            var randomMovieViewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(randomMovieViewModel);
			//return RedirectToAction("index", "home", new { page = 1, Sortby = "name" });
        }

        public ActionResult New()
        {
            var movie = new Movie();
            var viewModelMovie = new MovieFormViewModel
            {
                Movie = movie,
                Title = "Add New Movie"
            };
            return View("MovieForm", viewModelMovie);
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Single(m => m.ID == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Title = "Movie Details"
            };
            return View("MovieForm", viewModel);
        }

	    public ActionResult Edit(int id)
	    {
            var movie = _context.Movies.FirstOrDefault(m => m.ID == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Title = "Edit Movie"
            };
		    return View("MovieForm", viewModel);
	    }

	    [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
	    public ActionResult ByReleaseDate(int year, int month)
	    {
		    return Content(year + "/" + month);
	    }

        public ActionResult Index()
        {
            var movies = _context.Movies.ToList();
                         
            return View(movies);
        }

        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie
                };
                    return View("MovieForm", viewModel);
            }
            if (movie.ID == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.ID == movie.ID);
                movieInDb.Name = movie.Name;
                movieInDb.Genre = movie.Genre;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Delete(int id)
        {
            var movie = _context.Movies.Single(m => m.ID == id);
            if (movie == null)
                return HttpNotFound();
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
	//public ActionResult Index(int? pageIndex, string sortBy)
	//{
	//	if (!pageIndex.HasValue)
	//	{
	//		pageIndex = 1;
	//	}
	//	if (string.IsNullOrEmpty(sortBy))
	//	{
	//		sortBy = "name";
	//	}
	//	return Content(string.Format("PageIndex={0} & sortBy={1}", pageIndex, sortBy));
	//}
  }
}