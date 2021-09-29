namespace BicycleOrderingService.Models
{
    public class ProductModel
    {
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        private int _id;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private string _name;

        public string Cost
        {
            get => _cost;
            set => _cost = value;
        }

        private string _cost;
    }
}
