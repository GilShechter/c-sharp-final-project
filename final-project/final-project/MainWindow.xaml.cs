using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace final_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User currentUser;
        List<Exam> examsList;
        public MainWindow(User currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            hello_msg.Text = $"Hello, {currentUser.Name}";
            if (!currentUser.isTeacher)
            {
                Add_Exam_Button.Visibility = Visibility.Hidden;
                View_Exam_Button.Visibility = Visibility.Hidden;
            }
            else
            {
                Start_Exam_Button.Visibility = Visibility.Hidden;
            }
            examsList = new List<Exam>();
            GetExams("");
        }

        private void Add_Exam_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void GetExams(string keyWord)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:7002/api/Exam");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    examsList = JsonConvert.DeserializeObject<List<Exam>>(json);
                    examsList = examsList.Where(exam => exam.Name.ToLower().Contains(keyWord.ToLower())).ToList<Exam>();
                    foreach (Exam item in examsList)
                    {
                        this.ExamsList.Items.Add(item);
                    }
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyWord = this.Search_bar.Text;
            this.ExamsList.Items.Clear();
            GetExams(keyWord);
        }

        private void Start_Exam_Button_Click(object sender, RoutedEventArgs e)
        {
            ExamWindow examWindow = new ExamWindow();
            examWindow.Show();
        }

        private void View_Exam_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
