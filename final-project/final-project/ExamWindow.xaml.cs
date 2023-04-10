using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace final_project
{
    /// <summary>
    /// Interaction logic for ExamWindow.xaml
    /// </summary>
    public partial class ExamWindow : Window
    {
        Exam exam;
        User currentUser;
        ExamUser examUser;
        DispatcherTimer _timer;
        TimeSpan _time;
        int correctAnswerCountt = 0;
        public ExamWindow(Exam exam, User currentUser)
        {
            InitializeComponent();
            this.exam = exam;
            this.currentUser = currentUser;
            this.examUser = new ExamUser(exam, currentUser);

            // Set Timer
            _time = TimeSpan.FromSeconds(exam.Duration * 60);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                tbTime.Text = _time.ToString("c");
                if (_time == TimeSpan.Zero)
                {
                    _timer.Stop();
                    // navigate to exam choosing window
                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);
            _timer.Start();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // init the number of answered questions to 0 out of num of questions
            this.QuestionsNumberBox.Text = "0/" +
                this.exam.Questions.Count.ToString();

            // check if the exam is random and re-sort the questions
            if (this.exam.isRandom == true)
            {
                RandomSort(this.exam.Questions);
            }

            int j = 1;
            // add the questions to the questions listbox
            for (int i = 0; i < this.exam.Questions.Count; i++)
            {
                if (this.exam.Questions.ElementAt(i).answers.Count > 0)
                {
                    this.exam.Questions.ElementAt(i).questionId = j++;
                    this.ListBoxQuestions.Items.Add(this.exam.Questions.ElementAt(i));
                }
            }
        }

        static void RandomSort<T>(ICollection<T> collection)
        {
            Random random = new Random();
            List<T> list = collection.OrderBy(x => random.Next()).ToList();
            collection.Clear();
            foreach (T item in list)
            {
                collection.Add(item);
            }
        }

        private void ListBoxQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
             * Get the selected question from the ListBox and present it in
             * the quesion appearance part of the screen. If the question already
             * been answered restore the answer selected
             */
            int i = 0;
            this.QuestionContent.Children.Clear();
            this.OptionalAnswers.Children.Clear();

            if (this.ListBoxQuestions.SelectedItem is Question q)
            {
                if (q.imgName == string.Empty)
                {
                    TextBlock question = new TextBlock();
                    question.Text = q.content;
                    this.QuestionContent.Children.Add(question);
                }
                else
                {
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri(q.imgPath));
                    this.QuestionContent.Children.Add(img);
                }

                for (int j = 0; j < q.answers.Count; j++)
                {
                    Answer answer = q.answers.ElementAt(j);
                    RadioButton rb = new RadioButton();

                    rb.Content = answer.Content;

                    rb.Name = "Name" + (j.ToString());

                    rb.Checked += (sender, args) =>
                    {
                        q.chosenAnswer = rb.Name[rb.Name.Length - 1] - '0';
                        int newCount = this.exam.getSolvedQuestionsCount();
                        this.QuestionsNumberBox.Text = newCount.ToString() +
                        "/" + this.exam.Questions.Count.ToString();

                    };

                    rb.Unchecked += (sender, args) =>
                    {
                        q.chosenAnswer = -1;
                    };

                    rb.Tag = i++;

                    if (q.chosenAnswer == j)
                    {
                        rb.IsChecked = true;
                    }

                    else
                    {
                        rb.IsChecked = false;
                    }

                    OptionalAnswers.Children.Add(rb);

                }
            }
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

        private void exitBtnClick(object sender, RoutedEventArgs e)
        {
            /*
             * Exit button functionality: close the exam
             * (might be changed to Finish button)                         
             */
            if (this.exam.Questions.Count > 0)
            {
                foreach (Question question in this.ListBoxQuestions.Items)
                {
                    if (question.answers.ElementAt(question.chosenAnswer).CorrectAnswer == true)
                    {
                        this.correctAnswerCountt++;
                    }
                }
            }

            float pointsPerQuestion = 0;
            if (this.exam.Questions.Count != 0)
            {
                pointsPerQuestion = 100 / this.ListBoxQuestions.Items.Count;
            }

            int finalGrade = (int)Math.Ceiling(this.correctAnswerCountt * pointsPerQuestion);

            this.examUser.Grade = finalGrade;

            PostExamUser(this.examUser);

            this.Close();
        }

        private async void PostExamUser(ExamUser examUser)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7002/api/");

            // Serialize the object to JSON
            var json = JsonConvert.SerializeObject(examUser);

            // Create the request content
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, "endpoint");
            request.Content = content;

            // Send the POST request
            var response = await client.PostAsync("ExamUsers", content);
        }
    }
}
