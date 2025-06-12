// Data/MuzikKataloguDbContext.cs

using Microsoft.EntityFrameworkCore;
using MuzikKatalogu.Models;
using System;
using System.Collections.Generic;

namespace MuzikKatalogu.Data
{
    public class MuzikKataloguDbContext : DbContext
    {
        public MuzikKataloguDbContext(DbContextOptions<MuzikKataloguDbContext> options) : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // İlişki tanımlamaları
            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Albums)
                .WithOne(al => al.Artist)
                .HasForeignKey(al => al.ArtistId);

            modelBuilder.Entity<Album>()
                .HasMany(al => al.Songs)
                .WithOne(s => s.Album)
                .HasForeignKey(s => s.AlbumId);


            // Sanatçılar için Seed Data
            modelBuilder.Entity<Artist>().HasData(
                new Artist { ArtistId = 1, Name = "Queen", Bio = "İngiliz rock grubu. Eşsiz sahne performansları ve Freddie Mercury'nin karizmasıyla tanınırlar.", ImageUrl = "/images/artists/queen.jpg" },
                new Artist { ArtistId = 2, Name = "Michael Jackson", Bio = "Popun Kralı olarak bilinen Michael Jackson, müzik, dans ve moda dünyasında ikonik bir figürdür.", ImageUrl = "/images/artists/michaeljackson.jpg" },
                new Artist { ArtistId = 3, Name = "The Beatles", Bio = "Müzik tarihinin en etkili gruplarından biri olan The Beatles, 1960'larda rock müziği yeniden tanımladı.", ImageUrl = "/images/artists/thebeatles.jpg" }, // Örnek görsel eklendi
                new Artist { ArtistId = 4, Name = "Madonna", Bio = "Pop Kraliçesi Madonna, müzik ve moda dünyasındaki yenilikleriyle bilinir.", ImageUrl = "/images/artists/madonna.jpg" },
                new Artist { ArtistId = 5, Name = "Led Zeppelin", Bio = "Heavy metal ve hard rock'ın öncülerinden, blues-rock kökenli İngiliz grup.", ImageUrl = "/images/artists/ledzeppelin.jpg" },
                new Artist { ArtistId = 6, Name = "Adele", Bio = "Güçlü sesi ve duygusal şarkı sözleriyle tanınan İngiliz şarkıcı-söz yazarı.", ImageUrl = "/images/artists/adele.jpg" },
                new Artist { ArtistId = 7, Name = "Taylor Swift", Bio = "Ülke ve pop müziği harmanlayan, etkileyici şarkı sözleriyle genç yaşta büyük başarılar elde eden sanatçı.", ImageUrl = "/images/artists/taylorswift.jpg" },
                new Artist { ArtistId = 8, Name = "Elton John", Bio = "Dünyaca ünlü İngiliz piyanist, şarkıcı, söz yazarı ve besteci. Canlı performanslarıyla ünlüdür.", ImageUrl = "/images/artists/eltonjohn.jpg" },
                new Artist { ArtistId = 9, Name = "Pink Floyd", Bio = "Progresif ve psikedelik rock'ın öncülerinden, felsefi şarkı sözleri ve deneysel müzikleriyle tanınır.", ImageUrl = "/images/artists/pinkfloyd.jpg" },
                new Artist { ArtistId = 10, Name = "Beyoncé", Bio = "Küresel bir ikon, şarkıcı, söz yazarı, dansçı ve oyuncu. Sahne performansları ve güçlü vokalleriyle bilinir.", ImageUrl = "/images/artists/beyonce.jpg" },
                new Artist { ArtistId = 11, Name = "Eminem", Bio = "Tüm zamanların en çok satan rap sanatçılarından biri, karmaşık kafiyeleri ve kişisel hikayeleriyle ünlüdür.", ImageUrl = "/images/artists/eminem.jpg" },
                new Artist { ArtistId = 12, Name = "Rihanna", Bio = "Barbadoslu şarkıcı, iş kadını ve oyuncu. Çeşitli müzik tarzlarını bir araya getiren hitleriyle tanınır.", ImageUrl = "/images/artists/rihanna.jpg" },
                new Artist { ArtistId = 13, Name = "Coldplay", Bio = "Duygusal rock marşları ve stadyum konserleriyle dünya çapında büyük bir hayran kitlesi olan İngiliz grup.", ImageUrl = "/images/artists/coldplay.jpg" },
                new Artist { ArtistId = 14, Name = "Ed Sheeran", Bio = "Akustik gitarı ve samimi şarkı sözleriyle global başarı yakalayan İngiliz şarkıcı-söz yazarı.", ImageUrl = "/images/artists/edsheeran.jpg" },
                new Artist { ArtistId = 15, Name = "Maroon 5", Bio = "Funk, pop ve rock'ı harmanlayan, dünya çapında hit şarkılarıyla bilinen Amerikalı grup.", ImageUrl = "/images/artists/maroon5.jpg" },
                new Artist { ArtistId = 16, Name = "Adele", Bio = "Benzersiz sesi ve duygusal şarkılarıyla tanınan İngiliz şarkıcı.", ImageUrl = "/images/artists/adele.jpg" },
                new Artist { ArtistId = 17, Name = "Bruno Mars", Bio = "Soul, funk, pop ve R&B'yi bir araya getiren hitleriyle ünlü Amerikalı şarkıcı, söz yazarı ve yapımcı.", ImageUrl = "/images/artists/brunomars.jpg" },
                new Artist { ArtistId = 18, Name = "Ariana Grande", Bio = "Geniş vokal aralığı ve pop ile R&B hitleriyle tanınan Amerikalı şarkıcı ve oyuncu.", ImageUrl = "/images/artists/arianagrande.jpg" },
                new Artist { ArtistId = 19, Name = "Billie Eilish", Bio = "Karanlık, atmosferik pop tarzıyla ve sıradışı vokal tekniğiyle öne çıkan genç Amerikalı şarkıcı.", ImageUrl = "/images/artists/billieeilish.jpg" },
                new Artist { ArtistId = 20, Name = "Dua Lipa", Bio = "Dans-pop ve pop türündeki şarkılarıyla tanınan İngiliz şarkıcı.", ImageUrl = "/images/artists/dualipa.jpg" },
                new Artist { ArtistId = 21, Name = "Harry Styles", Bio = "One Direction grubunun eski üyesi, modern pop ve rock müziğiyle solo kariyerinde büyük başarı elde etti.", ImageUrl = "/images/artists/harrystyles.jpg" },
                new Artist { ArtistId = 22, Name = "The Weeknd", Bio = "R&B, pop ve soul'u harmanlayan, benzersiz vokalleri ve karanlık temalarıyla bilinen Kanadalı şarkıcı.", ImageUrl = "/images/artists/theweeknd.jpg" },
                new Artist { ArtistId = 23, Name = "Post Malone", Bio = "Hip-hop, pop ve rock türlerini karıştıran Amerikalı şarkıcı, rapçi ve söz yazarı.", ImageUrl = "/images/artists/postmalone.jpg" },
                new Artist { ArtistId = 24, Name = "Justin Bieber", Bio = "Genç yaşta küresel bir fenomen haline gelen Kanadalı pop şarkıcısı.", ImageUrl = "/images/artists/justinbieber.jpg" },
                new Artist { ArtistId = 25, Name = "Shakira", Bio = "Latin pop ve rock'ı harmanlayan, danslarıyla ve güçlü vokalleriyle bilinen Kolombiyalı süperstar.", ImageUrl = "/images/artists/shakira.jpg" },
                new Artist { ArtistId = 26, Name = "Red Hot Chili Peppers", Bio = "Funk rock ve alternatif rock'ın öncülerinden Amerikalı grup.", ImageUrl = "/images/artists/redhotchilipeppers.jpg" },
                new Artist { ArtistId = 27, Name = "Foo Fighters", Bio = "Nirvana'nın davulcusu Dave Grohl tarafından kurulan Amerikalı rock grubu.", ImageUrl = "/images/artists/foofighters.jpg" },
                new Artist { ArtistId = 28, Name = "AC/DC", Bio = "Hard rock ve blues rock'ın efsanevi Avustralyalı grubu, yüksek enerjili sahne performanslarıyla bilinir.", ImageUrl = "/images/artists/acdc.jpg" },
                new Artist { ArtistId = 29, Name = "Metallica", Bio = "Thrash metal'in öncülerinden ve en büyük gruplarından biri olan Amerikalı heavy metal grubu.", ImageUrl = "/images/artists/metallica.jpg" },
                new Artist { ArtistId = 30, Name = "Guns N' Roses", Bio = "Hard rock'ın ikonik gruplarından, 'Welcome to the Jungle' ve 'Sweet Child o' Mine' gibi hitleriyle ünlüdür.", ImageUrl = "/images/artists/gunsnroses.jpg" }
                // Toplam 30 sanatçıya ulaştık. 50'ye tamamlamak için benzer şekilde eklemeye devam edebilirsiniz.
            );

