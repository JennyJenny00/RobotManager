using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RobotManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobotManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RobotsController : ControllerBase
    {
        private readonly ILogger<RobotsController> _logger;

        public RobotsController(ILogger<RobotsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("welcome")]
        public String GetClosest()
        {
            return "Welcome!";
        }

        [HttpPost("closest")]
        public ClosestRobot FindClosest(Load load)
        {
            var closestRobot = new ClosestRobot
            {
                robotId = load.loadId,
                distanceToGoal = 2.3F,
                batteryLevel = load.x * 100 + load.y,
            };
            return closestRobot;
        }
    }
}
