using api.interfaces;
using api.models;
using MySql.Data.MySqlClient;
using System;

namespace api.Database
{
    public class DeleteSong : IDelete
    {
        public static void DropSongTable()
        {
            Connect myConnection = new Connect();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DROP TABLE IF EXISTS songs";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        public void DeleteSongById(string id)
        {
            Connect myConnection = new Connect();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DELETE FROM songs WHERE id = @id";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        void IDelete.DeleteSong(string id)
        {
            throw new NotImplementedException();
        }
    }
}