            // Albümler için Seed Data
            modelBuilder.Entity<Album>().HasData(
                // Queen Albümleri (ArtistId: 1)
                new Album { AlbumId = 1, Title = "A Night at the Opera", ReleaseDate = new DateTime(1975, 11, 21), CoverImageUrl = "/images/albums/queen_anightattheopera.jpg", Price = 19.99m, ArtistId = 1 },
                new Album { AlbumId = 2, Title = "News of the World", ReleaseDate = new DateTime(1977, 10, 28), CoverImageUrl = "/images/albums/queen_newsoftheworld.jpg", Price = 12.99m, ArtistId = 1 },
                new Album { AlbumId = 3, Title = "Greatest Hits", ReleaseDate = new DateTime(1981, 10, 26), CoverImageUrl = "/images/albums/queen_greatesthits.jpg", Price = 15.99m, ArtistId = 1 },
                new Album { AlbumId = 25, Title = "The Game", ReleaseDate = new DateTime(1980, 6, 30), CoverImageUrl = "/images/albums/queen_thegame.jpg", Price = 14.50m, ArtistId = 1 },

                // Michael Jackson Albümleri (ArtistId: 2)
                new Album { AlbumId = 4, Title = "Thriller", ReleaseDate = new DateTime(1982, 11, 30), CoverImageUrl = "/images/albums/mj_thriller.jpg", Price = 24.99m, ArtistId = 2 },
                new Album { AlbumId = 26, Title = "Bad", ReleaseDate = new DateTime(1987, 8, 31), CoverImageUrl = "/images/albums/mj_bad.jpg", Price = 20.00m, ArtistId = 2 },
                new Album { AlbumId = 27, Title = "Dangerous", ReleaseDate = new DateTime(1991, 11, 26), CoverImageUrl = "/images/albums/mj_dangerous.jpg", Price = 18.00m, ArtistId = 2 },

                // The Beatles Albümleri (ArtistId: 3)
                new Album { AlbumId = 5, Title = "Abbey Road", ReleaseDate = new DateTime(1969, 9, 26), CoverImageUrl = "/images/albums/beatles_abbeyroad.jpg", Price = 18.50m, ArtistId = 3 },
                new Album { AlbumId = 6, Title = "Sgt. Pepper's Lonely Hearts Club Band", ReleaseDate = new DateTime(1967, 6, 1), CoverImageUrl = "/images/albums/beatles_sgtpepper.jpg", Price = 22.00m, ArtistId = 3 },
                new Album { AlbumId = 7, Title = "Revolver", ReleaseDate = new DateTime(1966, 8, 5), CoverImageUrl = "/images/albums/beatles_revolver.jpg", Price = 17.00m, ArtistId = 3 },
                new Album { AlbumId = 28, Title = "The White Album", ReleaseDate = new DateTime(1968, 11, 22), CoverImageUrl = "/images/albums/beatles_whitealbum.jpg", Price = 25.00m, ArtistId = 3 },

                // Madonna Albümleri (ArtistId: 4)
                new Album { AlbumId = 8, Title = "Like a Virgin", ReleaseDate = new DateTime(1984, 11, 12), CoverImageUrl = "/images/albums/madonna_likeavirgin.jpg", Price = 14.00m, ArtistId = 4 },
                new Album { AlbumId = 9, Title = "Ray of Light", ReleaseDate = new DateTime(1998, 3, 3), CoverImageUrl = "/images/albums/madonna_rayoflight.jpg", Price = 16.00m, ArtistId = 4 },

                // Led Zeppelin Albümleri (ArtistId: 5)
                new Album { AlbumId = 10, Title = "Led Zeppelin IV", ReleaseDate = new DateTime(1971, 11, 8), CoverImageUrl = "/images/albums/ledzeppelin_iv.jpg", Price = 21.00m, ArtistId = 5 },
                new Album { AlbumId = 11, Title = "Houses of the Holy", ReleaseDate = new DateTime(1973, 3, 28), CoverImageUrl = "/images/albums/ledzeppelin_houses.jpg", Price = 19.50m, ArtistId = 5 },
                new Album { AlbumId = 29, Title = "Physical Graffiti", ReleaseDate = new DateTime(1975, 2, 24), CoverImageUrl = "/images/albums/ledzeppelin_physicalgraffiti.jpg", Price = 23.00m, ArtistId = 5 },

                // Adele Albümleri (ArtistId: 6)
                new Album { AlbumId = 12, Title = "21", ReleaseDate = new DateTime(2011, 1, 24), CoverImageUrl = "/images/albums/adele_21.jpg", Price = 17.50m, ArtistId = 6 },
                new Album { AlbumId = 13, Title = "25", ReleaseDate = new DateTime(2015, 11, 20), CoverImageUrl = "/images/albums/adele_25.jpg", Price = 18.00m, ArtistId = 6 },

                // Taylor Swift Albümleri (ArtistId: 7)
                new Album { AlbumId = 14, Title = "1989", ReleaseDate = new DateTime(2014, 10, 27), CoverImageUrl = "/images/albums/taylorswift_1989.jpg", Price = 15.00m, ArtistId = 7 },
                new Album { AlbumId = 15, Title = "Red", ReleaseDate = new DateTime(2012, 10, 22), CoverImageUrl = "/images/albums/taylorswift_red.jpg", Price = 14.50m, ArtistId = 7 },
                new Album { AlbumId = 30, Title = "Folklore", ReleaseDate = new DateTime(2020, 7, 24), CoverImageUrl = "/images/albums/taylorswift_folklore.jpg", Price = 16.00m, ArtistId = 7 },

                // Elton John Albümleri (ArtistId: 8)
                new Album { AlbumId = 16, Title = "Goodbye Yellow Brick Road", ReleaseDate = new DateTime(1973, 10, 5), CoverImageUrl = "/images/albums/eltonjohn_goodbyeyellowbrickroad.jpg", Price = 16.50m, ArtistId = 8 },

                // Pink Floyd Albümleri (ArtistId: 9)
                new Album { AlbumId = 17, Title = "The Dark Side of the Moon", ReleaseDate = new DateTime(1973, 3, 1), CoverImageUrl = "/images/albums/pinkfloyd_darksideofthemoon.jpg", Price = 25.00m, ArtistId = 9 },
                new Album { AlbumId = 18, Title = "The Wall", ReleaseDate = new DateTime(1979, 11, 30), CoverImageUrl = "/images/albums/pinkfloyd_thewall.jpg", Price = 23.00m, ArtistId = 9 },

                // Beyoncé Albümleri (ArtistId: 10)
                new Album { AlbumId = 19, Title = "Lemonade", ReleaseDate = new DateTime(2016, 4, 23), CoverImageUrl = "/images/albums/beyonce_lemonade.jpg", Price = 17.00m, ArtistId = 10 },

                // Eminem Albümleri (ArtistId: 11)
                new Album { AlbumId = 20, Title = "The Marshall Mathers LP", ReleaseDate = new DateTime(2000, 5, 23), CoverImageUrl = "/images/albums/eminem_mmlp.jpg", Price = 15.50m, ArtistId = 11 },

                // Rihanna Albümleri (ArtistId: 12)
                new Album { AlbumId = 21, Title = "Anti", ReleaseDate = new DateTime(2016, 1, 28), CoverImageUrl = "/images/albums/rihanna_anti.jpg", Price = 13.00m, ArtistId = 12 },

                // Coldplay Albümleri (ArtistId: 13)
                new Album { AlbumId = 22, Title = "A Rush of Blood to the Head", ReleaseDate = new DateTime(2002, 8, 26), CoverImageUrl = "/images/albums/coldplay_arushofblood.jpg", Price = 14.00m, ArtistId = 13 },

                // Ed Sheeran Albümleri (ArtistId: 14)
                new Album { AlbumId = 23, Title = "Divide", ReleaseDate = new DateTime(2017, 3, 3), CoverImageUrl = "/images/albums/edsheeran_divide.jpg", Price = 16.00m, ArtistId = 14 },

                // Maroon 5 Albümleri (ArtistId: 15)
                new Album { AlbumId = 24, Title = "Songs About Jane", ReleaseDate = new DateTime(2002, 6, 25), CoverImageUrl = "/images/albums/maroon5_songsaboutjane.jpg", Price = 12.00m, ArtistId = 15 },

                // Diğer Sanatçıların Albümleri (ID'ler benzersiz olmalı, 31'den başlayarak devam edin)
                new Album { AlbumId = 31, Title = "21 (Deluxe Edition)", ReleaseDate = new DateTime(2011, 1, 24), CoverImageUrl = "/images/albums/adele_21_deluxe.jpg", Price = 19.00m, ArtistId = 6 }, // Adele
                new Album { AlbumId = 32, Title = "Doo-Wops & Hooligans", ReleaseDate = new DateTime(2010, 10, 4), CoverImageUrl = "/images/albums/brunomars_doowops.jpg", Price = 13.50m, ArtistId = 17 }, // Bruno Mars
                new Album { AlbumId = 33, Title = "Sweetener", ReleaseDate = new DateTime(2018, 8, 17), CoverImageUrl = "/images/albums/arianagrande_sweetener.jpg", Price = 15.00m, ArtistId = 18 }, // Ariana Grande
                new Album { AlbumId = 34, Title = "When We All Fall Asleep, Where Do We Go?", ReleaseDate = new DateTime(2019, 3, 29), CoverImageUrl = "/images/albums/billieeilish_whenweallfall.jpg", Price = 16.50m, ArtistId = 19 }, // Billie Eilish
                new Album { AlbumId = 35, Title = "Future Nostalgia", ReleaseDate = new DateTime(2020, 3, 27), CoverImageUrl = "/images/albums/dualipa_futurenostalgia.jpg", Price = 14.00m, ArtistId = 20 }, // Dua Lipa
                new Album { AlbumId = 36, Title = "Fine Line", ReleaseDate = new DateTime(2019, 12, 13), CoverImageUrl = "/images/albums/harrystyles_fineline.jpg", Price = 17.00m, ArtistId = 21 }, // Harry Styles
                new Album { AlbumId = 37, Title = "After Hours", ReleaseDate = new DateTime(2020, 3, 20), CoverImageUrl = "/images/albums/theweeknd_afterhours.jpg", Price = 18.00m, ArtistId = 22 }, // The Weeknd
                new Album { AlbumId = 38, Title = "Hollywood's Bleeding", ReleaseDate = new DateTime(2019, 9, 6), CoverImageUrl = "/images/albums/postmalone_hollywoodsbleeding.jpg", Price = 15.50m, ArtistId = 23 }, // Post Malone
                new Album { AlbumId = 39, Title = "Purpose", ReleaseDate = new DateTime(2015, 11, 13), CoverImageUrl = "/images/albums/justinbieber_purpose.jpg", Price = 13.00m, ArtistId = 24 }, // Justin Bieber
                new Album { AlbumId = 40, Title = "Laundry Service", ReleaseDate = new DateTime(2001, 11, 13), CoverImageUrl = "/images/albums/shakira_laundryservice.jpg", Price = 11.00m, ArtistId = 25 }, // Shakira
                new Album { AlbumId = 41, Title = "Californication", ReleaseDate = new DateTime(1999, 6, 8), CoverImageUrl = "/images/albums/rhcp_californication.jpg", Price = 14.00m, ArtistId = 26 }, // Red Hot Chili Peppers
                new Album { AlbumId = 42, Title = "The Colour and the Shape", ReleaseDate = new DateTime(1997, 5, 20), CoverImageUrl = "/images/albums/foofighters_colourandshape.jpg", Price = 12.00m, ArtistId = 27 }, // Foo Fighters
                new Album { AlbumId = 43, Title = "Back in Black", ReleaseDate = new DateTime(1980, 7, 25), CoverImageUrl = "/images/albums/acdc_backinblack.jpg", Price = 19.00m, ArtistId = 28 }, // AC/DC
                new Album { AlbumId = 44, Title = "Master of Puppets", ReleaseDate = new DateTime(1986, 3, 3), CoverImageUrl = "/images/albums/metallica_masterofpuppets.jpg", Price = 17.00m, ArtistId = 29 }, // Metallica
                new Album { AlbumId = 45, Title = "Appetite for Destruction", ReleaseDate = new DateTime(1987, 7, 21), CoverImageUrl = "/images/albums/gunsnroses_appetite.jpg", Price = 18.00m, ArtistId = 30 }
                // Toplam 45 albüme ulaştık. 50'ye tamamlamak için benzer şekilde eklemeye devam edebilirsiniz.
            );

