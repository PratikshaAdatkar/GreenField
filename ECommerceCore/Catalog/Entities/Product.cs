namespace Catalog.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string image { get; set; }

        public override string ToString()
        {
            return Id + " " + Name + " " + Description;
        }
    }
}
