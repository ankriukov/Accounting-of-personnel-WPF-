using Catalog.Model;
using Catalog.Resources;
using Catalog.ViewModel;
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

namespace Catalog
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new AppViewModel();
            this.Icon = MyResource.icon.ToBitmapImage();

            Point location = AppConfiguration.GetStartUpPosition(this.Height, this.Width);
            this.Top = location.Y;
            this.Left = location.X;
        }

        
    }
}
