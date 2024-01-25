using System;
using System.Collections.Generic;
using System.Data;
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
using WpfApp1.View;

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для WindowBank.xaml
    /// </summary>
    public partial class WindowBank : Window
    {
        public WindowBank()
        {
            InitializeComponent();
            BankViewModel vmBank = new BankViewModel();
            lvBank.ItemsSource = vmBank.ListBank;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            BankViewModel vmBank = new BankViewModel();
            WindowNewBank wnBank = new WindowNewBank
            {
                Title = "Данные о новом банке",
                Owner = this
            };
            // формирование кода нового банка
            int maxIdBank = vmBank.MaxId() + 1;
            Bank bank = new Bank
            {
                Id = maxIdBank
            };
            wnBank.DataContext = bank;
            if (wnBank.ShowDialog() == true)
            {
                vmBank.ListBank.Add(bank);
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            BankViewModel vmBank = new BankViewModel();
            WindowNewBank wnBank = new WindowNewBank
            {
                Title = "Редактирование должности",
                Owner = this
            };
            Bank bank = lvBank.SelectedItem as Bank;
            if (bank != null)
            {
                Bank tempBank = bank.ShallowCopy();
                wnBank.DataContext = tempBank;
            if (wnBank.ShowDialog() == true)
                {
                    // сохранение данных
                    bank.NameFull = tempBank.NameFull;
                    bank.NameShort = tempBank.NameShort;
                    bank.Bik = tempBank.Bik;
                    bank.Inn = tempBank.Inn;
                    bank.Account = tempBank.Account;
                    bank.KorAccount = tempBank.KorAccount;
                    bank.City = tempBank.City;
                    lvBank.ItemsSource = null;
                    lvBank.ItemsSource = vmBank.ListBank;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать банк для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            BankViewModel vmBank = new BankViewModel();
            Bank bank = (Bank)lvBank.SelectedItem;
            if (bank != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по банку: " +
                bank.NameShort, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmBank.ListBank.Remove(bank);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать банк для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
