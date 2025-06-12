using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MuzikKatalogu.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateWithAllDataAndImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.AlbumId);
                    table.ForeignKey(
                        name: "FK_Albums_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DurationSeconds = table.Column<int>(type: "int", nullable: false),
                    AudioFileUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AlbumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongId);
                    table.ForeignKey(
                        name: "FK_Songs_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "AlbumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "Bio", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "İngiliz rock grubu. Eşsiz sahne performansları ve Freddie Mercury'nin karizmasıyla tanınırlar.", "/images/artists/queen.jpg", "Queen" },
                    { 2, "Popun Kralı olarak bilinen Michael Jackson, müzik, dans ve moda dünyasında ikonik bir figürdür.", "/images/artists/michaeljackson.jpg", "Michael Jackson" },
                    { 3, "Müzik tarihinin en etkili gruplarından biri olan The Beatles, 1960'larda rock müziği yeniden tanımladı.", "/images/artists/thebeatles.jpg", "The Beatles" },
                    { 4, "Pop Kraliçesi Madonna, müzik ve moda dünyasındaki yenilikleriyle bilinir.", "/images/artists/madonna.jpg", "Madonna" },
                    { 5, "Heavy metal ve hard rock'ın öncülerinden, blues-rock kökenli İngiliz grup.", "/images/artists/ledzeppelin.jpg", "Led Zeppelin" },
                    { 6, "Güçlü sesi ve duygusal şarkı sözleriyle tanınan İngiliz şarkıcı-söz yazarı.", "/images/artists/adele.jpg", "Adele" },
                    { 7, "Ülke ve pop müziği harmanlayan, etkileyici şarkı sözleriyle genç yaşta büyük başarılar elde eden sanatçı.", "/images/artists/taylorswift.jpg", "Taylor Swift" },
                    { 8, "Dünyaca ünlü İngiliz piyanist, şarkıcı, söz yazarı ve besteci. Canlı performanslarıyla ünlüdür.", "/images/artists/eltonjohn.jpg", "Elton John" },
                    { 9, "Progresif ve psikedelik rock'ın öncülerinden, felsefi şarkı sözleri ve deneysel müzikleriyle tanınır.", "/images/artists/pinkfloyd.jpg", "Pink Floyd" },
                    { 10, "Küresel bir ikon, şarkıcı, söz yazarı, dansçı ve oyuncu. Sahne performansları ve güçlü vokalleriyle bilinir.", "/images/artists/beyonce.jpg", "Beyoncé" },
                    { 11, "Tüm zamanların en çok satan rap sanatçılarından biri, karmaşık kafiyeleri ve kişisel hikayeleriyle ünlüdür.", "/images/artists/eminem.jpg", "Eminem" },
                    { 12, "Barbadoslu şarkıcı, iş kadını ve oyuncu. Çeşitli müzik tarzlarını bir araya getiren hitleriyle tanınır.", "/images/artists/rihanna.jpg", "Rihanna" },
                    { 13, "Duygusal rock marşları ve stadyum konserleriyle dünya çapında büyük bir hayran kitlesi olan İngiliz grup.", "/images/artists/coldplay.jpg", "Coldplay" },
                    { 14, "Akustik gitarı ve samimi şarkı sözleriyle global başarı yakalayan İngiliz şarkıcı-söz yazarı.", "/images/artists/edsheeran.jpg", "Ed Sheeran" },
                    { 15, "Funk, pop ve rock'ı harmanlayan, dünya çapında hit şarkılarıyla bilinen Amerikalı grup.", "/images/artists/maroon5.jpg", "Maroon 5" },
                    { 16, "Benzersiz sesi ve duygusal şarkılarıyla tanınan İngiliz şarkıcı.", "/images/artists/adele.jpg", "Adele" },
                    { 17, "Soul, funk, pop ve R&B'yi bir araya getiren hitleriyle ünlü Amerikalı şarkıcı, söz yazarı ve yapımcı.", "/images/artists/brunomars.jpg", "Bruno Mars" },
                    { 18, "Geniş vokal aralığı ve pop ile R&B hitleriyle tanınan Amerikalı şarkıcı ve oyuncu.", "/images/artists/arianagrande.jpg", "Ariana Grande" },
                    { 19, "Karanlık, atmosferik pop tarzıyla ve sıradışı vokal tekniğiyle öne çıkan genç Amerikalı şarkıcı.", "/images/artists/billieeilish.jpg", "Billie Eilish" },
                    { 20, "Dans-pop ve pop türündeki şarkılarıyla tanınan İngiliz şarkıcı.", "/images/artists/dualipa.jpg", "Dua Lipa" },
                    { 21, "One Direction grubunun eski üyesi, modern pop ve rock müziğiyle solo kariyerinde büyük başarı elde etti.", "/images/artists/harrystyles.jpg", "Harry Styles" },
                    { 22, "R&B, pop ve soul'u harmanlayan, benzersiz vokalleri ve karanlık temalarıyla bilinen Kanadalı şarkıcı.", "/images/artists/theweeknd.jpg", "The Weeknd" },
                    { 23, "Hip-hop, pop ve rock türlerini karıştıran Amerikalı şarkıcı, rapçi ve söz yazarı.", "/images/artists/postmalone.jpg", "Post Malone" },
                    { 24, "Genç yaşta küresel bir fenomen haline gelen Kanadalı pop şarkıcısı.", "/images/artists/justinbieber.jpg", "Justin Bieber" },
                    { 25, "Latin pop ve rock'ı harmanlayan, danslarıyla ve güçlü vokalleriyle bilinen Kolombiyalı süperstar.", "/images/artists/shakira.jpg", "Shakira" },
                    { 26, "Funk rock ve alternatif rock'ın öncülerinden Amerikalı grup.", "/images/artists/redhotchilipeppers.jpg", "Red Hot Chili Peppers" },
                    { 27, "Nirvana'nın davulcusu Dave Grohl tarafından kurulan Amerikalı rock grubu.", "/images/artists/foofighters.jpg", "Foo Fighters" },
                    { 28, "Hard rock ve blues rock'ın efsanevi Avustralyalı grubu, yüksek enerjili sahne performanslarıyla bilinir.", "/images/artists/acdc.jpg", "AC/DC" },
                    { 29, "Thrash metal'in öncülerinden ve en büyük gruplarından biri olan Amerikalı heavy metal grubu.", "/images/artists/metallica.jpg", "Metallica" },
                    { 30, "Hard rock'ın ikonik gruplarından, 'Welcome to the Jungle' ve 'Sweet Child o' Mine' gibi hitleriyle ünlüdür.", "/images/artists/gunsnroses.jpg", "Guns N' Roses" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "AlbumId", "ArtistId", "CoverImageUrl", "Price", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, "/images/albums/queen_anightattheopera.jpg", 19.99m, new DateTime(1975, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Night at the Opera" },
                    { 2, 1, "/images/albums/queen_newsoftheworld.jpg", 12.99m, new DateTime(1977, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "News of the World" },
                    { 3, 1, "/images/albums/queen_greatesthits.jpg", 15.99m, new DateTime(1981, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greatest Hits" },
                    { 4, 2, "/images/albums/mj_thriller.jpg", 24.99m, new DateTime(1982, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thriller" },
                    { 5, 3, "/images/albums/beatles_abbeyroad.jpg", 18.50m, new DateTime(1969, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abbey Road" },
                    { 6, 3, "/images/albums/beatles_sgtpepper.jpg", 22.00m, new DateTime(1967, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sgt. Pepper's Lonely Hearts Club Band" },
                    { 7, 3, "/images/albums/beatles_revolver.jpg", 17.00m, new DateTime(1966, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Revolver" },
                    { 8, 4, "/images/albums/madonna_likeavirgin.jpg", 14.00m, new DateTime(1984, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Like a Virgin" },
                    { 9, 4, "/images/albums/madonna_rayoflight.jpg", 16.00m, new DateTime(1998, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ray of Light" },
                    { 10, 5, "/images/albums/ledzeppelin_iv.jpg", 21.00m, new DateTime(1971, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Led Zeppelin IV" },
                    { 11, 5, "/images/albums/ledzeppelin_houses.jpg", 19.50m, new DateTime(1973, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Houses of the Holy" },
                    { 12, 6, "/images/albums/adele_21.jpg", 17.50m, new DateTime(2011, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "21" },
                    { 13, 6, "/images/albums/adele_25.jpg", 18.00m, new DateTime(2015, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "25" },
                    { 14, 7, "/images/albums/taylorswift_1989.jpg", 15.00m, new DateTime(2014, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "1989" },
                    { 15, 7, "/images/albums/taylorswift_red.jpg", 14.50m, new DateTime(2012, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red" },
                    { 16, 8, "/images/albums/eltonjohn_goodbyeyellowbrickroad.jpg", 16.50m, new DateTime(1973, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Goodbye Yellow Brick Road" },
                    { 17, 9, "/images/albums/pinkfloyd_darksideofthemoon.jpg", 25.00m, new DateTime(1973, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Side of the Moon" },
                    { 18, 9, "/images/albums/pinkfloyd_thewall.jpg", 23.00m, new DateTime(1979, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Wall" },
                    { 19, 10, "/images/albums/beyonce_lemonade.jpg", 17.00m, new DateTime(2016, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lemonade" },
                    { 20, 11, "/images/albums/eminem_mmlp.jpg", 15.50m, new DateTime(2000, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Marshall Mathers LP" },
                    { 21, 12, "/images/albums/rihanna_anti.jpg", 13.00m, new DateTime(2016, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anti" },
                    { 22, 13, "/images/albums/coldplay_arushofblood.jpg", 14.00m, new DateTime(2002, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Rush of Blood to the Head" },
                    { 23, 14, "/images/albums/edsheeran_divide.jpg", 16.00m, new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Divide" },
                    { 24, 15, "/images/albums/maroon5_songsaboutjane.jpg", 12.00m, new DateTime(2002, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Songs About Jane" },
                    { 25, 1, "/images/albums/queen_thegame.jpg", 14.50m, new DateTime(1980, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Game" },
                    { 26, 2, "/images/albums/mj_bad.jpg", 20.00m, new DateTime(1987, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bad" },
                    { 27, 2, "/images/albums/mj_dangerous.jpg", 18.00m, new DateTime(1991, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dangerous" },
                    { 28, 3, "/images/albums/beatles_whitealbum.jpg", 25.00m, new DateTime(1968, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "The White Album" },
                    { 29, 5, "/images/albums/ledzeppelin_physicalgraffiti.jpg", 23.00m, new DateTime(1975, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Physical Graffiti" },
                    { 30, 7, "/images/albums/taylorswift_folklore.jpg", 16.00m, new DateTime(2020, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Folklore" },
                    { 31, 6, "/images/albums/adele_21_deluxe.jpg", 19.00m, new DateTime(2011, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "21 (Deluxe Edition)" },
                    { 32, 17, "/images/albums/brunomars_doowops.jpg", 13.50m, new DateTime(2010, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doo-Wops & Hooligans" },
                    { 33, 18, "/images/albums/arianagrande_sweetener.jpg", 15.00m, new DateTime(2018, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sweetener" },
                    { 34, 19, "/images/albums/billieeilish_whenweallfall.jpg", 16.50m, new DateTime(2019, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "When We All Fall Asleep, Where Do We Go?" },
                    { 35, 20, "/images/albums/dualipa_futurenostalgia.jpg", 14.00m, new DateTime(2020, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Future Nostalgia" },
                    { 36, 21, "/images/albums/harrystyles_fineline.jpg", 17.00m, new DateTime(2019, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fine Line" },
                    { 37, 22, "/images/albums/theweeknd_afterhours.jpg", 18.00m, new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "After Hours" },
                    { 38, 23, "/images/albums/postmalone_hollywoodsbleeding.jpg", 15.50m, new DateTime(2019, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hollywood's Bleeding" },
                    { 39, 24, "/images/albums/justinbieber_purpose.jpg", 13.00m, new DateTime(2015, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Purpose" },
                    { 40, 25, "/images/albums/shakira_laundryservice.jpg", 11.00m, new DateTime(2001, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laundry Service" },
                    { 41, 26, "/images/albums/rhcp_californication.jpg", 14.00m, new DateTime(1999, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Californication" },
                    { 42, 27, "/images/albums/foofighters_colourandshape.jpg", 12.00m, new DateTime(1997, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Colour and the Shape" },
                    { 43, 28, "/images/albums/acdc_backinblack.jpg", 19.00m, new DateTime(1980, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Back in Black" },
                    { 44, 29, "/images/albums/metallica_masterofpuppets.jpg", 17.00m, new DateTime(1986, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Master of Puppets" },
                    { 45, 30, "/images/albums/gunsnroses_appetite.jpg", 18.00m, new DateTime(1987, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Appetite for Destruction" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "AlbumId", "AudioFileUrl", "DurationSeconds", "Title" },
                values: new object[,]
                {
                    { 1, 1, null, 354, "Bohemian Rhapsody" },
                    { 2, 1, null, 180, "Killer Queen" },
                    { 3, 1, null, 217, "Love of My Life" },
                    { 4, 2, null, 122, "We Will Rock You" },
                    { 5, 2, null, 179, "We Are the Champions" },
                    { 6, 3, null, 210, "Don't Stop Me Now" },
                    { 7, 25, null, 215, "Another One Bites the Dust" },
                    { 8, 4, null, 294, "Billie Jean" },
                    { 9, 4, null, 258, "Beat It" },
                    { 10, 4, null, 357, "Thriller" },
                    { 11, 26, null, 247, "Bad" },
                    { 12, 27, null, 257, "Smooth Criminal" },
                    { 13, 5, null, 259, "Come Together" },
                    { 14, 5, null, 182, "Something" },
                    { 15, 5, null, 185, "Here Comes the Sun" },
                    { 16, 6, null, 337, "A Day in the Life" },
                    { 17, 7, null, 159, "Yellow Submarine" },
                    { 18, 28, null, 285, "While My Guitar Gently Weeps" },
                    { 19, 8, null, 218, "Like a Virgin" },
                    { 20, 9, null, 318, "Vogue" },
                    { 21, 9, null, 377, "Frozen" },
                    { 22, 10, null, 482, "Stairway to Heaven" },
                    { 23, 10, null, 310, "Whole Lotta Love" },
                    { 24, 29, null, 512, "Kashmir" },
                    { 25, 12, null, 228, "Rolling in the Deep" },
                    { 26, 12, null, 285, "Someone Like You" },
                    { 27, 13, null, 295, "Hello" },
                    { 28, 14, null, 219, "Shake It Off" },
                    { 29, 14, null, 221, "Blank Space" },
                    { 30, 15, null, 328, "All Too Well" },
                    { 31, 30, null, 255, "Cardigan" },
                    { 32, 16, null, 340, "Tiny Dancer" },
                    { 33, 17, null, 398, "Money" },
                    { 34, 18, null, 383, "Comfortably Numb" },
                    { 35, 19, null, 206, "Formation" },
                    { 36, 20, null, 444, "Stan" },
                    { 37, 21, null, 219, "Work" },
                    { 38, 22, null, 307, "Clocks" },
                    { 39, 23, null, 233, "Shape of You" },
                    { 40, 24, null, 206, "This Love" },
                    { 41, 32, null, 233, "Locked Out of Heaven" },
                    { 42, 33, null, 227, "thank u, next" },
                    { 43, 34, null, 194, "Bad Guy" },
                    { 44, 35, null, 183, "Don't Start Now" },
                    { 45, 36, null, 174, "Watermelon Sugar" },
                    { 46, 37, null, 200, "Blinding Lights" },
                    { 47, 38, null, 207, "Circles" },
                    { 48, 39, null, 208, "What Do You Mean?" },
                    { 49, 40, null, 196, "Whenever, Wherever" },
                    { 50, 41, null, 266, "Under the Bridge" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistId",
                table: "Albums",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumId",
                table: "Songs",
                column: "AlbumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
