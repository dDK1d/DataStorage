using System.Collections.ObjectModel;

namespace DataStorage
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<User> users = new ObservableCollection<User>();

        public MainPage()
        {
            InitializeComponent();
            userListView.ItemsSource = users;
        }

        private async void btn_AddUser_Clicked(object sender, EventArgs e)
        {
            var addUserPage = new AddUserPage(users);
            await Navigation.PushAsync(addUserPage);
        }

        private async void lv_UserSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var user = (User)e.SelectedItem;
                await Navigation.PushAsync(new UserData(user));
                userListView.SelectedItem = null;
            }
        }

        private void btn_DeleteUser_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var userToDelete = button.CommandParameter as User;
            if (userToDelete != null && users.Contains(userToDelete))
            {
                users.Remove(userToDelete);
            }
        }
    }

}

