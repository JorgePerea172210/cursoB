using apiProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        private IRandomService _RandomServiceSingleton;
        private IRandomService _RandomServiceScoped;
        private IRandomService _RandomServiceTransient;

        private IRandomService _RandomService2Singleton;
        private IRandomService _RandomService2Scoped;
        private IRandomService _RandomService2Transient;

        public RandomController(
            [FromKeyedServices("randomSingleton")] IRandomService randomServiceSingleton,
            [FromKeyedServices("randomScoped")] IRandomService randomServiceScoped,
            [FromKeyedServices("randomTransient")] IRandomService randomServiceTransient,
            [FromKeyedServices("randomSingleton")] IRandomService randomService2Singleton,
            [FromKeyedServices("randomScoped")] IRandomService randomService2Scoped,
            [FromKeyedServices("randomTransient")] IRandomService randomService2Transient)
        {
            _RandomServiceSingleton = randomServiceSingleton;
            _RandomServiceScoped = randomServiceScoped;
            _RandomServiceTransient = randomServiceTransient;
            _RandomService2Singleton = randomService2Singleton;
            _RandomService2Scoped = randomService2Scoped;
            _RandomService2Transient = randomService2Transient;
        }

        [HttpGet]
        public ActionResult<Dictionary<string, int>> Get()
        {
            var result = new Dictionary<string, int>();

            result.Add("Singleton 1", _RandomServiceSingleton.Value);
            result.Add("Scoped 1", _RandomServiceScoped.Value);
            result.Add("Transient 1", _RandomServiceTransient.Value);
            result.Add("Singleton 2", _RandomService2Singleton.Value);
            result.Add("Scoped 2", _RandomService2Scoped.Value);
            result.Add("Transient 2", _RandomService2Transient.Value);

            return result;
        }
    }
}
