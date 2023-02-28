using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Threading;

namespace final_project
{
    /// <summary>
    /// Interaction logic for ExamWindow.xaml
    /// </summary>
    public partial class ExamWindow : Window
    {
        Exam exam;
        DispatcherTimer _timer;
        TimeSpan _time;
        public ExamWindow()
        {
            InitializeComponent();
            List<Question> questions = new List<Question>();

            // Testing hardcoding

            Answer answer1 = new Answer("Yes");
            Answer answer2 = new Answer("No");
            Answer[] answers = { answer1, answer2 };
            Question question1 = new Question("Is this a test?", answers);
            Question question2 = new Question("Are you okay?", answers);
            Question question3 = new Question("Are you a human?", answers);
            questions.Add(question1);
            questions.Add(question2);
            questions.Add(question3);
            Teacher teacher = new Teacher("Test", "test");

            this.exam = new Exam("Test", DateTime.Now, teacher, 90, false, questions);

            // Testing finished

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
                this.exam.questions.Count.ToString();

            // add the questions to the questions listbox
            for (int i = 0; i < this.exam.questions.Count; i++)
            {
                this.exam.questions[i].Id = i + 1;
                this.ListBoxQuestions.Items.Add(exam.questions[i]);
            }

        }

        private void ListBoxQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = 0;
            this.QuestionContent.Children.Clear();
            this.OptionalAnswers.Children.Clear();

            if (this.ListBoxQuestions.SelectedItem is Question q)
            {
                if (q.imgName == "")
                {
                    TextBlock question = new TextBlock();
                    question.Text = q.content;
                    this.QuestionContent.Children.Add(question);
                }
                else
                {
                    Image img = new Image();
                    string location = q.imgPath + "/" + q.imgName;
                    img.Source = new BitmapImage(new Uri(location));
                    this.QuestionContent.Children.Add(img);
                }

                for (int j = 0; j < q.answers.Length; j++)
                {
                    Answer answer = q.answers[j];
                    RadioButton rb = new RadioButton()
                    {
                        Content = answer.content,
                    };

                    rb.Name = "Name" + (j.ToString());

                    rb.Checked += (sender, args) =>
                    {
                        q.chosenAnswer = rb.Name[rb.Name.Length - 1] - '0';
                        int newCount = this.exam.getSolvedQuestionsCount();
                        this.QuestionsNumberBox.Text = newCount.ToString() +
                        "/" + this.exam.questions.Count.ToString();

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
            int selectedIndex = this.ListBoxQuestions.SelectedIndex;
            if (selectedIndex != this.exam.questions.Count)
            {
                this.ListBoxQuestions.SelectedIndex = selectedIndex + 1;
            }
        }

        private void PrevBtn_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = this.ListBoxQuestions.SelectedIndex;
            if (selectedIndex != 0)
            {
                this.ListBoxQuestions.SelectedIndex = selectedIndex - 1;
            }
        }
    }
}
