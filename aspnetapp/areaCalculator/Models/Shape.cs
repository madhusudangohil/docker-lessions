using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace areaCalculator.Models
{
    public class Shape
    {
        public string ShapeType { get; set; }
        public double Area { get; set; }

        [JsonProperty("length")]
        public int Length { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("radius")]
        public int Radius { get; set; }
    }
    
}
