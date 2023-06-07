using LiveCharts;
using LiveCharts.Wpf;
using ProjectCollege.odbConnectHelper;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectCollege.MainPage.PageTeacher
{
    /// <summary>
    /// Логика взаимодействия для PageStudentEvaluations.xaml
    /// </summary>
    public partial class PageStudentEvaluations : Page
    {
        Student _student;

        SeriesCollection series = new SeriesCollection();
        ChartValues<int> testint = new ChartValues<int>();
        List<string> dates = new List<string>();

        public PageStudentEvaluations(Student student)
        {
            InitializeComponent();
            StudentName.Text = student.Name;
            cmbLesson.SelectedValuePath = "Id";
            cmbLesson.DisplayMemberPath = "Name";
            cmbLesson.ItemsSource = odbConnectApp.dbObj.Lesson.ToList();
            _student = student;
            DataContext = student;
            Propusk.LegendLocation = LegendLocation.Bottom;
            foreach (var testObj in odbConnectApp.dbObj.Test.Where(x => x.IdStudent == _student.Id))
            {
                testint.Add(Convert.ToInt32(testObj.num));
                dates.Add(testObj.date.ToShortDateString());
            }
            Propusk.AxisX.Clear();
            Propusk.AxisX.Add(new Axis()
            {
                Title = "Даты",
                Labels = dates
            });
            LineSeries dateLine = new LineSeries();
            dateLine.Title = "Пропуски";
            dateLine.Values = testint;
            series.Add(dateLine);
            Propusk.Series = series;

        }

        public void avgMark()
        {
            int idLesson = (cmbLesson.SelectedItem as Lesson).Id;
            double Count = odbConnectApp.dbObj.Journal.Count(x => x.IdStudent == _student.Id && x.IdLesson == idLesson);
            double Sum = 0;
            foreach (var SotrudGroup in odbConnectApp.dbObj.Journal.Where(x => x.IdStudent == _student.Id && x.IdLesson == idLesson))
            {
                Sum += SotrudGroup.Evaluation;
            }
            avg.Text = Convert.ToString(Sum / Count);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            FrameSecApp.frmObj.Navigate(new ListStudent());
        }

        private void cmbLesson_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idLesson = (cmbLesson.SelectedItem as Lesson).Id;
            Test.Text = null;
            foreach (var SotrudGroup in odbConnectApp.dbObj.Journal.Where(x => x.IdStudent == _student.Id && x.IdLesson == idLesson))
            {
                Test.Text += string.Format("{0} ", SotrudGroup.Evaluation);
            }
            avgMark();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Test2.Text.Length != 0)
            {
                int idLesson = (cmbLesson.SelectedItem as Lesson).Id;
                Journal journal = new Journal()
                {
                    IdLesson = idLesson,
                    IdStudent = _student.Id,
                    Evaluation = Convert.ToInt32(Test2.Text)
                };
                odbConnectApp.dbObj.Journal.Add(journal);
                odbConnectApp.dbObj.SaveChanges();
                MessageBox.Show("Оценка добавлена");
                Test.Text += string.Format(Test2.Text+", ");
                avgMark();
            }
            else
                MessageBox.Show("Заполните все поля");
        }
    }
}
