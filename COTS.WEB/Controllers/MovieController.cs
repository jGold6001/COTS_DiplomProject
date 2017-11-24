﻿using AutoMapper;
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
            IEnumerable<MovieDTO> moviesDTOs = movieService.GetAll();
            var movies = mapper.Map<IEnumerable<MovieDTO>, IEnumerable<MovieViewModel>>(moviesDTOs);
            return View(movies);           
        }
    }
}