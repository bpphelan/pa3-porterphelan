using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.models;
using api.Handler;
using api.Database;
using Newtonsoft.Json;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        // GET
        [HttpGet]
        public List<Song> Get()
        {
            SongHandler mySongHandler = new SongHandler();
            return mySongHandler.GetAllSongs();

            
        }

       
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(string id)
        {
            SaveSong mySavedSong = new SaveSong();
            Song song = mySavedSong.GetSongById(id);
            Console.WriteLine("Fetched Song: " + JsonConvert.SerializeObject(song)); 

            if (song != null)
            {
                return Ok(song);
            }
            else
            {
                return NotFound();
            }
        }

        // POST
        [HttpPost]  
        public void Post([FromBody] Song value)
        {
            SongHandler mySongHandler = new SongHandler();
            mySongHandler.AddSong(value);
        }

        // PUT
        [HttpPut("{id}")]   
        public void Put(string id, [FromBody] Song value)
        {
            SongHandler mySongHandler = new SongHandler();
            mySongHandler.EditSong(id, value);
        }

        // DELETE
        [HttpDelete("{id}")]    
        public void Delete(string id)
        {
            SongHandler mySongHandler = new SongHandler();
            mySongHandler.DeleteSong(id);
        }
    }
}