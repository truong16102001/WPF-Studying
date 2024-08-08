using MVVM.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MVVM.ViewModel
{
    public class UserViewModel
    {
        private IList<User> _UsersList;
        private User _SelectedUser;


        public UserViewModel()
        {
            _UsersList = new ObservableCollection<User>
        {
            new User { UserId = 1, FirstName = "Raj", LastName = "Beniwal", City = "Delhi", State = "DEL", Country = "INDIA" },
            new User { UserId = 2, FirstName = "Mark", LastName = "henry", City = "New York", State = "NY", Country = "USA" },
            new User { UserId = 3, FirstName = "Mahesh", LastName = "Chand", City = "Philadelphia", State = "PHL", Country = "USA" },
            new User { UserId = 4, FirstName = "Vikash", LastName = "Nanda", City = "Noida", State = "UP", Country = "INDIA" },
            new User { UserId = 5, FirstName = "Harsh", LastName = "Kumar", City = "Ghaziabad", State = "UP", Country = "INDIA" },
            new User { UserId = 6, FirstName = "Reetesh", LastName = "Tomar", City = "Mumbai", State = "MP", Country = "INDIA" },
            new User { UserId = 7, FirstName = "Deven", LastName = "Verma", City = "Palwal", State = "HP", Country = "INDIA" },
            new User { UserId = 8, FirstName = "Ravi", LastName = "Taneja", City = "Delhi", State = "DEL", Country = "INDIA" }
        };
            AddCommand = new RelayCommand(AddUser);
            UpdateCommand = new RelayCommand(UpdateUser);
            DeleteCommand = new RelayCommand(DeleteUser);
        }

        public IList<User> Users
        {
            get { return _UsersList; }
            set
            {
                _UsersList = value;
            }
        }

        public User SelectedUser
        {
            get { return _SelectedUser; }
            set
            {
                _SelectedUser = value;
            }
        }

        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

        private void AddUser(object parameter)
        {
            var newUser = parameter as User;
            if (newUser != null)
            {
                newUser.UserId = _UsersList.Count + 1; // simple auto-increment id
                _UsersList.Add(newUser);
            }
        }

        private void UpdateUser(object parameter)
        {
            var updatedUser = parameter as User;
            if (updatedUser != null)
            {
                var user = _UsersList.FirstOrDefault(u => u.UserId == updatedUser.UserId);
                if (user != null)
                {
                    user.FirstName = updatedUser.FirstName;
                    user.LastName = updatedUser.LastName;
                    user.City = updatedUser.City;
                    user.State = updatedUser.State;
                    user.Country = updatedUser.Country;
                }
            }
        }

        private void DeleteUser(object parameter)
        {
            var userId = (int)parameter;
            var user = _UsersList.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                _UsersList.Remove(user);
            }
        }

        public class RelayCommand : ICommand
        {
            private Action<object> execute;

            public RelayCommand(Action<object> executeAction)
            {
                execute = executeAction;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                execute(parameter);
            }
        }

       
    }
}