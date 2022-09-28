namespace RobotManager.Models
{
    public class Load
    {
        public int loadId { get; set; }

        public int x { get; set; }

        public int y { get; set; }

        public Load(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
