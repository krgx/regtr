using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace regtr
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        //При нажатие на кнопку идет создание нового пользователя
        private void Button_Click_Register(object sender, RoutedEventArgs e)
        {

            {
                Window2 reg = new Window2();
                this.Close();
                reg.Show();
                //Ввод логи на и пароля для нового пользователя 
                string loginReg = RegLog.Text.Trim();
                string passReg = RegPass.Password;
                string passReg2 = RegPassR.Password;
                if (loginReg.Length > 2 && passReg.Length > 5 && passReg2.Length > 5)

                {
                    if (!Regex.IsMatch(loginReg.ToLower(), "[йцукенгшщзхъфывапролджэячсмитьбю.\\||//ъх!@#$%^&*()_+=-Ё~`:;\"\'<>,-@№{}[]"))
                    {

                        //условие,если пароль и подтв пароля совпадают
                        if (passReg == passReg2)
                        //Используем базу данных для занесения пользователя в базу
                        {
                            using (hachiuebani123 hachi = new hachiuebani123())
                            {
                                //запрос к базе
                                var query = hachi.auth.Where(x => x.login.Equals(loginReg)).FirstOrDefault();
                                // если такого лоигна нет,то он вносится в базу
                                if (query == null)
                                //Добавление нового пользователя 
                                {
                                    hachi.auth.Add(new auth()
                                    {
                                        login = loginReg,
                                        password = passReg,
                                    }
                                    );
                                    //сохранение изменений
                                    hachi.SaveChanges();
                                    MessageBox.Show("Поздравляем!Вы успешно зарегестрировались!");
                                    MainWindow Main = new MainWindow();
                                    this.Close();
                                    Main.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Такой логин уже существует");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пароли не совпадают");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Недопустимые символы");
                    }
                }
                else
                {
                    MessageBox.Show("Пароль меньше 6 символов");
                }

            }

        }

        private void Button_Click_Help(object sender, RoutedEventArgs e)
        {
            Window2 reg = new Window2();
            MessageBox.Show("Разрешенные символы для регистрации:Английский алфавит,Цифры от 0 до 9!");
            this.Close();
            reg.Show();
        }


        
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show(); 
        }
    }
}



