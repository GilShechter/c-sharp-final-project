using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for EditExamWindow.xaml
    /// </summary>
    public partial class EditExamWindow : Window
    {
        private Exam exam;
        private List<Question> _questions;
        private List<Answer> _answers;
        HttpClient client = new HttpClient();

        public EditExamWindow(Exam exam)
        {
            InitializeComponent();
            client.BaseAddress = new Uri("https://localhost:7002/api/");
            this.exam = exam;
            this._questions = new List<Question>();
            this._answers = new List<Answer>();

            foreach (Question question in this.exam.Questions)
            {
                if (question.answers.Count > 0)
                {
                    this._questions.Add(question);
                    ListBoxQuestions.Items.Add((Question)question);
                }
                
            }

            // update the count of the questions in the exam
            QuestionsNumberBox.Text = (ListBoxQuestions.Items.Count).ToString();
        }

        private async void addExamBtn_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Button to add the exam we just created into the exams list
             * and exit this window
             */

            // delete all empty questions
            List<Question> tmp = new List<Question>();
            foreach (Question question in this._questions)
            {
                if (question.content != string.Empty)
                {
                    tmp.Add(question);
                }
            }
            this._questions = tmp;
            this.exam.Questions = this._questions;

            // Serialize the object to JSON
            var json = JsonConvert.SerializeObject(exam);

            // Create the request content
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, "endpoint");
            request.Content = content;

            /*            // Send the DELETE request
                        var response = await client.DeleteAsync($"Exam/{exam.ExamId}");

                        // Send the POST request
                        response = await client.PostAsync("Exam", content);*/

            // Send the PUT requese
            var response = await client.PutAsync($"Exam/{exam.ExamId}", content);

            if (!response.IsSuccessStatusCode)
            {
                // The request failed
                var errorMessage = await response.Content.ReadAsStringAsync();
                MessageBox.Show(errorMessage);
                // Handle the error message
            }

            this.Close();
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Next button functionality: go to the next question.
             * If no question selected do nothing
             */

            int selectedIndex = this.ListBoxQuestions.SelectedIndex;
            if (selectedIndex == -1) { return; }
            if (selectedIndex != this.ListBoxQuestions.Items.Count)
            {
                this.ListBoxQuestions.SelectedIndex = selectedIndex + 1;
            }
        }

        private void PrevBtn_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Previous button functionality: go to the prev question.
             * If no question selected do nothing
             */

            int selectedIndex = this.ListBoxQuestions.SelectedIndex;
            if (selectedIndex == -1) { return; }
            if (selectedIndex != 0)
            {
                this.ListBoxQuestions.SelectedIndex = selectedIndex - 1;
            }
        }

        private void AddQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Button to add another question to the exam and show its empty fields.
             */

            // Add an empty question
            int i = ListBoxQuestions.Items.Count;

            Question question = new Question("", this._answers);
            question.questionId = ListBoxQuestions.Items.Count + 1;
            this._questions.Add(question);

            ListBoxQuestions.Items.Add((Question)question);

            // update the questions count
            QuestionsNumberBox.Text = (i + 1).ToString();

            // select the new question
            ListBoxQuestions.SelectedIndex = i;
        }

        private void AddAnswerBtn_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Button to add another Answer to the exam and show its empty field
             */

            if (ListBoxQuestions.SelectedIndex == -1)
            {
                return;
            }

            TextBox tb = new TextBox();
            CheckBox cb = new CheckBox();
            int numOfQuestions = (OptionalAnswers.Children.Count / 2) + 1;
            string name = "Answer" + numOfQuestions.ToString();

            tb.Margin = new Thickness(10);
            tb.HorizontalAlignment = HorizontalAlignment.Left;
            tb.Width = 400;
            tb.Background = Brushes.LightGray;
            tb.Name = name;

            cb.Content = "Mark as correct answer";
            cb.Margin = new Thickness(0, 0, 0, 10);
            cb.Name = name + "CheckBox";

            OptionalAnswers.Children.Add(tb);
            OptionalAnswers.Children.Add(cb);
        }

        private void AddQuestionImage_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Add the question content as image instead of text
             */
            if (this.ListBoxQuestions.Items.Count == 0) { return; }

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "C:\\";

            int index = this.ListBoxQuestions.SelectedIndex;
            Question question = this._questions[index];

            if (dialog.ShowDialog() == true)
            {
                string name = dialog.FileName;
                string fileName = System.IO.Path.GetFileName(name);
                string location = Environment.CurrentDirectory + fileName;
                ContentTxt.Text = name;
                File.Copy(name, location, true);

                question.imgName = fileName;
                question.imgPath = location;
                question.content = string.Empty;
                Image img = new Image();
                img.Source = new BitmapImage(new Uri(question.imgPath));

                QuestionContent.Children.Add(img);
            }
        }

        private void ListBoxQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
             * Set the fields of the selected question to match
             * the data inserted             
             */

            if (ListBoxQuestions.SelectedIndex == -1) { return; }

            // clear the question and answers fields
            OptionalAnswers.Children.Clear();
            ContentTxt.Clear();
            for (int i = 0; i < QuestionContent.Children.Count; i++)
            {
                if (QuestionContent.Children[i] is Image)
                {
                    QuestionContent.Children.RemoveAt(i);
                }
            }

            // get the currently selected index
            int index = ListBoxQuestions.SelectedIndex;

            if (this._questions[index].imgName != string.Empty)
            {
                if (this._questions[index].answers.Count() >= 2)
                {
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri(this._questions[index].imgPath));

                    ContentTxt.Text = this._questions[index].imgPath;
                    QuestionContent.Children.Add(img);
                }
            }
            else
            {
                ContentTxt.Text = this._questions[index].content;
            }


            CheckBox cb;
            TextBox tb;

            foreach (Answer answer in this._questions[index].answers)
            {
                tb = new TextBox();
                cb = new CheckBox();

                tb.Margin = new Thickness(10);
                tb.HorizontalAlignment = HorizontalAlignment.Left;
                tb.Width = 400;
                tb.Background = Brushes.LightGray;

                cb.Content = "Mark as correct answer";
                cb.Margin = new Thickness(0, 0, 0, 10);

                tb.Text = answer.Content;
                if (answer.CorrectAnswer)
                {
                    cb.IsChecked = true;
                }
                else
                {
                    cb.IsChecked = false;
                }

                OptionalAnswers.Children.Add(tb);
                OptionalAnswers.Children.Add(cb);
            }
        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Button to confirm the question's fields modifications
             */
            int index = ListBoxQuestions.SelectedIndex;
            Answer answer;

            for (int j = 0; j < this.OptionalAnswers.Children.Count; j++)
            {
                answer = new Answer(string.Empty, false);

                if (OptionalAnswers.Children[j] is TextBox)
                {
                    TextBox tb = (TextBox)OptionalAnswers.Children[j];
                    if (tb != null)
                    {
                        answer.Content = tb.Text;
                    }
                }

                else if (OptionalAnswers.Children[j] is CheckBox)
                {
                    CheckBox cb = (CheckBox)OptionalAnswers.Children[j];
                    int cbIndex = j / 2;

                    if (cb.IsChecked == true)
                    {
                        this._answers[cbIndex].CorrectAnswer = true;
                    }

                    else
                    {
                        this._answers[cbIndex].CorrectAnswer = false;
                    }

                }

                if (answer.Content != string.Empty)
                {
                    this._answers.Add(answer);
                }
            }

            // if there is no question content or at least 2 answers dont update
            if (ContentTxt.Text == string.Empty || this._answers.Count < 2)
            {
                this._answers.Clear();
                return;
            }

            // check if there are no correct answers
            bool correct_answer_found = false;

            foreach (Answer ans in this._answers)
            {
                if (ans.CorrectAnswer == true)
                {
                    correct_answer_found = true;
                    break;
                }
            }
            if (correct_answer_found == false)
            {
                this._answers.Clear();
                return;
            }

            // update the data
            if (this._questions[index].imgName == string.Empty)
            {
                this._questions[index].content = ContentTxt.Text;
            }
            else
            {
                this._questions[index].content = this._questions[index].imgName;
            }

            this._questions[index].answers = this._answers.ToArray();
            this._answers.Clear();
        }
    }
}
