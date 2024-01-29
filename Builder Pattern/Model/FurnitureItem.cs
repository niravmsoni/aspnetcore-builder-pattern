namespace Builder_Pattern.Model
{
    public class FurnitureItem
    {
        public string Name;
        public double Price;
        public double Height;
        public double Width;
        public double Weight;

        public FurnitureItem(string productName, double price, double height, double width, double weight)
        {
            Name = productName;
            Price = price;
            Height = height;
            Width = width;
            Weight = weight;
        }
    }
}
