using System;

namespace Builder_Pattern.Builder
{
    /// <summary>
    /// Another concrete builder for Furniture inventory builder
    /// </summary>
    internal class WeeklyReportBuilder : IFurnitureInventoryBuilder
    {
        public IFurnitureInventoryBuilder AddDimensions()
        {
            throw new NotImplementedException();
        }

        public IFurnitureInventoryBuilder AddLogistics(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public IFurnitureInventoryBuilder AddTitle()
        {
            throw new NotImplementedException();
        }

        public InventoryReport Build()
        {
            throw new NotImplementedException();
        }
    }
}
