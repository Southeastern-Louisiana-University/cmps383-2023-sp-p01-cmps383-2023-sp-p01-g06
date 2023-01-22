using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        [Required, MaxLength(120)] // Must return "Name" Maximum Character Length is 120.
        public string Name { get; set; } = string.Empty;

        [Required] //Must return "Address"
        public string Address { get; set; } = string.Empty;





    }
}
