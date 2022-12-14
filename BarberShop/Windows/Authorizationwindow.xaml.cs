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

namespace BarberShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для Authorizationwindow.xaml
    /// </summary>
    public partial class Authorizationwindow : Window
    {
        public Authorizationwindow()
        {
            InitializeComponent();
        }

        private void AuthorizationBtn_Click(object sender, RoutedEventArgs e)
        {
            try

            {
                var user = Helpers.AuthorizationHelper.barberDb.UsersTb.FirstOrDefault(x=> x.name == LoginTb.Text && x.password  ==  PassBx.Password);
                if (user != null)
                {
                    MessageBox.Show("добро пожаловать" + user.name + "!");
                    Helpers.AuthorizationHelper.firstWindow.Show();
                    this.Close();
                    
                }
                else

                    MessageBox.Show("пользователь не найден", "ошибка при авторизаци", MessageBoxButton.OK, MessageBoxImage.Error);

}
            catch (Exception ex)
            {
                MessageBox.Show("ошибка" + ex.Message.ToString() + "critical work", "notification", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    }
 }


