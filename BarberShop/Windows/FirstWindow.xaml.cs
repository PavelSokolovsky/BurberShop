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
    /// Логика взаимодействия для FirstWindow.xaml
    /// </summary>
    public partial class FirstWindow : Window
    {
        

        public FirstWindow()
        {
            InitializeComponent();
            BarberList.ItemsSource = Helpers.AuthorizationHelper.barberDb.BarberTb.ToList();
        }

        public void UpdateBarbers()
        {
            var currentBurber = Helpers.AuthorizationHelper.barberDb.BarberTb.Where(p => p.role == FiltrTb.Text || p.name == FiltrTb.Text).ToList();
            BarberList.ItemsSource = currentBurber;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Helpers.AuthorizationHelper.authorizationwindow.Show();
            this.Close();
        }

        private void EditBB_Click(object sender, RoutedEventArgs e)
        {
            int num = Convert.ToInt32(BarberIdTb.Text);
            var uRow = Helpers.AuthorizationHelper.barberDb.BarberTb.Where(w => w.IDBarber == num).FirstOrDefault();
            uRow.IDBarber = num;
            uRow.name = BarberNameTb.Text;
            uRow.role = BarberRoleTb.Text;
            Helpers.AuthorizationHelper.barberDb.SaveChanges();
            BarberList.ItemsSource = Helpers.AuthorizationHelper.barberDb.BarberTb.ToList();
        }

        private void InsertBB_Click(object sender, RoutedEventArgs e)
        {
            BarberTb barberTb = new BarberTb();
            int num = Convert.ToInt32(BarberIdTb.Text);
            
            barberTb.IDBarber = num;
            barberTb.name = BarberNameTb.Text;
            barberTb.role = BarberRoleTb.Text;
            Helpers.AuthorizationHelper.barberDb.BarberTb.Add(barberTb);
            Helpers.AuthorizationHelper.barberDb.SaveChanges();
            BarberList.ItemsSource = Helpers.AuthorizationHelper.barberDb.BarberTb.ToList();
        }

        private void DeleteBB_Click(object sender, RoutedEventArgs e)
        {
            int num = Convert.ToInt32(BarberIdTb.Text);
            var dRow = Helpers.AuthorizationHelper.barberDb.BarberTb.Where(w => w.IDBarber == num).FirstOrDefault();
            Helpers.AuthorizationHelper.barberDb.BarberTb.Remove(dRow);
            Helpers.AuthorizationHelper.barberDb.SaveChanges();
            BarberList.ItemsSource = Helpers.AuthorizationHelper.barberDb.BarberTb.ToList();
        }

        private void NextWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Helpers.AuthorizationHelper.secondWindow.Show();
            
        }

        private void FiltrTb_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (FiltrTb.Text.Length > 0)
            {

                UpdateBarbers();
            }

            else BarberList.ItemsSource = Helpers.AuthorizationHelper.barberDb.BarberTb.ToList();

        }
    }
}
