using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SP23.P01.Tests.Web.Dtos
{
    internal class CreateTrainStationDto
    {


        public int Id;
        
        [Required] // Must return "Name"
        public string Name;

        
        [Required] //Must return "Address"
        public string Address;

        
       
        
    }
}
