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

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            {
                Window2 reg = new Window2();
                this.Close();
                reg.Show();
                string loginReg = log1.Text.Trim();
                string passReg = passs1.Password;
                string passReg2 = passs2.Password;
                if (loginReg.Length > 2 && passReg.Length > 3 && passReg2.Length > 3)
                {
                    if (passReg == passReg2)
                    {
                        using (hachiuebani123 hachi = new hachiuebani123())
                        {
                            var query = hachi.auth.Where(x => x.login.Equals(loginReg)).FirstOrDefault();

                            if (query == null)
                            {
                                hachi.auth.Add(new auth()
                                {
                                    login = loginReg,
                                    password = passReg,
                                }
                                );
                                hachi.SaveChanges();
                                MessageBox.Show("Работает");
                                MainWindow Main = new MainWindow();
                                this.Close();
                                Main.Show();
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
        
    

