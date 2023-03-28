using api;
using api.interfaces;
using api.models;
using MySql.Data.MySqlClient;
using System;

namespace api.Database
{
    public class SaveSong : ISave
    {
        public static void CreateSongTable()
        {
            Connect myConnection = new Connect();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE songs(id VARCHAR(255) PRIMARY KEY, title TEXT, artist TEXT, date_added DATETIME, favorited BOOLEAN, deleted BOOLEAN)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }
        public void CreateSong(Song mySong)
        {
            Connect myConnection = new Connect();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO songs(id, title, artist, date_added, favorited, deleted) VALUES(@id, @title, @artist, @date_added, @favorited, @deleted)";

            using var cmd = new MySqlCommand(stm, con);

            
            cmd.Parameters.AddWithValue("@title", mySong.Title);
            cmd.Parameters.AddWithValue("@artist", mySong.Artist);
            cmd.Parameters.AddWithValue("@date_added", mySong.DateAdded);
            cmd.Parameters.AddWithValue("@favorited", mySong.Favorited);
            cmd.Parameters.AddWithValue("@deleted", mySong.Deleted);
            cmd.Parameters.AddWithValue("@id", mySong.ID);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        public void UpdateSong(Song mySong)
        {
            Connect myConnection = new Connect();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE songs SET title = @title, artist = @artist, favorited = @favorited, deleted = @deleted WHERE id = @id";

            using var cmd = new MySqlCommand(stm, con);

            
            cmd.Parameters.AddWithValue("@title", mySong.Title);
            cmd.Parameters.AddWithValue("@artist", mySong.Artist);
            cmd.Parameters.AddWithValue("@favorited", mySong.Favorited);
            cmd.Parameters.AddWithValue("@deleted", mySong.Deleted);
            cmd.Parameters.AddWithValue("@id", mySong.ID);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        void ISave.SaveSong(Song mySong)
        {
            // SaveSong(mySong);
        }

        public void InitializeDatabase()
        {
            string sql = @"USE s80nt7070ufuczp0;
                DROP TABLE IF EXISTS songs;

                CREATE TABLE IF NOT EXISTS songs (
                    id VARCHAR(255) PRIMARY KEY,
                    title TEXT NOT NULL,
                    artist TEXT NOT NULL,
                    date_added DATETIME NOT NULL,
                    favorited BOOLEAN NOT NULL DEFAULT 0,
                    deleted BOOLEAN NOT NULL DEFAULT 0
                );

                SELECT * FROM s80nt7070ufuczp0.songs;";

            Connect myConnection = new Connect();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            using var cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public Song GetSongById(string id)
        {
            Connect myConnection = new Connect();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM songs WHERE id = @id";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Song song = new Song
                {
                    Title = reader.GetString("title"),
                    Artist = reader.GetString("artist"),
                    DateAdded = reader.GetDateTime("date_added"),
                    Favorited = reader.GetBoolean("favorited"),
                    Deleted = reader.GetBoolean("deleted"),
                    ID = reader.GetString("id")
                };
                return song;
            }
            else
            {
                return null;
            }
        }

    }
}