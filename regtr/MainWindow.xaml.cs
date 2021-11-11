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

        //При нажатие проверяется данные для входа,если они правильные то подключаемся к личному кабинету
        private void Button_Click_Vhod(object sender, RoutedEventArgs e)
        {
            // инициал. переменных
            string log = LoginAuth.Text;
            string pass = PassAuth.Password;
            
            //Условие,если лоина логина и пароля больше 2 символов,идет подключение к базе
            if (log.Length > 2 && pass.Length > 3)
            {
                using (hachiuebani123 hachi = new hachiuebani123())
                    //Проверка на правильные данные пользователя
                {
                    //запрос где логин и пароль совпадают с данными в базе
                    var query = hachi.auth.Where(x => x.login == log 
                                                 && x.password == pass).FirstOrDefault();
                    //условие если запрос не пустой открывается личный кабинет
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
        //При нажатие на кнопку открывается окно регистрации
        private void Button_Click_Reg(object sender, RoutedEventArgs e)
        {
            Window2 reg = new Window2();
            this.Close();
            reg.Show();
        }
    }
}

















































//https://studbooks.net/1938603/informatika/proektirovanie_bazy_dannyh_subd_mysql