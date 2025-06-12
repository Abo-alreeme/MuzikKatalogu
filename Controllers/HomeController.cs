// Controllers/HomeController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuzikKatalogu.Data;
using MuzikKatalogu.Models;
using System.Diagnostics;
using System.Linq; // Any() metodu için

namespace MuzikKatalogu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MuzikKataloguDbContext _context;

        public HomeController(ILogger<HomeController> logger, MuzikKataloguDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeViewModel
            {
                FeaturedAlbums = await _context.Albums
                                            .Include(a => a.Artist)
                                            .OrderByDescending(a => a.ReleaseDate) // Yeni çıkanlar veya popüler olanlar
                                            .Take(4)
                                            .ToListAsync(),
                FeaturedArtists = await _context.Artists
                                             .OrderBy(a => a.Name)
                                             .Take(4)
                                             .ToListAsync()
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return RedirectToAction(nameof(Index));
            }

            var artists = await _context.Artists
                                        .Where(a => a.Name.Contains(query) || (a.Bio != null && a.Bio.Contains(query)))
                                        .ToListAsync();

            var albums = await _context.Albums
                                       .Include(a => a.Artist)
                                       .Where(a => a.Title.Contains(query) || (a.Artist != null && a.Artist.Name.Contains(query)))
                                       .ToListAsync();

            var songs = await _context.Songs
                                      .Include(s => s.Album)
                                      .ThenInclude(a => a.Artist)
                                      .Where(s => s.Title.Contains(query) || (s.Album != null && s.Album.Title.Contains(query)) || (s.Album != null && s.Album.Artist != null && s.Album.Artist.Name.Contains(query)))
                                      .ToListAsync();

            var searchResults = new SearchResultsViewModel
            {
                SearchQuery = query,
                Artists = artists,
                Albums = albums,
                Songs = songs
            };

            return View("SearchResults", searchResults); // Yeni SearchResults View'a yönlendir
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}