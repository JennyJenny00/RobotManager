namespace RobotManager.Models
{
    public class ClosestRobot
    {
        public int robotId { get; set; }

        public float distanceToGoal { get; set; }

        public int batteryLevel { get; set; }
    }
}
