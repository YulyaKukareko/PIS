using System.IO;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Lab703.Controllers
{
    public class VideoResult : ActionResult
    {
        // GET: VideoResult
        public VideoResult(string videoPath)
        {
            VideoPath = videoPath;
        }

        public VideoResult()
        {
        }

        private string VideoPath { get; }

        public override void ExecuteResult(ControllerContext context)
        {
            var videoFilePath = HostingEnvironment.MapPath(VideoPath);
            context.HttpContext.Response.AddHeader("Content-Disposition",
                "attachment; filename=" + Path.GetFileName(VideoPath));
            var file = new FileInfo(videoFilePath);
            if (file.Exists)
            {
                var stream = file.OpenRead();
                var bytesinfile = new byte[stream.Length];
                stream.Read(bytesinfile, 0, (int)file.Length);
                context.HttpContext.Response.BinaryWrite(bytesinfile);
            }
        }
    }
}