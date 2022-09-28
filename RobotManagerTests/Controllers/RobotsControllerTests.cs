using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotManager.Models;
using System;

namespace RobotManager.Controllers.Tests
{
    [TestClass]
    public class RobotsControllerTests
    {
        [TestMethod]
        public async Task FindClosestTestAsync()
        {
            var testLoad = new Load(0, 0);
            var controller = new RobotsController(null);
            var result1 = await controller.FindClosest(testLoad);
            // The expected result is {"robotId":4,"batteryLevel":37,"x":2,"y":7}
            double distance = Math.Sqrt(2 * 2 + 7 * 7);
            var result2 = new ClosestRobot(4, distance, 37);
            
            Assert.IsTrue(result1.Equals(result2));
        }
    }
}