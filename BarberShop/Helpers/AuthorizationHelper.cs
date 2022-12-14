using BarberShop.Models;
using BarberShop.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Helpers
{
    internal class AuthorizationHelper
    {
        public static BarberBDEntities barberDb = new BarberBDEntities();
        public static FirstWindow firstWindow = new FirstWindow();
        public static Authorizationwindow authorizationwindow = new Authorizationwindow();
        public static SecondWindow secondWindow = new SecondWindow();
    }
}
