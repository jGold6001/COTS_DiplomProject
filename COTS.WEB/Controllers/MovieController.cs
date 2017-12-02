using AutoMapper;
using COTS.BLL.DTO;
using COTS.BLL.Interfaces;
using COTS.WEB.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COTS.WEB.Controllers
{
    [RoutePrefix("movie")]
    public class MovieController : Controller
    {
        IMovieService movieService;
        IMapper mapper;

        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<MovieDTO, MovieViewModel>()));
        }

        public ActionResult Index()
        {
            ViewBag.CityId = "kiev";
            return View("Index");
        }

        [Route("{cityId}")]
        public ActionResult GetAllByCity(string cityId)
        {
            ViewBag.CityId = cityId;
            return View("Index");
        }

        [Route("{cityId}/{id:long}")]
        public ActionResult GetOneByCity(string cityId, long id)
        {
            MovieDTO movieDTO = movieService.GetOne(id);
            var movie = mapper.Map<MovieDTO, MovieViewModel>(movieDTO);

            ViewBag.CityId = cityId;

            //host name
            ViewBag.BaseUrl = Request.Url.Authority;                    
            return View("MovieView", movie);
        }

        [Route("premeries/{cityId}")]
        public ActionResult GetAllPremeriesByCity(string cityId)
        {
            ViewData["cityId"] = cityId;
            IEnumerable<MovieDTO> moviesDTOs = movieService.FindAllPremeriesByCity(cityId);
            var movies = mapper.Map<IEnumerable<MovieDTO>, IEnumerable<MovieViewModel>>(moviesDTOs);
            return PartialView("GetAllByCity", movies);
        }

        [Route("comingsoon/{cityId}")]
        public ActionResult GetAllCommingSoonByCity(string cityId)
        {
            ViewData["cityId"] = cityId;
            IEnumerable<MovieDTO> moviesDTOs = movieService.FindAllComingSoonByCity(cityId);
            var movies = mapper.Map<IEnumerable<MovieDTO>, IEnumerable<MovieViewModel>>(moviesDTOs);
            return PartialView("GetAllByCity", movies);
        }

        [Route("top10/{cityId}")]
        public ActionResult GetTop10ByCity(string cityId)
        {
            ViewData["cityId"] = cityId;
            IEnumerable<MovieDTO> moviesDTOs = movieService.GetTop10ByRankOrderByCity(cityId);
            var movies = mapper.Map<IEnumerable<MovieDTO>, IEnumerable<MovieViewModel>>(moviesDTOs);
            return PartialView("GetAllByCity", movies);
        }

        [Route("get_json/{cityId}")]
        public JsonResult GetAllByCityJson(string cityId)
        {
            IEnumerable<MovieDTO> moviesDTOs = movieService.FindAllByCity(cityId);
            var movies = mapper.Map<IEnumerable<MovieDTO>, IEnumerable<MovieViewModel>>(moviesDTOs);
            return Json(movies, JsonRequestBehavior.AllowGet);
        }
    }
}