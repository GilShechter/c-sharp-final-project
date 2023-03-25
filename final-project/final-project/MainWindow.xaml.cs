using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
        Exam selectedExam;
        HttpClient client = new HttpClient();
        public MainWindow(User currentUser)
        {
            InitializeComponent();
            client.BaseAddress = new Uri("https://localhost:7002/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            this.currentUser = currentUser;
            hello_msg.Text = $"Hello, {currentUser.Name}";
            if (!currentUser.IsTeacher)
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
            List<Question> questions = new List<Question>();

            // Testing hardcoding

            Answer answer1 = new Answer("Yes", true);
            Answer answer2 = new Answer("No", false);
            List<Answer> answers = new List<Answer>();
            answers.Add(answer1);
            answers.Add(answer2);
            Question question1 = new Question("Is this a test?", answers);
            Question question2 = new Question("Are you okay?", answers);
            Question question3 = new Question("Are you a human?", answers);
            questions.Add(question1);
            questions.Add(question2);
            questions.Add(question3);
            User teacher = new User("Test2", "222", "test2", true);
            Exam new_exam = new Exam("Test2", DateTime.Now, teacher, 90, false, questions);

            // Serialize the object to JSON
            var json = JsonConvert.SerializeObject(new_exam);

            // Create the request content
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, "endpoint");
            request.Content = content;

            // Send the POST request
            var response1 = await client.PostAsync("Exam", content);

            // Handle the response
            if (response1.IsSuccessStatusCode)
            {
                // The request was successful
            }
            else
            {
                // The request failed
                var errorMessage = await response1.Content.ReadAsStringAsync();
                MessageBox.Show(errorMessage);
                // Handle the error message
            }

            var response = await client.GetStringAsync("Exam");
            examsList = JsonConvert.DeserializeObject<List<Exam>>(response);
            examsList = examsList.Where(exam => exam.Name.ToLower().Contains(keyWord.ToLower())).ToList<Exam>();
            foreach (Exam item in examsList)
            {
                this.ExamsList.Items.Add(item);
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
            ExamWindow examWindow = new ExamWindow(this.selectedExam);
            examWindow.Show();
        }

        private void View_Exam_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExamsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (currentUser.IsTeacher)
            {
                View_Exam_Button.IsEnabled = true;
            }
            else
            {
                Start_Exam_Button.IsEnabled = true;
            }
            this.selectedExam = (Exam)ExamsList.SelectedItem;
        }
    }
}
