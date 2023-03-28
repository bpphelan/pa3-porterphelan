using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.interfaces;
using api.Database;

namespace api.models
{
    public class Song
    {
        public string Title {get; set;} 
        public string Artist {get; set;}
        
        public DateTime DateAdded {get; set;}
        public bool Favorited {get; set;}
        public bool Deleted {get; set;}
        public string ID {get; set;}
        
       
       public ISave Save {get; set;} 
       
       
        public Song(){
            ID = Guid.NewGuid().ToString();
            Save = new SaveSong();

        }

        public override string ToString(){
            return $"{Title} {Artist} {DateAdded} {Favorited} {Deleted} {ID}" ;
        }

        internal void Add(Song song){
            throw new NotImplementedException();
        }

       


   
   
   
   
   
    }
}