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
                FeaturedArtists = await _context.Artists
                    .OrderByDescending(a => a.Albums.Count)
                    .Take(4)
                    .ToListAsync(),
                FeaturedAlbums = await _context.Albums
                    .Include(a => a.Artist)
                    .OrderByDescending(a => a.ReleaseDate)
                    .Take(4)
                    .ToListAsync()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Search(string query)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(query))
                {
                    return RedirectToAction(nameof(Index));
                }

                _logger.LogInformation($"Search query: {query}");

                var searchResults = new SearchResultsViewModel
                {
                    SearchQuery = query,
                    Artists = await _context.Artists
                        .Where(a => a.Name.Contains(query))
                        .ToListAsync(),
                    Albums = await _context.Albums
                        .Include(a => a.Artist)
                        .Where(a => a.Title.Contains(query) || a.Artist.Name.Contains(query))
                        .ToListAsync(),
                    Songs = await _context.Songs
                        .Include(s => s.Album)
                            .ThenInclude(a => a.Artist)
                        .Where(s => s.Title.Contains(query) || 
                                  s.Album.Title.Contains(query) || 
                                  s.Album.Artist.Name.Contains(query))
                        .ToListAsync()
                };

                _logger.LogInformation($"Found {searchResults.Artists.Count} artists, " +
                                     $"{searchResults.Albums.Count} albums, " +
                                     $"{searchResults.Songs.Count} songs");

                return View(searchResults);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during search");
                return RedirectToAction(nameof(Index));
            }
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