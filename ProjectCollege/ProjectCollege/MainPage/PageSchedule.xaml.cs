using Microsoft.Win32;
using ProjectCollege.odbConnectHelper;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для PageSchedule.xaml
    /// </summary>
    public partial class PageSchedule : Page
    {
        int day;
        public PageSchedule()
        {
            InitializeComponent();
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            day = (int)dt.DayOfWeek;
            setDay();
        }
        public void setDay()
        {
            var bc = new BrushConverter();
            if (day == 1 )
            {
                Monday.Background = (Brush)bc.ConvertFrom("#FF085A3A");
            }
            if (day == 2)
            {
                Tuesday.Background = (Brush)bc.ConvertFrom("#FF085A3A");
            }
            if (day == 3)
            {
                Wednesday.Background = (Brush)bc.ConvertFrom("#FF085A3A");
            }
            if (day == 4)
            {
                Thursday.Background = (Brush)bc.ConvertFrom("#FF085A3A");
            }
            if (day == 5)
            {
                Friday.Background = (Brush)bc.ConvertFrom("#FF085A3A");
            }
            if (day == 6 || day == 7)
            {
                SaturdaySunday.Background = (Brush)bc.ConvertFrom("#FF085A3A");
            }
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Выберите картинку";
            op.Filter = "jpg|*.jpg| jpeg|*.jpeg| bmp|*.bmp| png|*.png";
            if (op.ShowDialog() == true)
            {
                odbConnectHelper.Image image = new odbConnectHelper.Image()
                {
                    Image1 = File.ReadAllBytes(op.FileName)
                };
                odbConnectApp.dbObj.Image.Add(image);
                odbConnectApp.dbObj.SaveChanges();
                MessageBox.Show("Сохранено!");
            }
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            PageImage imageP = new PageImage(odbConnectApp.dbObj.Image.OrderByDescending(x => x.Id).First());
            imageP.Show();
        }
    }
}
