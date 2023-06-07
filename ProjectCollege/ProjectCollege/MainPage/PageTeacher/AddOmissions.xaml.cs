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
    /// Логика взаимодействия для AddOmissions.xaml
    /// </summary>
    public partial class AddOmissions : Page
    {
        public AddOmissions()
        {
            InitializeComponent();
            StudentName.SelectedValuePath = "Id";
            StudentName.DisplayMemberPath = "Name";
            StudentName.ItemsSource = odbConnectApp.dbObj.Student.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Sum.Text.Length > 0)
            {
                if (StudentName != null)
                {
                    if (Date.SelectedDate != null)
                    {
                        Test omis = new Test()
                        {
                            IdStudent = (StudentName.SelectedItem as Student).Id,
                            date = Convert.ToDateTime(Date.SelectedDate),
                            num = Convert.ToInt16(Sum.Text)
                        };
                        odbConnectApp.dbObj.Test.Add(omis);
                        odbConnectApp.dbObj.SaveChanges();
                        MessageBox.Show("Пропуск добавлен!");
                        ClearTxb();
                    }
                    else
                        MessageBox.Show("Выберите дату");
                }
                else
                    MessageBox.Show("Выберите студента");
            }
            else
                MessageBox.Show("Выберите пару");
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearTxb();
        }

        public void ClearTxb()
        {
            Sum.Text = null;
            StudentName.SelectedItem = null;
            Date.SelectedDate = null;
        }
    }
}
