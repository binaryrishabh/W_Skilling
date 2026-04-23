using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Music_Playlist_Manager.models {
    public class Song {
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Rating { get; set; }  // 1-5 stars

        public Song(string title, string artist, int rating) {
            Title = title;
            Artist = artist;
            Rating = rating;
        }

        public override string ToString() {
            return $"{Title} by {Artist} (Rating: {Rating}★)";
        }

        public override bool Equals(object? obj) {
            if (obj is Song other) {
                return Title == other.Title && Artist == other.Artist;
            }
            return false;
        }

        public override int GetHashCode() {
            return HashCode.Combine(Title, Artist);
        }
    }
}