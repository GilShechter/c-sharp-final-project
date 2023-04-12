using Newtonsoft.Json;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;

namespace final_project
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void UsernameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private async void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password.ToString();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please insert username and password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync($"https://localhost:7002/api/Users/{username}");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    User current = JsonConvert.DeserializeObject<User>(json);
                    if (current != null)
                    {
                        if (current.Password == password)
                        {
                            MainWindow main = new MainWindow(current);
                            main.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("User not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }
    }
}
