using System;

namespace BicycleOrderingService.Models
{
    public class OrderModel
    {
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        private int _id;

        public int IdUser
        {
            get => _idUser;
            set => _idUser = value;
        }

        private int _idUser;

        public int IdProduct
        {
            get => _idProduct;
            set => _idProduct = value;
        }

        private int _idProduct;

        public DateTime Date
        {
            get => _date;
            set => _date = value;
        }

        private DateTime _date;

        public int Hours
        {
            get => _hours;
            set => _hours = value;
        }

        private int _hours;

        public string Minutes
        {
            get => _minutes;
            set => _minutes = value;
        }

        private string _minutes;
    }
}
