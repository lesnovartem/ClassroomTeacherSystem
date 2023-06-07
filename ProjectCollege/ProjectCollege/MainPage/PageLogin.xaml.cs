using ProjectCollege.MainPage.PageStudent;
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

namespace ProjectCollege.MainPage
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }
        async void Login()
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).Load();
            await Task.Run(() =>
            {
                odbConnectApp.dbObj.Student.ToList();
            });
            Autorization();
            ((MainWindow)System.Windows.Application.Current.MainWindow).CloseLoad();
        }
        public void Autorization()
        {
            var userObj = odbConnectApp.dbObj.User.FirstOrDefault(x => x.Password
            == txbPassword.Text && x.Login == txbLogin.Text);
            if (userObj != null)
            {
                switch (userObj.IdRole)
                {
                    case 1:
                        FrameApp.frmObj.Navigate(new PageMenuTeather());
                        break;
                    case 2:
                        FrameApp.frmObj.Navigate(new PageMenuStudent());
                        break;
                }
            }
            else
                MessageBox.Show("Пользоватеь не найден");
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login();
            }
        }
    }
}
