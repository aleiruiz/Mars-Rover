
namespace Challenge1.Models
{
    public class Plateau
    {
        /// <summary>
        /// X Corner
        /// </summary>
        public int xAxis { get; set; }

        /// <summary>
        /// Y Corner
        /// </summary>
        public int yAxis { get; set; }

        public Plateau(int xAxis, int yAxis)
        {
            this.xAxis = xAxis;
            this.yAxis = yAxis;
        }
    }
}
