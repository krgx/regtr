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

namespace regtr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
           
        {
            InitializeComponent();
            


        }
        // при нажатии кнопки регистрации открывается окно регистрации
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            Window2 window2 = new Window2();
            window.Close();
            window2.Show();

            //try
            //{
            //    hachiuebani123Entities1 entities1 = new hachiuebani123Entities1();

            //    var query = entities1.Avtobus.Select(x => x.Количество_мест);
            //    foreach (var item in query)
            //    {
            //        MessageBox.Show(item.ToString());
            //    }

            //    MessageBox.Show("База работает");

            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("База не работает");
            //    throw;
            //}
        }
        private void Button_Click_2(object sender,RoutedEventArgs e)
        {
            Window3 window3 = new Window3();
            window3.Show();
        }
    }
}


