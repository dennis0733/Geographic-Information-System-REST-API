using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocationApp.ViewModel
{
    public class LocationViewModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
       
        public double X { get; set; }
        public double Y { get; set; }

    }
}
