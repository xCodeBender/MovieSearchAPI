using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieDAL movieDAL = new MovieDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MovieSearch()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MovieSearch(string Title = "")
        {
            MovieModel movie = new MovieModel();

            if (Title != "")
            {
                movie = movieDAL.ConvertJSONtoSingleTitleMovieModel(Title);
                return View(movie);
            }

            else
            {
                return RedirectToAction("MovieSearch");
            }
        }
       
        public IActionResult MovieNight()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MovieNight(string Title1 , string Title2 , string Title3 )
        {
            
            if (string.IsNullOrEmpty(Title1) && string.IsNullOrEmpty(Title1) && string.IsNullOrEmpty(Title1))
            {
                return View();
            }
            List<string> movieList = new List<string>
            {
                new string(Title1),
                new string(Title2),
                new string(Title3)
            };
            List<MovieModel> movieResult = new List<MovieModel>();

            if (movieList != null)
            {
                foreach (string movie in movieList)
                {
                    var movieDetails = movieDAL.ConvertJSONtoSingleTitleMovieModel(movie);
                    movieResult.Add(movieDetails);
                }

                return View(movieResult);
            }
            else
            {
                return RedirectToAction("MovieNight");
            }

        }
        
        //public IActionResult MovieNightMethod(string title1 = "", string title2 = "", string title3 = "")
        //{
        //    MovieModel movie = new MovieModel();
        //    List<MovieModel> movieList = new List<MovieModel>();

        //    if (title1 != "")
        //    {
        //        movie = movieDAL.ConvertJSONtoSingleTitleMovieModel(title1);
        //        movieList.Add(movie);
        //        return View(movieList);
        //    }
        //    if (title2 != "")
        //    {
        //        movie = movieDAL.ConvertJSONtoSingleTitleMovieModel(title2);
        //        movieList.Add(movie);               
        //        return View(movieList);
        //    }
        //    if (title3 != "")
        //    {
        //        movie = movieDAL.ConvertJSONtoSingleTitleMovieModel(title3);
        //        movieList.Add(movie);
        //        return View(movieList);

        //    }
        //    //return View(movieList);
        //    else
        //    {
        //        return View(RedirectToAction("MovieNight"));
        //    }


        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
