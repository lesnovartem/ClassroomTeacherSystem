using ProjectCollege.MainPage.PageTeacher;
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
using System.Windows.Threading;

namespace ProjectCollege.MainPage.PageStudent
{
    /// <summary>
    /// Логика взаимодействия для PageMenuStudent.xaml
    /// </summary>
    public partial class PageMenuStudent : Page
    {
        DispatcherTimer timer;
        double panelWidth;
        bool hidden;

        public PageMenuStudent()
        {
            InitializeComponent();
            FrameSecApp.frmObj = FrameSecond;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Tick += Timer_Tick;

            panelWidth = sidePanel.Width;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (hidden)
            {
                test.Width = new GridLength(0.190, GridUnitType.Star);
                sidePanel.Width += 2;
                if (sidePanel.Width >= panelWidth)
                {
                    timer.Stop();
                    hidden = false;
                }
            }
            else
            {
                sidePanel.Width -= 2;
                if (sidePanel.Width <= 40)
                {
                    test.Width = new GridLength(0.055, GridUnitType.Star);
                    timer.Stop();
                    hidden = true;
                }
            }
        }
        private void Schedule_Selected(object sender, RoutedEventArgs e)
        {
            FrameSecApp.frmObj.Navigate(new PageSchedule());
        }

        private void Exit_Selected(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageLogin());
        }

        private void Omissions_Selected(object sender, RoutedEventArgs e)
        {
            FrameSecApp.frmObj.Navigate(new AddOmissions());
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            FrameSecApp.frmObj.Navigate(new PageListStudent());
        }
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }
    }
}
