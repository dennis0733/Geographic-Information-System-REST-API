using LocationApp.Data;
using LocationApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LocationApp.Controllers
{
    public class LocationController : Controller
    {
       
        private readonly LocationDataContext context;
        public LocationController(LocationDataContext context)
        {
            this.context = context;
        }

        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            var locations = this.context.Locations.Select(m => new LocationViewModel
            {
                
                Name = m.Name,
                X=m.X,
                Y=m.Y,
                Id = m.Id,


            });
            if (locations == null)
            {
                return BadRequest("Location Database is empty");
            }

            return Ok(locations);
        }

        [HttpGet("Get By Id")]
        public IActionResult GetbyID(int id)
        {
            var locations = this.context.Locations.Find(id);

            if (locations == null)
            {
                return BadRequest("Location Not Found");
            }

            return Ok(locations);



        }


        [HttpPost("Add")]
        public IActionResult Add(Location loc)
        {
          if(loc.Name==null && loc.X==0 && loc.Y == 0)
            {
                return BadRequest("There is no information about location");
            }

          this.context.Add(loc);
          this.context.SaveChanges();

            return Ok("Added Succesfully");
        }


        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var locations = this.context.Locations.Find(id);
           if(locations == null)
            { return BadRequest("Location Not Found"); }

            this.context.Remove(locations);
            this.context.SaveChanges();

            return Ok("Deleted Successfully");

        }

        [HttpPut("Update")]
        public IActionResult Update(Location location)
        {
            var loc = this.context.Locations.Find(location.Id);

            
            if (loc == null)
            {
                return BadRequest("Location Not Found");
            }

            
            if (location.Name != null)
            {
               loc.Name = location.Name;
            }

            if (location.X != 0)
            {
                loc.X = location.X;
            }

            if (location.Y != 0)
            {
                loc.Y = location.Y;
            }
            
        



            this.context.Update(loc);
            this.context.SaveChanges();



            return Ok("Updated Successfully");
        }

        

           
        
    }
}
