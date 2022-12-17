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
    /// Логика взаимодействия для ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        public ManagerPage()
        {
            InitializeComponent();
            DGridExecutor.ItemsSource = EkzEntities.GetContext().Task.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Manager.MainFrame.Navigate(new AddEditPageE(null));
            MessageBox.Show("В данный момент вы не можете добавить данные. " +
                "Данная функция находится в разработке!");
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var taskForRemoving = DGridExecutor.SelectedItems.Cast<Task>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {taskForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    EkzEntities.GetContext().Task.RemoveRange(taskForRemoving);
                    EkzEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridExecutor.ItemsSource = EkzEntities.GetContext().Task.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager1.MainFrame.GoBack();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager1.MainFrame.Navigate(new AddManager((sender as Button).DataContext as Task));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            EkzEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DGridExecutor.ItemsSource = EkzEntities.GetContext().Task.ToList();
        }
    }
}
