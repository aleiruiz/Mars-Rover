
namespace Challenge1.Models
{
    /// <summary>
    /// Object in charge of rendering a X and Y boundaries inside a cardinal map.
    /// It can not render boundaries below the 0 position.
    /// </summary>
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
