using BarberShop.Models;
using System;
using System.Collections;
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
    /// Логика взаимодействия для SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();
            ItemsList.ItemsSource = Helpers.AuthorizationHelper.barberDb.ItemsTb.ToList();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            int num1 = Convert.ToInt32(ItemIdTb.Text);
            ItemsTb itemsTb = new ItemsTb();
            itemsTb.iditem = num1;
            itemsTb.name = ItemNameTb.Text;
            itemsTb.amount = ItemAmountTb.Text;
            itemsTb.Date = (DateTime)ItemDt.SelectedDate;
            Helpers.AuthorizationHelper.barberDb.ItemsTb.Add(itemsTb);
            Helpers.AuthorizationHelper.barberDb.SaveChanges();
            ItemsList.ItemsSource = Helpers.AuthorizationHelper.barberDb.ItemsTb.ToList();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            int num = Convert.ToInt32(ItemIdTb.Text);
            var uRow = Helpers.AuthorizationHelper.barberDb.ItemsTb.Where(w => w.iditem == num).FirstOrDefault();
            uRow.iditem = num;
            uRow.name = ItemNameTb.Text;
            uRow.amount = ItemAmountTb.Text;
            uRow.Date = (DateTime)ItemDt.SelectedDate;
            Helpers.AuthorizationHelper.barberDb.SaveChanges();
            ItemsList.ItemsSource = Helpers.AuthorizationHelper.barberDb.ItemsTb.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int num2 = Convert.ToInt32(ItemIdTb.Text);
            var dRow = Helpers.AuthorizationHelper.barberDb.ItemsTb.Where(w => w.iditem == num2).FirstOrDefault();
            Helpers.AuthorizationHelper.barberDb.ItemsTb.Remove(dRow);
            Helpers.AuthorizationHelper.barberDb.SaveChanges();
            ItemsList.ItemsSource = Helpers.AuthorizationHelper.barberDb.ItemsTb.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Helpers.AuthorizationHelper.firstWindow.Show();
            
        }
    }
}
