using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace areaCalculator.Controllers
{
    public class AreaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Calculate([Bind("Length, Width, Radius, ShapeType, Area")] Models.Shape shape)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://calculatorapi");

            try
            {
                Console.WriteLine("Shape is " + shape.ShapeType);
                switch (shape.ShapeType)
                {
                    case "circle":                        
                        var r1 = await httpClient.PostAsync("/api/area/circle", 
                        FormatPayload(new { radius = shape.Radius }));
                        shape.Area = await ExtractResponse(r1);                         
                        break;
                    case "rectangle":
                        var r2 = await httpClient.PostAsync("/api/area/rectangle",
                            FormatPayload(new { length = shape.Length, width = shape.Width }));
                        shape.Area = await ExtractResponse(r2);                        
                        break;
                }                
                return View(shape);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(ex);
            }
        }

        private StringContent FormatPayload<T>(T payload)
        {
            var p1 = JsonConvert.SerializeObject(payload);
            Console.WriteLine(p1);
            var c1 = new StringContent(p1);
            c1.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return c1;
        }

        private async ValueTask<double> ExtractResponse(HttpResponseMessage message)
        {
            string areajson = await message.Content.ReadAsStringAsync();
            dynamic area = JsonConvert.DeserializeObject<dynamic>(areajson);            
            return area.area;
        }
    }
}