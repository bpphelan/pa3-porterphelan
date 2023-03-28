using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.interfaces
{
    public interface ISave
    {
        public void CreateSong(Song mySong);
        public void SaveSong(Song mySong);
    }
}