// Models/Song.cs
using System.ComponentModel.DataAnnotations;

namespace MuzikKatalogu.Models
{
    public class Song
    {
        public int SongId { get; set; }

        [Required(ErrorMessage = "Şarkı başlığı zorunludur.")]
        [StringLength(200, ErrorMessage = "Şarkı başlığı en fazla 200 karakter olabilir.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Süre zorunludur.")]
        [Range(1, 3600, ErrorMessage = "Şarkı süresi 1 ile 3600 saniye arasında olmalıdır.")]
        [Display(Name = "Süre (Saniye)")]
        public int DurationSeconds { get; set; }

        [Display(Name = "Ses Dosyası URL")]
        [StringLength(255, ErrorMessage = "Ses dosyası URL'si en fazla 255 karakter olabilir.")]
        public string? AudioFileUrl { get; set; }

        // Foreign Key: Bir şarkının bir albümü olmalıdır.
        [Required(ErrorMessage = "Albüm seçimi zorunludur.")]
        [Display(Name = "Albüm")]
        public int AlbumId { get; set; }

        // Navigasyon özelliği: İlişkili albüm nesnesi
        public Album? Album { get; set; }
    }
}