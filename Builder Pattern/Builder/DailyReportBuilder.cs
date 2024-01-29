using System;
using System.Collections.Generic;
using System.Linq;
using Builder_Pattern.Model;

namespace Builder_Pattern.Builder
{
    /// <summary>
    /// Concrete builder that builds an object of InventoryReport.
    /// </summary>
    public class DailyReportBuilder : IFurnitureInventoryBuilder
    {
        private readonly InventoryReport _report;
        private IEnumerable<FurnitureItem> _items;

        public DailyReportBuilder(IEnumerable<FurnitureItem> items)
        {
            _report = new InventoryReport();
            _items = items;
        }
        public void AddDimensions()
        {
            _report.DimensionsSection = string.Join(Environment.NewLine, _items.Select(product =>
                            $"Product: {product.Name} \nPrice: {product.Price} \n" +
                            $"Height: {product.Height} x Width: {product.Width} -> Weight: {product.Weight} lbs \n"));
        }

        public void AddLogistics(DateTime dateTime)
        {
            _report.LogisticsSection = $"Report generated on {dateTime}";
        }

        public void AddTitle()
        {
            _report.TitleSection = "-------Daily Inventory Report-------\n\n";
        }

        public InventoryReport Build()
        {
            return _report;
        }
    }
}
