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
using ProjectCollege.MainPage;

namespace ProjectCollege
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameApp.frmObj = Frame;
            FrameApp.frmObj.Navigate(new PageLogin());
            odbConnectApp.dbObj = new DBCollegeEntities();
        }
        public void Load()
        {
            Loading.Visibility = Visibility.Visible;
            BackgroundLoading.Visibility = Visibility.Visible;
        }
        public void CloseLoad()
        {
            Loading.Visibility = Visibility.Collapsed;
            BackgroundLoading.Visibility = Visibility.Collapsed;
        }
    }
}
