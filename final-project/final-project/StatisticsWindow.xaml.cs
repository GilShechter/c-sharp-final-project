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
    /// Interaction logic for StatisticsWindow.xaml
    /// </summary>
    public partial class StatisticsWindow : Window
    {
        Exam exam;
        List<int> grades = new List<int>();
        public StatisticsWindow(Exam exam)
        {
            InitializeComponent();
            this.exam = exam;

            // feel the listbox with the students done the exam
            foreach (User user in this.exam.students)
            {
                if (user.isTeacher == false)
                {
                    studentsListBox.Items.Add(user);
                }
            }

            // calculate the average, find the highest and lowest grades
            grades = this.exam.grades.Values.ToList();

            int highestGrade = 0;
            int lowestGrade = 100;
            float averageGrade = 0;

            for(int i=0;i<grades.Count;i++)
            {
                averageGrade += grades[i];

                if (grades[i] > highestGrade)
                {
                    averageGrade = grades[i];
                }
                
                if (grades[i] < lowestGrade)
                {
                    lowestGrade = grades[i];
                }
            }

            averageGrade = averageGrade/grades.Count;

            // set the TextBlocks to show the information
            highestGradeTB.Text = highestGrade.ToString();
            lowestGradeTB.Text = lowestGrade.ToString();
            averageGradeTB.Text = averageGrade.ToString();
            numberOfStudentsTB.Text = this.studentsListBox.Items.Count.ToString();
        }
        private void studentsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.studentsListBox.SelectedIndex == -1)
            {
                return;
            }

            // get the student instance to find his grade in the grades dictionary
            if (this.studentsListBox.SelectedItem is User)
            {
                /* we are getting the grade by the dictionary and not by the index to prevent
                 * an occasion where one of the users in the exam was a teacher
                 */
                User student = this.studentsListBox.SelectedItem;
                int studentGrade = this.exam.grades[student];
                selectedStudentGradeTB.Text = studentGrade.ToString();
            }

        }
        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
