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

namespace ProjectCollege.MainPage.PageStudent
{
    /// <summary>
    /// Логика взаимодействия для PageListStudent.xaml
    /// </summary>
    public partial class PageListStudent : Page
    {
        public PageListStudent()
        {
            InitializeComponent();
            List.ItemsSource = odbConnectApp.dbObj.Student.ToList();
        }
    }
}
