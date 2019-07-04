using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using Lab703.Context;
using Lab703.Models;

namespace Lab703.Services
{
    public class VideosService
    {
        private readonly VideosContext _context = new VideosContext();

        public string GetName(int id)
        {
            return "Video_" + id;
        }

        public string GetPath(int id)
        {
            return Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "Videos", GetName(id));
        }

        public string GetShortPath(int id)
        {
            return Path.Combine("~", "App_Data", "Videos", GetName(id));
        }

        private bool IsVideo(string ext)
        {
            var arr = new List<string>
            {
                ".mp4",
                ".avi"
            };

            return arr.Contains(ext, StringComparer.OrdinalIgnoreCase);
        }

        public string UploadVideo(Video video)
        {
            if (video?.File == null || video.File.ContentLength <= 0)
            {
                return "Incorrect file";
            }

            var fileName = Path.GetFileName(video.File.FileName);

            if (fileName == null)
            {
                return "Empty file name";
            }

            var ext = Path.GetExtension(fileName);
            if (!IsVideo(ext))
            {
                return "It is not a supported file/not a video";
            }

            var videoModel = Add(new VideoModel { OriginalName = fileName });
            var path = GetPath(videoModel.Id) + ext;
            try
            {
                video.File.SaveAs(path);
            }
            catch (Exception e)
            {
                Delete(videoModel);
            }

            return null;
        }

        public VideoModel Add(VideoModel model)
        {
            _context.Videos.Add(model);
            _context.SaveChanges();
            return model;
        }

        public void Delete(VideoModel model)
        {
            _context.Videos.Remove(model);
            _context.SaveChanges();
        }

        public VideoModel Get(int id)
        {
            return _context.Videos.FirstOrDefault(x => x.Id == id);
        }

        public List<VideoModel> GetAll()
        {
            return _context.Videos.ToList();
        }
    }
}