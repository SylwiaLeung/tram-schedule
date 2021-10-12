using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tram_Schedule.Models
{
    public class TramStop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public Route Route { get; set; }
        [ForeignKey("Route")]
        public int? RouteID { get; set; }
    }
}