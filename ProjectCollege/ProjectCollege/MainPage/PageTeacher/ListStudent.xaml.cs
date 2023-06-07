using ProjectCollege.odbConnectHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using static System.Net.Mime.MediaTypeNames;

namespace ProjectCollege.MainPage.PageTeacher
{
    /// <summary>
    /// Логика взаимодействия для ListStudent.xaml
    /// </summary>
    public partial class ListStudent : Page
    {
        
        public ListStudent()
        {
            InitializeComponent();
            loadList();
        }
        async void loadList()
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).Load();
            await Task.Run(() => {
                odbConnectApp.dbObj.Student.ToList();
            });
            test();
            ((MainWindow)System.Windows.Application.Current.MainWindow).CloseLoad();
        }
        public void test()
        {
            List.ItemsSource = odbConnectApp.dbObj.Student.ToList();
        }
        private void List_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FrameSecApp.frmObj.Navigate(new PageStudentEvaluations(List.SelectedItem as Student));
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            test();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            FrameSecApp.frmObj.Navigate(new PageEditStudent((sender as Button).DataContext as Student));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
                try
                {
                    if (MessageBox.Show($"Вы точно ходите удалить {((sender as Button).DataContext as Student).Name} ?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        odbConnectApp.dbObj.Student.Remove((sender as Button).DataContext as Student);
                        odbConnectApp.dbObj.SaveChanges();
                        MessageBox.Show("Удалено");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());

                }
            loadList();
        }
    }
}
