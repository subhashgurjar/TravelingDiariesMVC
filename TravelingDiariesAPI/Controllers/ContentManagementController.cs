using Microsoft.AspNetCore.Mvc;
using TravelingDiariesAPI.Models;

namespace TravelingDiariesAPI.Controllers
{
    [ApiController]
    [Route("ContentManagement")]
    public class ContentManagementController : ControllerBase
    {
        private readonly IPlaceRepository placeRepository;

        public ContentManagementController(IPlaceRepository placeRepository)
        {
            this.placeRepository = placeRepository;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        [Route("CM")]

        //CM page view
        public IActionResult CM()
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


        //for the create form
       /* public IActionResult Create()
        {
            return View();
        }*/

        [HttpPost]
        [Route("AddPlace")]
        
        public IActionResult AddPlace(Place p)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    placeRepository.AddPlace(p);
                    return Ok(p);
                }
                return RedirectToAction("CM");
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }

        }

       /* [HttpPut]
        [ValidateAntiForgeryToken]
        [Route("EditPlace")]
        public IActionResult EditPlace(int id)
        {
            try
            {
                Place p = placeRepository.GetAllPlaces().FirstOrDefault(s => s.PlaceID == id);
              
                return Ok(p);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }

        }*/
       
        [HttpPut]
    
        [Route("EditPlace")]
        public IActionResult EditPlace(Place p)
        {
            try
            {
                placeRepository.EditPlace(p);

                return Ok(p);
              /*  if (ModelState.IsValid)
                {
                    placeRepository.EditPlace(place);
                }
                return RedirectToAction("CM");*/

            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
           
        }


        //to remove from the db
        [HttpDelete]
        [Route("RemovePlace")]
        public IActionResult RemovePlace(int? id)
        {
            try
            {
                placeRepository.RemovePlace(id);


                return RedirectToAction("CM");
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

    }
}
