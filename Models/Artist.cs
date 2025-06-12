// Models/Artist.cs
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic; // ICollection için

namespace MuzikKatalogu.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }

        [Required(ErrorMessage = "Sanatçı adı zorunludur.")]
        [StringLength(100, ErrorMessage = "Sanatçı adı en fazla 100 karakter olabilir.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Biyografi en fazla 500 karakter olabilir.")]
        public string? Bio { get; set; }

        [Display(Name = "Görsel URL")]
        [StringLength(255, ErrorMessage = "Görsel URL en fazla 255 karakter olabilir.")]
        public string? ImageUrl { get; set; }

        // Navigasyon özelliği: Bir sanatçının birden fazla albümü olabilir.
        public ICollection<Album>? Albums { get; set; }
    }
}