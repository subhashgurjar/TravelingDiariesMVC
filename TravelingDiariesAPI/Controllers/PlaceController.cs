using Microsoft.AspNetCore.Mvc;
using TravelingDiariesAPI.Models;

namespace TravelingDairies.Controllers
{
    [ApiController]
    [Route("Place")]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceRepository placeRepository;

        public PlaceController(IPlaceRepository placeRepository)
        {
            this.placeRepository = placeRepository;
        }

        [HttpGet]
        [Route("GetAllPlaces")]
        //to retrive all the places.
        public IActionResult GetAllPlaces()
        {
            try
            {
                var places = this.placeRepository.GetAllPlaces();
                return Ok(places);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
        [HttpGet]
        [Route("GetPlaceById")]
        public IActionResult GetPlaceById(int id)
        {
            try
            {
                var places = placeRepository.PlaceDetail(id);
                return Ok(places);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");

            }
            /*
                    }
                    [HttpPost]
                    [Route("AddPlaces")]
                    public IActionResult AddPlace(Place p)
                    {
                        try
                        {
                           placeRepository.AddPlace(p);
                            return Ok(place);
                        }
                        catch (Exception)
                        {

                            return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
                        }

                    }
                    [HttpDelete]
                    [Route("RemovePlaces")]
                    public IActionResult RemovePlaces(int id)
                    {
                        try
                        {
                            var place = placeRepository.GetAllPlaces.FirstOrDefault(s => s.PlaceId == id);
                            placeRepository.RemovePlace(place);
                            return Ok(place);
                        }
                        catch (Exception)
                        {

                            return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
                        }



                    }
                    [HttpPut]
                    [Route("EditPlace")]
                    public IActionResult EditPlace(Place p)
                    {
                        try
                        {
                            var EditPlace = placeRepository.EditPlace(p);

                            return Ok(EditPlace);
                        }
                        catch (Exception)
                        {

                            return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
                        }



                    }*/
        }
    }
}