            // Şarkılar için Seed Data
            modelBuilder.Entity<Song>().HasData(
                // Queen Albümleri (AlbumId: 1, 2, 3, 25)
                new Song { SongId = 1, Title = "Bohemian Rhapsody", DurationSeconds = 354, AlbumId = 1 },
                new Song { SongId = 2, Title = "Killer Queen", DurationSeconds = 180, AlbumId = 1 },
                new Song { SongId = 3, Title = "Love of My Life", DurationSeconds = 217, AlbumId = 1 },
                new Song { SongId = 4, Title = "We Will Rock You", DurationSeconds = 122, AlbumId = 2 },
                new Song { SongId = 5, Title = "We Are the Champions", DurationSeconds = 179, AlbumId = 2 },
                new Song { SongId = 6, Title = "Don't Stop Me Now", DurationSeconds = 210, AlbumId = 3 },
                new Song { SongId = 7, Title = "Another One Bites the Dust", DurationSeconds = 215, AlbumId = 25 },

                // Michael Jackson Albümleri (AlbumId: 4, 26, 27)
                new Song { SongId = 8, Title = "Billie Jean", DurationSeconds = 294, AlbumId = 4 },
                new Song { SongId = 9, Title = "Beat It", DurationSeconds = 258, AlbumId = 4 },
                new Song { SongId = 10, Title = "Thriller", DurationSeconds = 357, AlbumId = 4 },
                new Song { SongId = 11, Title = "Bad", DurationSeconds = 247, AlbumId = 26 },
                new Song { SongId = 12, Title = "Smooth Criminal", DurationSeconds = 257, AlbumId = 27 },

                // The Beatles Albümleri (AlbumId: 5, 6, 7, 28)
                new Song { SongId = 13, Title = "Come Together", DurationSeconds = 259, AlbumId = 5 },
                new Song { SongId = 14, Title = "Something", DurationSeconds = 182, AlbumId = 5 },
                new Song { SongId = 15, Title = "Here Comes the Sun", DurationSeconds = 185, AlbumId = 5 },
                new Song { SongId = 16, Title = "A Day in the Life", DurationSeconds = 337, AlbumId = 6 },
                new Song { SongId = 17, Title = "Yellow Submarine", DurationSeconds = 159, AlbumId = 7 },
                new Song { SongId = 18, Title = "While My Guitar Gently Weeps", DurationSeconds = 285, AlbumId = 28 },

                // Madonna Albümleri (AlbumId: 8, 9)
                new Song { SongId = 19, Title = "Like a Virgin", DurationSeconds = 218, AlbumId = 8 },
                new Song { SongId = 20, Title = "Vogue", DurationSeconds = 318, AlbumId = 9 }, // Ray of Light'ta değil ama örnek
                new Song { SongId = 21, Title = "Frozen", DurationSeconds = 377, AlbumId = 9 },

                // Led Zeppelin Albümleri (AlbumId: 10, 11, 29)
                new Song { SongId = 22, Title = "Stairway to Heaven", DurationSeconds = 482, AlbumId = 10 },
                new Song { SongId = 23, Title = "Whole Lotta Love", DurationSeconds = 310, AlbumId = 10 }, // Led Zeppelin II'den ama örnek
                new Song { SongId = 24, Title = "Kashmir", DurationSeconds = 512, AlbumId = 29 },

                // Adele Albümleri (AlbumId: 12, 13, 31)
                new Song { SongId = 25, Title = "Rolling in the Deep", DurationSeconds = 228, AlbumId = 12 },
                new Song { SongId = 26, Title = "Someone Like You", DurationSeconds = 285, AlbumId = 12 },
                new Song { SongId = 27, Title = "Hello", DurationSeconds = 295, AlbumId = 13 },

                // Taylor Swift Albümleri (AlbumId: 14, 15, 30)
                new Song { SongId = 28, Title = "Shake It Off", DurationSeconds = 219, AlbumId = 14 },
                new Song { SongId = 29, Title = "Blank Space", DurationSeconds = 221, AlbumId = 14 },
                new Song { SongId = 30, Title = "All Too Well", DurationSeconds = 328, AlbumId = 15 },
                new Song { SongId = 31, Title = "Cardigan", DurationSeconds = 255, AlbumId = 30 },

                // Elton John Albümleri (AlbumId: 16)
                new Song { SongId = 32, Title = "Tiny Dancer", DurationSeconds = 340, AlbumId = 16 },

                // Pink Floyd Albümleri (AlbumId: 17, 18)
                new Song { SongId = 33, Title = "Money", DurationSeconds = 398, AlbumId = 17 },
                new Song { SongId = 34, Title = "Comfortably Numb", DurationSeconds = 383, AlbumId = 18 },

                // Beyoncé Albümleri (AlbumId: 19)
                new Song { SongId = 35, Title = "Formation", DurationSeconds = 206, AlbumId = 19 },

                // Eminem Albümleri (AlbumId: 20)
                new Song { SongId = 36, Title = "Stan", DurationSeconds = 444, AlbumId = 20 },

                // Rihanna Albümleri (AlbumId: 21)
                new Song { SongId = 37, Title = "Work", DurationSeconds = 219, AlbumId = 21 },

                // Coldplay Albümleri (AlbumId: 22)
                new Song { SongId = 38, Title = "Clocks", DurationSeconds = 307, AlbumId = 22 },

                // Ed Sheeran Albümleri (AlbumId: 23)
                new Song { SongId = 39, Title = "Shape of You", DurationSeconds = 233, AlbumId = 23 },

                // Maroon 5 Albümleri (AlbumId: 24)
                new Song { SongId = 40, Title = "This Love", DurationSeconds = 206, AlbumId = 24 },

                // Yeni eklenen albümlerden şarkılar
                new Song { SongId = 41, Title = "Locked Out of Heaven", DurationSeconds = 233, AlbumId = 32 }, // Bruno Mars - Doo-Wops & Hooligans
                new Song { SongId = 42, Title = "thank u, next", DurationSeconds = 227, AlbumId = 33 }, // Ariana Grande - Sweetener
                new Song { SongId = 43, Title = "Bad Guy", DurationSeconds = 194, AlbumId = 34 }, // Billie Eilish - When We All Fall Asleep
                new Song { SongId = 44, Title = "Don't Start Now", DurationSeconds = 183, AlbumId = 35 }, // Dua Lipa - Future Nostalgia
                new Song { SongId = 45, Title = "Watermelon Sugar", DurationSeconds = 174, AlbumId = 36 }, // Harry Styles - Fine Line
                new Song { SongId = 46, Title = "Blinding Lights", DurationSeconds = 200, AlbumId = 37 }, // The Weeknd - After Hours
                new Song { SongId = 47, Title = "Circles", DurationSeconds = 207, AlbumId = 38 }, // Post Malone - Hollywood's Bleeding
                new Song { SongId = 48, Title = "What Do You Mean?", DurationSeconds = 208, AlbumId = 39 }, // Justin Bieber - Purpose
                new Song { SongId = 49, Title = "Whenever, Wherever", DurationSeconds = 196, AlbumId = 40 }, // Shakira - Laundry Service
                new Song { SongId = 50, Title = "Under the Bridge", DurationSeconds = 266, AlbumId = 41 } // Red Hot Chili Peppers - Californication
                // Toplam 50 şarkıya ulaştık. İsteğe bağlı olarak daha fazlasını eklemeye devam edebilirsiniz.
            );
        }
    }
}