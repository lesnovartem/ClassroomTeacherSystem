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
using System.Windows.Shapes;

namespace ProjectCollege.MainPage
{
    /// <summary>
    /// Логика взаимодействия для PageImage.xaml
    /// </summary>
    public partial class PageImage : Window
    {
        public PageImage(odbConnectHelper.Image image)
        {
            InitializeComponent();
            DataContext = image;
        }
    }
}
