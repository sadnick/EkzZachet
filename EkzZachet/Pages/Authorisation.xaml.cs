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
using System.Windows.Threading;

namespace EkzZachet.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorisation.xaml
    /// </summary>
    public partial class Authorisation : Page
    {
        public Authorisation()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, (object s, EventArgs ev) =>
            {
                this.myDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }, this.Dispatcher);
            timer.Start();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Manager1.MainFrame.Navigate(new ExecutorPage());
        }

        private void btnManager_Click(object sender, RoutedEventArgs e)
        {
            Manager1.MainFrame.Navigate(new ManagerPage());
        }
    }
}
