using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP23.P01.Web.Dtos
{
    internal class UpdateTrainStationDto
    {

        public int Id;


        [Required, MaxLength(120)] // Must return "Name" Maximum character length is 120
        public string Name { get; set; } = string.Empty;


        [Required] // Must return "Address"
        public string Address { get; set; } = string.Empty;




    }
}
