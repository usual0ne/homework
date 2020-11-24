using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesApp.Data;
using MoviesApp.Models;
using MoviesApp.ViewModels;

namespace MoviesApp.Controllers
{
    public class MoviesActorsController : Controller
    {
        private readonly MoviesContext _context;
        private readonly ILogger<HomeController> _logger;

        public MoviesActorsController(MoviesContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Movies and actors
        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.MoviesActors.Select(ma => new MoviesActorsViewModel
            {
                MovieId = ma.MovieId,
                Movie = ma.Movie,
                ActorId = ma.ActorId,
                Actor = ma.Actor

            }).ToList());
        }
    }
}
