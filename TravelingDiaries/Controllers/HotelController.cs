using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TravelingDiaries.Models;

namespace TravelingDiaries.Controllers
{
    public class HotelController : Controller
    {

        /*
                to retrive all the Hotels*/
        public async Task<IActionResult> GetAllHotels()
        {
            IEnumerable<Hotel> hotels = new List<Hotel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7015/Hotel/GetAllHotels"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    hotels = JsonConvert.DeserializeObject<IEnumerable<Hotel>>(apiResponse);
                }

            }
            return View(hotels);

        }


 /*       to get the details of single Hotel*/

        public async Task<IActionResult> HotelDetail(int? id)
        {
            var hotel = new Hotel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7015/Hotel/GetHotelById?id="+id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    hotel = JsonConvert.DeserializeObject<Hotel>(apiResponse);
                }

            }

            ViewData["ID"] = id;
            return View(hotel);

        }


    }
}
