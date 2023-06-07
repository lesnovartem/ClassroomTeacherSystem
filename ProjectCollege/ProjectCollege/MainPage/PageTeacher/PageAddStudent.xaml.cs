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
    /// Логика взаимодействия для PageAddStudent.xaml
    /// </summary>
    public partial class PageAddStudent : Page
    {
        public PageAddStudent()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txbName.Text.Length <= 0)
                    MessageBox.Show("Заполните поле");
                else
                {
                    Student student = new Student()
                    {
                        Name = txbName.Text,
                        About = txbAbout.Text
                    };
                    odbConnectApp.dbObj.Student.Add(student);
                    odbConnectApp.dbObj.SaveChanges();
                    MessageBox.Show("Студент добавлен!");
                    txbName.Text = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txbName.Text = null;
            txbAbout.Text = null;
        }
    }
}
