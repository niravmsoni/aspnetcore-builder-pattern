using System.Text;

namespace Builder_Pattern
{
    /// <summary>
    /// Complex object we would build with builder method. 
    /// No constructor since we would be setting up values one by one
    /// Feed list of items in inventory report class
    /// </summary>
    public class InventoryReport
    {
        public string TitleSection;
        public string DimensionsSection;
        public string LogisticsSection;

        /// <summary>
        /// Help with output
        /// </summary>
        /// <returns></returns>
        public string Debug()
        {
            return new StringBuilder()
                .AppendLine(TitleSection)
                .AppendLine(DimensionsSection)
                .AppendLine(LogisticsSection)
                .ToString();
        }
    }
}
