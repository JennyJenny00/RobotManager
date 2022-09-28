namespace RobotManager.Models
{
    public class ClosestRobot
    {
        public int robotId { get; set; }

        public double distanceToGoal { get; set; }

        public int batteryLevel { get; set; }

        public ClosestRobot(int robotId, double distanceToGoal, int batteryLevel)
        {
            this.robotId = robotId;
            this.distanceToGoal = distanceToGoal;
            this.batteryLevel = batteryLevel;
        }

        public bool Equals(ClosestRobot other)
        {
            if (this.batteryLevel != other.batteryLevel) return false;
            if (this.robotId != other.robotId) return false;
            if (this.distanceToGoal != other.distanceToGoal) return false;
            return true;
        }
    }
}
