using Microsoft.AspNetCore.Mvc;

namespace Lab_APSNETCORE.Controllers
{
    public class DiShowerController : Controller
    {
        private readonly ForSingleton singleton;
        private readonly ForScoped scope;
        public DiShowerController(ForSingleton singleton, ForScoped scope)
        {
            this.singleton = singleton;
            this.scope = scope;
        }
        public IActionResult Index()
        {
            ViewBag.Scope = scope.GetId();
            ViewBag.Singleton = singleton.GetId();
            return View();
        }
    }
    public class ForSingleton
    {
        public int Id { get; set; }
        public int GetId() => ++Id;
    }
    public class ForSingletonInject
    {
        public int Id { get; set; }
        public int GetId() => ++Id;
    }
    public class ForScoped
    {
        public int Id { get; set; }
        public int GetId() => ++Id;
    }
}