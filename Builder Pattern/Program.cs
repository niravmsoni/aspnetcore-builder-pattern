using System;
using System.Collections.Generic;
using Builder_Pattern.Builder;
using Builder_Pattern.Director;
using Builder_Pattern.Model;

namespace Builder_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new List<FurnitureItem>
            {
                new FurnitureItem("Sectional Couch", 55.5, 22.4, 78.6, 35.0),
                new FurnitureItem("Nightstand", 25.0, 12.4, 20.0, 10.0),
                new FurnitureItem("Dining Table", 105.0, 35.4, 100.6, 55.5),
            };

            var inventoryBuilder = new DailyReportBuilder(items);
            var director = new InventoryBuildDirector(inventoryBuilder);

            director.BuildCompleteReport();

            var directorReport = inventoryBuilder.Build();
            Console.WriteLine(directorReport.Debug());
        }
    }
}
