// Models/HomeViewModel.cs
using System.Collections.Generic;

namespace MuzikKatalogu.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Album>? FeaturedAlbums { get; set; }
        public IEnumerable<Artist>? FeaturedArtists { get; set; }
    }
}