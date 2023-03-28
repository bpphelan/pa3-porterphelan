using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.interfaces
{
    public interface IDelete
    {
        public void DeleteSong(string ID);
    }
}