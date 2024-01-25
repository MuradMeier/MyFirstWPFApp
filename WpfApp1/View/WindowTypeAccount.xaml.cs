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
using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для WindowTypeAccount.xaml
    /// </summary>
    public partial class WindowTypeAccount : Window
    {
        TypeAccountViewModel vmTypeAccount = new TypeAccountViewModel();
        public WindowTypeAccount()
        {
            InitializeComponent();
            vmTypeAccount = new TypeAccountViewModel();
            lvTypeAccount.ItemsSource = vmTypeAccount.ListTypeAccount;
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            TypeAccountViewModel vmTypeAccount = new TypeAccountViewModel();
            WindowNewTypeAccount wnTypeAccount = new WindowNewTypeAccount
            {
                Title = "Редактирование данных о типах счетов",
                Owner = this
            };
            TypeAccount typeAccount = lvTypeAccount.SelectedItem as TypeAccount;
            if (typeAccount != null)
            {
                TypeAccount tempTypeAccount = typeAccount.ShallowCopy();
                wnTypeAccount.DataContext = tempTypeAccount;
                if (wnTypeAccount.ShowDialog() == true)
                {
                    // сохранение данных
                    typeAccount.typeAccount = tempTypeAccount.typeAccount;
                    lvTypeAccount.ItemsSource = null;
                    lvTypeAccount.ItemsSource = vmTypeAccount.ListTypeAccount;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать тип счёта для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            TypeAccountViewModel vmTypeAccount = new TypeAccountViewModel();
            TypeAccount typeAccount = (TypeAccount)lvTypeAccount.SelectedItem;
            if (typeAccount != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить тип счёта: " +
                typeAccount.typeAccount, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmTypeAccount.ListTypeAccount.Remove(typeAccount);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать счёт для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowTypeAccount wnTypeAccount = new WindowTypeAccount
            {
                Title = "Новая должность",
                Owner = this
            };
            // формирование кода новой должности
            int maxIdTypeAccount = vmTypeAccount.MaxId() + 1;
            TypeAccount typeAccount = new TypeAccount
            {
                Id = maxIdTypeAccount
            };
            wnTypeAccount.DataContext = typeAccount;
            if (wnTypeAccount.ShowDialog() == true)
            {
                vmTypeAccount.ListTypeAccount.Add(typeAccount);
            }
        }
    }

}
