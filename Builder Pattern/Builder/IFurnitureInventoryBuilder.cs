using System;

namespace Builder_Pattern.Builder
{
    /// <summary>
    /// Builder interface. 
    /// Should be general enough to apply to all different kinds of concrete builder class that might implement it in future
    /// </summary>
    public interface IFurnitureInventoryBuilder
    {
        void AddTitle();

        void AddDimensions();

        void AddLogistics(DateTime dateTime);

        InventoryReport Build();
    }
}
