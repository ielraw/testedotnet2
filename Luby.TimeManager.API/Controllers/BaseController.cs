using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace Luby.TimeManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class BaseController : ControllerBase
    {
        protected IConfiguration _configuracoes;
        protected readonly ILogger<Object> _logger;

        public BaseController(ILogger<Object> logger, IConfiguration config)
        {
            _logger = logger;
            _configuracoes = config;
        }

        protected string CurrentPath()
        {

            var path = HttpContext.Request.Scheme + "://" +
                    HttpContext.Request.Host +
                    HttpContext.Request.Path;
            return path;
        }

        protected string InsertedPath(Guid id)
        {

            var path = $"{CurrentPath()}/{id}";
            return path;
        }

        protected long CurrentClienteId
        {
            get
            {
                try
                {
                    var x = User.Identity;
                    var y = User.Claims.Where(x => x.Type == "ClienteId").FirstOrDefault()?.Value;

                    return Convert.ToInt64(y);
                }
                catch (Exception e)
                {
                    _logger.LogWarning(e, "O usuário logado não possui um cliente definido");
                    throw new Exception("O usuário logado não possui um cliente definido");
                }
            }
        }

        protected long CurrentColaboradorId
        {
            get {
                try
                {
                    var x = User.Identity;
                    var y = User.Claims.Where(x => x.Type == "ColaboradorId").FirstOrDefault()?.Value;

                    return Convert.ToInt64(y);
                }
                catch (Exception e)
                {
                    _logger.LogWarning(e, "O usuário logado não é um colaborador");
                    throw new Exception("O usuário logado não é um colaborador");
                }
            }
        }

    }
}
