using api.models;
using api.Database;

namespace api.Handler{
    public  class SongHandler{
        public static List<Song> AllSongs = new List<Song>();

        public SongHandler(){
            
        }

        public List<Song> GetAllSongs(){
            return AllSongs;
        }

        public void AddSong(Song newSong){
            SaveSong saveSong = new SaveSong();
            saveSong.CreateSong(newSong);
            AllSongs.Add(newSong);
            PrintAll();
        }

        public void PrintAll(){
            foreach(Song song in AllSongs){
                System.Console.WriteLine(song.ToString());
            }
        }

         public void EditSong(string id, Song editSong)
        {
            int index = AllSongs.FindIndex(s => s.ID == id);
            SaveSong saveSong = new SaveSong();
            saveSong.UpdateSong(editSong);
            AllSongs[index] = editSong;
        }

        public void DeleteSong(string id)
        {
            int index = AllSongs.FindIndex(s => s.ID == id);
            AllSongs.RemoveAt(index);
            DeleteSong deleteSong = new DeleteSong();
            deleteSong.DeleteSongById(id);
        }
    }
}