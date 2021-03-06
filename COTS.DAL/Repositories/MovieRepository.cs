﻿using COTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Repositories
{
    public class MovieRepository : Repository<Movie>
    {
        public MovieRepository(DbContext context) : base(context)
        {

        }

       
        public IEnumerable<Movie> FindAllByCity(string cityId)
        {
            return context.Database.SqlQuery<Movie>(
                "SELECT  dbo.Movies.Id, dbo.Movies.Name, dbo.Movies.ImagePath, dbo.Movies.RankSales, dbo.Movies.DateIssue " +
                "FROM dbo.Movies " +
                "INNER JOIN dbo.Seances on dbo.Movies.Id = dbo.Seances.MovieId " +
                "INNER JOIN dbo.Halls on dbo.Seances.HallId = dbo.Halls.Id "+
                "INNER JOIN dbo.Cinemas on dbo.Halls.CinemaId = dbo.Cinemas.Id " +
                "INNER JOIN dbo.Cities on dbo.Cities.Id = dbo.Cinemas.CityId AND dbo.Cities.Id = @cityId " +
                "GROUP BY dbo.Movies.Id, dbo.Movies.Name, dbo.Movies.ImagePath, dbo.Movies.RankSales, dbo.Movies.DateIssue "
                , new SqlParameter("@cityId", cityId)
            ).ToList();
        }

        public IEnumerable<Movie> FindAllPremeries()
        {
            return context.Database.SqlQuery<Movie>(                                  
                "SELECT * FROM dbo.Movies " +
                "WHERE dbo.Movies.DateIssue <= GETDATE() " +
                "AND DATEADD(day, 15, dbo.Movies.DateIssue) > GETDATE();"
            ).ToList();
        }

        public IEnumerable<Movie> FindAllPremeriesByCity(string cityId)
        {
            return context.Database.SqlQuery<Movie>(
                 "SELECT  dbo.Movies.Id, dbo.Movies.Name, dbo.Movies.ImagePath, dbo.Movies.RankSales, dbo.Movies.DateIssue " +
                 "FROM dbo.Movies " +
                 "INNER JOIN dbo.Seances on dbo.Movies.Id = dbo.Seances.MovieId " +
                 "INNER JOIN dbo.Halls on dbo.Seances.HallId = dbo.Halls.Id " +
                 "INNER JOIN dbo.Cinemas on dbo.Halls.CinemaId = dbo.Cinemas.Id " +
                 "INNER JOIN dbo.Cities on dbo.Cities.Id = dbo.Cinemas.CityId AND dbo.Cities.Id = @cityId " +
                 "AND dbo.Movies.DateIssue <= GETDATE() AND DATEADD(day, 15, dbo.Movies.DateIssue) > GETDATE() " +
                 "GROUP BY dbo.Movies.Id, dbo.Movies.Name, dbo.Movies.ImagePath, dbo.Movies.RankSales, dbo.Movies.DateIssue "
                 , new SqlParameter("@cityId", cityId)
             ).ToList();
        }

        public IEnumerable<Movie> FindAllComingSoon()
        {
            return context.Database.SqlQuery<Movie>(
                "SELECT * FROM dbo.Movies WHERE dbo.Movies.DateIssue > GETDATE();"
            ).ToList();
        }

        public IEnumerable<Movie> FindAllComingSoonByCity(string cityId)
        {
            return context.Database.SqlQuery<Movie>(
                 "SELECT  dbo.Movies.Id, dbo.Movies.Name, dbo.Movies.ImagePath, dbo.Movies.RankSales, dbo.Movies.DateIssue " +
                 "FROM dbo.Movies " +
                 "INNER JOIN dbo.Seances on dbo.Movies.Id = dbo.Seances.MovieId " +
                 "INNER JOIN dbo.Halls on dbo.Seances.HallId = dbo.Halls.Id " +
                 "INNER JOIN dbo.Cinemas on dbo.Halls.CinemaId = dbo.Cinemas.Id " +
                 "INNER JOIN dbo.Cities on dbo.Cities.Id = dbo.Cinemas.CityId AND dbo.Cities.Id = @cityId " +
                 "AND dbo.Movies.DateIssue > GETDATE() " +
                 "GROUP BY dbo.Movies.Id, dbo.Movies.Name, dbo.Movies.ImagePath, dbo.Movies.RankSales, dbo.Movies.DateIssue "
                 , new SqlParameter("@cityId", cityId)
             ).ToList();
        }

        public IEnumerable<Movie> GetTop10ByRankOrder()
        {
            return context.Database.SqlQuery<Movie>(
                "SELECT TOP(10) * FROM dbo.Movies ORDER BY dbo.Movies.RankSales DESC;"
            ).ToList();
        }

        public IEnumerable<Movie> GetTop10ByRankOrderByCity(string cityId)
        {
            return context.Database.SqlQuery<Movie>(
                 "SELECT  dbo.Movies.Id, dbo.Movies.Name, dbo.Movies.ImagePath, dbo.Movies.RankSales, dbo.Movies.DateIssue " +
                 "FROM dbo.Movies " +
                 "INNER JOIN dbo.Seances on dbo.Movies.Id = dbo.Seances.MovieId " +
                 "INNER JOIN dbo.Halls on dbo.Seances.HallId = dbo.Halls.Id " +
                 "INNER JOIN dbo.Cinemas on dbo.Halls.CinemaId = dbo.Cinemas.Id " +
                 "INNER JOIN dbo.Cities on dbo.Cities.Id = dbo.Cinemas.CityId AND dbo.Cities.Id = @cityId " +
                 "GROUP BY dbo.Movies.Id, dbo.Movies.Name, dbo.Movies.ImagePath, dbo.Movies.RankSales, dbo.Movies.DateIssue " +
                 "ORDER BY dbo.Movies.RankSales DESC;"
                 , new SqlParameter("@cityId", cityId)
             ).ToList();
        }
    }
}
