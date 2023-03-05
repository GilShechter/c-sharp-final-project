using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace final_project
{
    /// <summary>
    /// Interaction logic for AddExamWindow.xaml
    /// </summary>
    public partial class AddExamWindow : Window
    {
        private List<Question> _questions;
        private List<Answer> _answers;
        public AddExamWindow()
        {
            InitializeComponent();
            this._questions = new List<Question>();
            this._answers = new List<Answer>();
        }

        private void addExamBtn_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Button to add the exam we just created into the exams list
             * and exit this window
             */
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
            Answer answer;

            int i = ListBoxQuestions.Items.Count;
            string name = "Question " + i.ToString();            

            /*
             * add all the fields to the last question in our questions list
             * and clear the answers list
             */
            
            string questionContent = ContentTxt.Text;
            
            for(int j=0; j<this.OptionalAnswers.Children.Count; j++)
            {
                answer = new Answer(string.Empty);

                if (OptionalAnswers.Children[j] is TextBox)
                {
                    TextBox tb = (TextBox)OptionalAnswers.Children[j];
                    if (tb != null)
                    {
                        answer.content = tb.Text;
                    }
                }

                else if (OptionalAnswers.Children[j] is CheckBox)
                {
                    CheckBox cb = (CheckBox)OptionalAnswers.Children[j];
                    
                    // NOTICE: for some reason the answer,correct answer setter
                    // doesn't work this way altough the checkboxes responsivety
                    // works good.
                    // TODO: find out why and solve it
                    if (cb.IsChecked == true)
                    {
                        answer.correct_answer = true;                    
                    }

                    else
                    {
                        answer.correct_answer = false;                        
                    }

                }

                if (answer.content != string.Empty)
                {
                    this._answers.Add(answer);
                }
            }
            if (ContentTxt.Text != string.Empty && this._answers.Count>=2
                || ListBoxQuestions.Items.Count == 0)
            {
                Question question = new Question(questionContent, this._answers.ToArray());
                question.Id = ListBoxQuestions.Items.Count + 1;
                this._questions.Add(question);

                ListBoxQuestions.Items.Add((Question)question);
                this._answers.Clear();

                // update the questions count
                QuestionsNumberBox.Text = (i + 1).ToString();
            }

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
            int numOfQuestions = (OptionalAnswers.Children.Count / 2)+1;
            string name = "Answer"+numOfQuestions.ToString();

            tb.Margin=new Thickness(10);
            tb.HorizontalAlignment = HorizontalAlignment.Left;
            tb.Width = 400;
            tb.Background = Brushes.LightGray;
            tb.Name = name;

            cb.Content = "Mark as correct answer";
            cb.Margin = new Thickness(0, 0, 0, 10);
            cb.Name = name+"CheckBox";

            OptionalAnswers.Children.Add(tb);
            OptionalAnswers.Children.Add(cb);
        }

        private void AddQuestionImage_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Add the question content as image instead of text
             * TODO: fix the image to show up in the QuestionContent StakPanel
             */

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "C:\\";

            if (dialog.ShowDialog() == true)
            {
                int index = this.ListBoxQuestions.SelectedIndex;
                Question question = this._questions[index];
                //Image img = new Image();
                //QuestionContent.Children.Add(img);

                string name = dialog.FileName;
                string fileName = System.IO.Path.GetFileName(name);
                string location = Environment.CurrentDirectory;
                ContentTxt.Text = name;
                //File.Copy(name, location, true);

                question.imgName = fileName;
                question.imgPath = location;
                //img.Source = new BitmapImage(new Uri(question.imgPath.ToString()));
            }
        }

        private void ListBoxQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
             * Set the fields of the selected question to match
             * the data inserted
             * TODO: fix the functionality to show the right data
             */

            // clear the question and answers fields
            OptionalAnswers.Children.Clear();
            ContentTxt.Clear();

            // get the currently selected index
            int index = ListBoxQuestions.SelectedIndex;           

            if(this._questions.Count != index+1) { return; }
            ContentTxt.Text = this._questions[index].content;


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

                tb.Text = answer.content;
                if (answer.correct_answer)
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
    }
}
