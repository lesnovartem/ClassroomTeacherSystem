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
    /// Логика взаимодействия для PageEditStudent.xaml
    /// </summary>
    public partial class PageEditStudent : Page
    {
        Student _student;
        public PageEditStudent(Student student)
        {
            InitializeComponent();
            _student = student;
            DataContext= _student;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            FrameSecApp.frmObj.Navigate(new ListStudent());
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            odbConnectApp.dbObj.SaveChanges();
            MessageBox.Show("Сохранено!");
            FrameSecApp.frmObj.Navigate(new ListStudent());
        }
    }
}
