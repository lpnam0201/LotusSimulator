using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Web.Http;

namespace LotusSimulator.Controllers
{
    public class HomeController : ControllerBase
    {
        public HomeController(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public IServiceProvider ServiceProvider { get; }

        
    }
}
