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
        private void Button_Click_Vhod(object sender, RoutedEventArgs e)
        {
            string log = jopa.Text;
            string pass = pas.Password;

            if (log.Length > 2 && pass.Length > 3)
            {
                using (hachiuebani123 hachi = new hachiuebani123())
                {
                    var query = hachi.auth.Where(x => x.login == log && x.password == pass).FirstOrDefault();

                    if (query != null)
                    {
                        MessageBox.Show("Вы успешно зашли!");
                        Window3 profile = new Window3();
                        this.Close();
                        profile.Show();
                    }
                }
            }
            else
            {
                MessageBox.Show("Не правильно введен логин или пароль");

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window2 reg = new Window2();
            this.Close();
            reg.Show();
        }
    }
}


        

           
                
                


