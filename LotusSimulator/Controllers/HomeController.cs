using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace LotusSimulator.Controllers
{
    public class HomeController : ApiController
    {
        public HomeController(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public IServiceProvider ServiceProvider { get; }

        public IHttpActionResult Index()
        {
            var gameContainer = ServiceProvider.GetService<GameContainer>();
            return Ok();
        }
    }
}
