// Models/Album.cs
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic; // ICollection için

namespace MuzikKatalogu.Models
{
    public class Album
    {
        public int AlbumId { get; set; }

        [Required(ErrorMessage = "Albüm başlığı zorunludur.")]
        [StringLength(200, ErrorMessage = "Albüm başlığı en fazla 200 karakter olabilir.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Çıkış tarihi zorunludur.")]
        [DataType(DataType.Date)]
        [Display(Name = "Çıkış Tarihi")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Kapak Görseli URL")]
        [StringLength(255, ErrorMessage = "Kapak görseli URL'si en fazla 255 karakter olabilir.")]
        public string? CoverImageUrl { get; set; }

        [Required(ErrorMessage = "Fiyat zorunludur.")]
        [Range(0.01, 1000.00, ErrorMessage = "Fiyat 0.01 ile 1000 arasında olmalıdır.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        // Foreign Key: Bir albümün bir sanatçısı olmalıdır.
        [Required(ErrorMessage = "Sanatçı seçimi zorunludur.")]
        [Display(Name = "Sanatçı")]
        public int ArtistId { get; set; }

        // Navigasyon özelliği: İlişkili sanatçı nesnesi
        public Artist? Artist { get; set; }

        // Navigasyon özelliği: Bir albümün birden fazla şarkısı olabilir.
        public ICollection<Song>? Songs { get; set; }
    }
}