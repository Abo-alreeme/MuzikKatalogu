// Models/SearchResultsViewModel.cs
using System.Collections.Generic;

namespace MuzikKatalogu.Models
{
    public class SearchResultsViewModel
    {
        public string? SearchQuery { get; set; }
        public List<Artist>? Artists { get; set; }
        public List<Album>? Albums { get; set; }
        public List<Song>? Songs { get; set; }
        public bool NoResults => !(Artists?.Any() == true || Albums?.Any() == true || Songs?.Any() == true);
    }
}