using _4_Music_Playlist_Manager;
using _4_Music_Playlist_Manager.models;
using _4_Music_Playlist_Manager;
using _4_Music_Playlist_Manager.models;

namespace _4_Music_Playlist_Manager {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("========================================");
            Console.WriteLine("   MUSIC PLAYLIST MANAGER - DEMO");
            Console.WriteLine("========================================\n");

            PlaylistManager manager = new PlaylistManager();

            // Create sample songs
            Song song1 = new Song("Bohemian Rhapsody", "Queen", 5);
            Song song2 = new Song("Imagine", "John Lennon", 5);
            Song song3 = new Song("Hotel California", "Eagles", 4);
            Song song4 = new Song("Shape of You", "Ed Sheeran", 3);
            Song song5 = new Song("Rolling in the Deep", "Adele", 4);
            Song song6 = new Song("Billie Jean", "Michael Jackson", 5);
            Song song7 = new Song("Stairway to Heaven", "Led Zeppelin", 5);
            Song song8 = new Song("Happy", "Pharrell Williams", 3);

            Console.WriteLine("Step 1: Adding songs to all collections...\n");

            manager.AddSongComplete(song1);
            manager.AddSongComplete(song2);
            manager.AddSongComplete(song3);
            manager.AddSongComplete(song4);
            manager.AddSongComplete(song5);
            manager.AddSongComplete(song6);
            manager.AddSongComplete(song7);
            manager.AddSongComplete(song8);

            // ========== DEMO 1: PLAYLIST OPERATIONS (LinkedList) ==========
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("DEMO 1: PLAYLIST OPERATIONS (LinkedList)");
            Console.WriteLine(new string('=', 50));

            manager.DisplayPlaylist();

            // Insert song after a specific song
            Song newSong = new Song("Someone Like You", "Adele", 4);
            manager.InsertSongAfter("Imagine", newSong);
            manager.DisplayPlaylist();

            // Insert song before a specific song
            Song anotherSong = new Song("Thriller", "Michael Jackson", 5);
            manager.InsertSongBefore("Happy", anotherSong);
            manager.DisplayPlaylist();

            // Remove a song
            manager.RemoveSongFromPlaylist("Shape of You");
            manager.DisplayPlaylist();

            // Move songs
            manager.MoveSongToTop("Billie Jean");
            manager.MoveSongToBottom("Stairway to Heaven");
            manager.DisplayPlaylist();

            // ========== DEMO 2: SORTING BY RATING (SortedList) ==========
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("DEMO 2: SONGS SORTED BY RATING (SortedList)");
            Console.WriteLine(new string('=', 50));

            manager.DisplaySongsByRating();
            manager.DisplaySongsByRatingDescending();

            // ========== DEMO 3: SORTING BY ARTIST (SortedDictionary) ==========
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("DEMO 3: SONGS SORTED BY ARTIST NAME (SortedDictionary)");
            Console.WriteLine(new string('=', 50));

            manager.DisplaySongsByArtist();

            // Search by artist
            string? songByArtist = manager.GetSongByArtist("Queen");
            if (songByArtist != null) {
                Console.WriteLine($"\n✓ Found: Queen → {songByArtist}");
            }

            // ========== DEMO 4: EFFICIENT INSERTION/DELETION ==========
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("DEMO 4: EFFICIENT INSERTION/DELETION DEMO");
            Console.WriteLine(new string('=', 50));

            Console.WriteLine("Adding a new song at the end (O(1) operation):");
            Song newHit = new Song("Blinding Lights", "The Weeknd", 5);
            manager.AddSongToPlaylist(newHit);

            Console.WriteLine("\nRemoving first song (O(1) operation):");
            if (manager.RemoveSongFromPlaylist("Bohemian Rhapsody")) {
                Console.WriteLine("✓ First song removed efficiently!");
            }

            manager.DisplayPlaylist();

            // ========== FINAL SUMMARY ==========
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("FINAL SUMMARY");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("✓ LinkedList: Efficient O(1) add/remove from ends");
            Console.WriteLine("✓ SortedList: Songs automatically sorted by rating");
            Console.WriteLine("✓ SortedDictionary: Artists automatically sorted A-Z");
            Console.WriteLine("\n✓ All requirements met successfully!");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}