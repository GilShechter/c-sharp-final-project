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
            string answerContent;

            int i = ListBoxQuestions.Items.Count;
            string name = "Question " + i.ToString();

            // update the questions count
            QuestionsNumberBox.Text = (i+1).ToString();

            // add a new question to the list
            ListBoxQuestions.Items.Add(name);

            /*
             * add all the fields to the last question in our questions list
             * and clear the answers list
             */
            string questionContent = ContentTxt.Text;
            
            // not finished! this window's functionallity still needs some work
            for(int j=0; j<this.OptionalAnswers.Children.Count; j++)
            {
                if(j%2 == 0) // the items in even places are the answer content
                {
                    answerContent = OptionalAnswers.Children[j].Text;
                }
            }


            // select the new question
            ListBoxQuestions.SelectedIndex = i+1;
        }

        private void AddAnswerBtn_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Button to add another Answer to the exam and show its empty field
             */
            TextBlock tb = new TextBlock();
            CheckBox cb = new CheckBox();
            int numOfQuestions = (OptionalAnswers.Children.Count / 2)+1;
            string name = "Answer"+numOfQuestions.ToString();

            tb.Margin=new Thickness(10);
            tb.HorizontalAlignment = HorizontalAlignment.Left;
            tb.Width = 400;
            tb.Name = name;

            cb.Content = "Mark as correct answer";
            cb.Margin = new Thickness(0, 0, 0, 10);
            cb.Name = name+"CheckBox";

            OptionalAnswers.Children.Add(tb);
            OptionalAnswers.Children.Add(cb);
        }

        private void AddQuestionImage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
