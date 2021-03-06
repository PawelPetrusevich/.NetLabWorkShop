﻿using System.Net;
using System.Web.Http;
using Rocket.BL.Common.Services;
using Swashbuckle.Swagger.Annotations;

namespace Rocket.Web.Controllers
{
    public class LoggerController : ApiController
    {
        private readonly ILogService _logService;

        public LoggerController(ILogService logService)
        {
            _logService = logService;
        }
    }
}
