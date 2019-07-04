using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Lab703.Models;

namespace Lab703.Context
{
    public class VideosContext : DbContext
    {
        public VideosContext() : base("videosConnectionString")
        {
        }

        public DbSet<VideoModel> Videos { get; set; }
    }
}