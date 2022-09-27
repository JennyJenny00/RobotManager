using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RobotManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RobotManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RobotsController : ControllerBase
    {
        private readonly ILogger<RobotsController> _logger;
        private static HttpClient client = new HttpClient();
        private static String requestUrl = "https://60c8ed887dafc90017ffbd56.mockapi.io/robots";
        private static double tolerance = 1e-6;

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
        public async Task<ClosestRobot> FindClosest(Load load)
        {
            var robots = await GetRobots();

            int robotId = -1;
            double minimumDistance = double.MaxValue;
            int maximumBatteryLevel = 0;
            foreach (var robot in robots)
            {
                var distance = GetDistance(robot, load);
                if (distance < minimumDistance)
                {
                    minimumDistance = distance;
                    maximumBatteryLevel = robot.batteryLevel;
                    robotId = robot.robotId;
                }
                else if (Math.Abs(distance - minimumDistance) < tolerance && maximumBatteryLevel < robot.batteryLevel)
                {
                    maximumBatteryLevel = robot.batteryLevel;
                    robotId = robot.robotId;
                }
            }

            var closestRobot = new ClosestRobot
            {
                robotId = robotId,
                distanceToGoal = minimumDistance,
                batteryLevel = maximumBatteryLevel,
            };
            return closestRobot;
        }

        private static async Task<IEnumerable<Robot>> GetRobots()
        {
            IEnumerable<Robot> robots = null;
            HttpResponseMessage response = await client.GetAsync(requestUrl);
            if (response.IsSuccessStatusCode)
            {
                robots = await response.Content.ReadAsAsync<IEnumerable<Robot>>();
            }
            return robots;
        }

        private static double GetDistance(Robot robot, Load load)
        {
            var xDiff = robot.x - load.x;
            var yDiff = robot.y - load.y;
            var distance = Math.Sqrt(xDiff * yDiff + yDiff * xDiff);
            return distance;
        }
    }
}
