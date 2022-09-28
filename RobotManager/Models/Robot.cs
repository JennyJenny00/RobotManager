using System;

namespace RobotManager.Models
{
    public class Robot
    {
        public Robot(int robotId, int batteryLevel, int x, int y)
        {
            this.robotId = robotId;
            this.batteryLevel = batteryLevel;
            this.x = x;
            this.y = y;
        }

        public int robotId { get; set; }

        public int batteryLevel { get; set; }

        public int x { get; set; }

        public int y { get; set; }
    }
}
