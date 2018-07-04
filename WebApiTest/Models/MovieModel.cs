using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiTest.Models
{
    public class MovieModel
    {
        public int id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int Runtime { get; set; }
    }

    public class MovieModelDb : DbContext
    {
        public DbSet<MovieModel> Movies { get; set; }
    }
}