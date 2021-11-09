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
                //Ввод логина и пароля для нового пользователя 
                string loginReg = log1.Text.Trim();
                string passReg = passs1.Password;
                string passReg2 = passs2.Password;
                //string str = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
                //if (str.Contains("абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"))
                //    MessageBox.Show("Строка содержит кириллицу");
                //else
                //    MessageBox.Show("Все работает");

                if (loginReg.Length > 2 && passReg.Length > 3 && passReg2.Length > 3)
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
                    MessageBox.Show("Логин или пароль введены не правильно");
                }
            }

        }
    }
}
        
    

