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

namespace EkzZachet.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddExecutor.xaml
    /// </summary>
    public partial class AddExecutor : Page
    {
        private Task _currentTask = new Task();
        public AddExecutor(Task selectedTask)
        {
            InitializeComponent();

            if (selectedTask != null)
                _currentTask = selectedTask;

            DataContext = _currentTask;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentTask.ID == 0)
                EkzEntities.GetContext().Task.Add(_currentTask);
            try
            {
                EkzEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager1.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager1.MainFrame.GoBack();
        }
    }
}
