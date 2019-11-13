using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace areaCalculator.Controllers
{
    public class AreaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Calculate([Bind("Length, Width, ShapeType, Area")] Models.Shape shape)
        {
            HttpClient httpClient = new HttpClient();            
            httpClient.BaseAddress = new Uri("http://calculatorapi");

            try
            {
                switch (shape.ShapeType)
                {
                    case "circle":
                        var p1 = JsonConvert.SerializeObject(new { radius = shape.Radius });
                        var c1 = new StringContent(p1);
                        var r1 = await httpClient.PostAsync("api/area/circle", c1);
                        shape.Area = double.Parse(r1.Content.ToString());

                        break;
                    case "rectangle":
                        var payload = JsonConvert.SerializeObject(new { length = shape.Length, width = shape.Width });
                        var content = new StringContent(payload);
                        var result = await httpClient.PostAsync("api/area/rectangle", content);
                        shape.Area = double.Parse(result.Content.ToString());
                        break;
                }
                //ViewData["area"] = area;
                return View(shape);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(ex);
            }
        }
    }
}