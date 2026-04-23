using System;
using System.Collections.Generic;
using System.Text;
using _4_Music_Playlist_Manager.models;

namespace _4_Music_Playlist_Manager {
    public class PlaylistManager {
        // LinkedList for playlist songs (easy insertion/removal)
        private LinkedList<Song> _playlist;

        // SortedList by rating (int rating -> song title)
        private SortedList<int, string> _songsByRating;

        // SortedDictionary by artist name (artist -> song title)
        private SortedDictionary<string, string> _songsByArtist;

        public PlaylistManager() {
            _playlist = new LinkedList<Song>();
            _songsByRating = new SortedList<int, string>();
            _songsByArtist = new SortedDictionary<string, string>();
        }

        // ========== Playlist Operations (LinkedList) ==========

        // Add song to playlist
        public void AddSongToPlaylist(Song song) {
            _playlist.AddLast(song);
            Console.WriteLine($"✓ Added to playlist: {song}");
        }

        // Remove song from playlist by title
        public bool RemoveSongFromPlaylist(string title) {
            var node = _playlist.First;
            while (node != null) {
                if (node.Value.Title.Equals(title, StringComparison.OrdinalIgnoreCase)) {
                    _playlist.Remove(node);
                    Console.WriteLine($"✓ Removed from playlist: {title}");
                    return true;
                }
                node = node.Next;
            }
            Console.WriteLine($"✗ Song not found: {title}");
            return false;
        }

        // Insert song after a specific song
        public bool InsertSongAfter(string afterTitle, Song newSong) {
            var node = _playlist.First;
            while (node != null) {
                if (node.Value.Title.Equals(afterTitle, StringComparison.OrdinalIgnoreCase)) {
                    _playlist.AddAfter(node, newSong);
                    Console.WriteLine($"✓ Inserted '{newSong.Title}' after '{afterTitle}'");
                    return true;
                }
                node = node.Next;
            }
            Console.WriteLine($"✗ Reference song '{afterTitle}' not found");
            return false;
        }

        // Insert song before a specific song
        public bool InsertSongBefore(string beforeTitle, Song newSong) {
            var node = _playlist.First;
            while (node != null) {
                if (node.Value.Title.Equals(beforeTitle, StringComparison.OrdinalIgnoreCase)) {
                    _playlist.AddBefore(node, newSong);
                    Console.WriteLine($"✓ Inserted '{newSong.Title}' before '{beforeTitle}'");
                    return true;
                }
                node = node.Next;
            }
            Console.WriteLine($"✗ Reference song '{beforeTitle}' not found");
            return false;
        }

        // Display entire playlist
        public void DisplayPlaylist() {
            Console.WriteLine("\n=== Current Playlist (Play Order) ===");
            if (_playlist.Count == 0) {
                Console.WriteLine("Playlist is empty");
                return;
            }

            int index = 1;
            foreach (var song in _playlist) {
                Console.WriteLine($"{index}. {song}");
                index++;
            }
            Console.WriteLine($"Total songs: {_playlist.Count}\n");
        }

        // ========== Rating Operations (SortedList) ==========

        // Add song to rating collection
        public void AddSongByRating(Song song) {
            // Handle duplicate ratings by adding suffix
            string songRef = song.Title;
            while (_songsByRating.ContainsKey(song.Rating) && _songsByRating[song.Rating] == songRef) {
                songRef = song.Title + " (duplicate)";
            }

            if (!_songsByRating.ContainsKey(song.Rating)) {
                _songsByRating.Add(song.Rating, songRef);
                Console.WriteLine($"✓ Added to rating list: {song.Title} (Rating: {song.Rating}★)");
            }
            else {
                Console.WriteLine($"Note: Rating {song.Rating}★ already has a song");
            }
        }

        // Display songs sorted by rating
        public void DisplaySongsByRating() {
            Console.WriteLine("\n=== Songs Sorted by Rating (Lowest to Highest) ===");
            if (_songsByRating.Count == 0) {
                Console.WriteLine("No songs in rating list");
                return;
            }

            foreach (var item in _songsByRating) {
                Console.WriteLine($"{item.Key}★ → {item.Value}");
            }
            Console.WriteLine();
        }

        // Display songs sorted by rating (descending)
        public void DisplaySongsByRatingDescending() {
            Console.WriteLine("\n=== Songs Sorted by Rating (Highest to Lowest) ===");
            if (_songsByRating.Count == 0) {
                Console.WriteLine("No songs in rating list");
                return;
            }

            var reversed = _songsByRating.Reverse();
            foreach (var item in reversed) {
                Console.WriteLine($"{item.Key}★ → {item.Value}");
            }
            Console.WriteLine();
        }

        // ========== Artist Operations (SortedDictionary) ==========

        // Add song to artist collection
        public void AddSongByArtist(Song song) {
            if (!_songsByArtist.ContainsKey(song.Artist)) {
                _songsByArtist.Add(song.Artist, song.Title);
                Console.WriteLine($"✓ Added to artist list: {song.Artist} → {song.Title}");
            }
            else {
                // Handle multiple songs by same artist (show warning)
                Console.WriteLine($"Note: Artist '{song.Artist}' already has a song in the dictionary");
            }
        }

        // Display songs sorted by artist name
        public void DisplaySongsByArtist() {
            Console.WriteLine("\n=== Songs Sorted by Artist Name (A-Z) ===");
            if (_songsByArtist.Count == 0) {
                Console.WriteLine("No songs in artist list");
                return;
            }

            foreach (var item in _songsByArtist) {
                Console.WriteLine($"{item.Key} → {item.Value}");
            }
            Console.WriteLine();
        }

        // Get song by artist
        public string? GetSongByArtist(string artist) {
            if (_songsByArtist.TryGetValue(artist, out string? song)) {
                return song;
            }
            return null;
        }

        // ========== Complete Operations ==========

        // Add song to all collections
        public void AddSongComplete(Song song) {
            AddSongToPlaylist(song);
            AddSongByRating(song);
            AddSongByArtist(song);
            Console.WriteLine($"✓ Song '{song.Title}' added to all collections!\n");
        }

        // Move song in playlist (reorder)
        public void MoveSongToTop(string title) {
            var node = _playlist.First;
            while (node != null) {
                if (node.Value.Title.Equals(title, StringComparison.OrdinalIgnoreCase)) {
                    _playlist.Remove(node);
                    _playlist.AddFirst(node.Value);
                    Console.WriteLine($"✓ Moved '{title}' to top of playlist");
                    return;
                }
                node = node.Next;
            }
            Console.WriteLine($"✗ Song '{title}' not found");
        }

        public void MoveSongToBottom(string title) {
            var node = _playlist.First;
            while (node != null) {
                if (node.Value.Title.Equals(title, StringComparison.OrdinalIgnoreCase)) {
                    _playlist.Remove(node);
                    _playlist.AddLast(node.Value);
                    Console.WriteLine($"✓ Moved '{title}' to bottom of playlist");
                    return;
                }
                node = node.Next;
            }
            Console.WriteLine($"✗ Song '{title}' not found");
        }
    }
}