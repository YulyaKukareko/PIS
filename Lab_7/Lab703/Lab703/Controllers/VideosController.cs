using System.Web;
using System.Web.Mvc;
using Lab703.Models;
using Lab703.Services;

namespace Lab703.Controllers
{
    public class VideosController : Controller
    {
        private readonly VideosService _service = new VideosService();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.VideosList = _service.GetAll();
            return View();
        }

        [HttpGet]
        public ActionResult Video(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.VideosList = _service.GetAll();
            ViewBag.VideoFileId = id;
            return View("VideoBlock");
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        public ActionResult GetVideo(int id)
        {
            return new VideoResult(_service.GetShortPath(id) + ".mp4");
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            var video = new Video
            {
                File = file
            };
            var result = _service.UploadVideo(video);
            if (result == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Error = result;

            return View();
        }
    }
}