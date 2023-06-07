using LiveCharts.Wpf;
using LiveCharts;
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
    /// Логика взаимодействия для PageOmissions.xaml
    /// </summary>
    public partial class PageOmissions : Page
    {
        SeriesCollection series = new SeriesCollection();
        ChartValues<int> testint = new ChartValues<int>();
        List<string> dates = new List<string>();
        public PageOmissions()
        {
            InitializeComponent();
            loadList();
            Test.LegendLocation = LegendLocation.Bottom;
        }
        async void loadList()
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).Load();
            await Task.Run(() => {
                
                
                foreach (var testObj in odbConnectApp.dbObj.Test)
                {
                    testint.Add(Convert.ToInt32(testObj.num));
                    dates.Add(testObj.date.ToShortDateString());
                }
                
            });
            test(testint);
            ((MainWindow)System.Windows.Application.Current.MainWindow).CloseLoad();
        }
        public void test(ChartValues<int> testint)
        {
            Test.AxisX.Clear();
            Test.AxisX.Add(new Axis()
            {
                Title = "Даты",
                Labels = dates
            });
            LineSeries dateLine = new LineSeries();
            dateLine.Title = "Пропуски";
            dateLine.Values = testint;
            series.Add(dateLine);
            Test.Series = series;
        }
    }
}
