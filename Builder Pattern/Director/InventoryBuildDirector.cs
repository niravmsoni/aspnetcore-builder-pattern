using Builder_Pattern.Builder;
using System;

namespace Builder_Pattern.Director
{
    /// <summary>
    /// Act as director class that orchaestrates building of Inventory builder
    /// </summary>
    public class InventoryBuildDirector
    {
        private IFurnitureInventoryBuilder _builder;

        public InventoryBuildDirector(IFurnitureInventoryBuilder builder)
        {
            _builder = builder;
        }

        public void BuildCompleteReport()
        {
            _builder.AddTitle();
            _builder.AddDimensions();
            _builder.AddLogistics(DateTime.Now);
        }
    }
}
