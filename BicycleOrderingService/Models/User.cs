namespace BicycleOrderingService.Models
{
    public class User
    {
        public string Login
        {
            get => _login;
            set => _login = value;
        }

        private string _login;

        public  string Password
        {
            get => _password;
            set => _password = value;
        }

        private string _password;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private string _name;

        public string Surname
        {
            get => _surname;
            set => _surname = value;
        }

        private string _surname;
    }
}
