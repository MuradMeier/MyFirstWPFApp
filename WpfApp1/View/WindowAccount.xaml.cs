using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
using WpfApp1.Helper;
using WpfApp1.Model;
using WpfApp1.ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для WindowAccount.xaml
    /// </summary>
    public partial class WindowAccount : Window
    {
        private AccountViewModel vmAccount = MainWindow.vmAccount;
        private BankViewModel vmBank;
        private TypeAccountViewModel vmTypeAccount;
        private AgreementViewModel vmAgreement;
        private ObservableCollection<AccountDPO> accountsDPO;
        private List<Bank> banks;
        private List<Agreement> agreements;
        private List<TypeAccount> typeAccounts;

        public WindowAccount()
        {
            InitializeComponent();
            vmAccount = new AccountViewModel();
            vmBank = new BankViewModel();
            vmAgreement = new AgreementViewModel();
            vmTypeAccount = new TypeAccountViewModel();
            banks = vmBank.ListBank.ToList();
            agreements = vmAgreement.ListAgreement.ToList();
            typeAccounts = vmTypeAccount.ListTypeAccount.ToList();

                
            accountsDPO = new ObservableCollection<AccountDPO>();
            foreach (var account in vmAccount.ListAccount)
            {
                AccountDPO a = new AccountDPO();
                a = a.CopyFromAccount(account);
                accountsDPO.Add(a);
            }
            lvAccount.ItemsSource = accountsDPO;
        }


        private void btn_Click(object sender, RoutedEventArgs e)
        {
            
        }

            private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewAccount wnAccount = new WindowNewAccount
            {
                Title = "Редактирование данных о счетах",
                Owner = this
            };

            AccountDPO accDPO = (AccountDPO)lvAccount.SelectedValue;
            AccountDPO tempAccDPO;
            if (accDPO != null)
            {
                tempAccDPO = accDPO.ShallowCopy();
                wnAccount.DataContext = tempAccDPO;
                wnAccount.CbBank.ItemsSource = banks;
                wnAccount.CbBank.Text = tempAccDPO.Bank;
                wnAccount.CbTypeAccount.ItemsSource = typeAccounts;
                wnAccount.CbTypeAccount.Text = tempAccDPO.type;
                wnAccount.CbAgreement.ItemsSource = agreements;
                wnAccount.CbAgreement.Text = tempAccDPO.Agreement;
                if (wnAccount.ShowDialog() == true)
                {
                    // перенос данных из временного класса в класс отображения данных 
                    Bank b = (Bank)wnAccount.CbBank.SelectedValue;
                    Agreement agr = (Agreement)wnAccount.CbAgreement.SelectedValue;
                    TypeAccount ta = (TypeAccount)wnAccount.CbTypeAccount.SelectedValue;
                    accDPO.Bank = b.NameShort;
                    accDPO.account = tempAccDPO.account;
                    accDPO.Agreement = agr.Number;
                    accDPO.type = ta.typeAccount;
                    lvAccount.ItemsSource = null;
                    lvAccount.ItemsSource = accountsDPO;

                    // перенос данных из класса отображения данных в класс Person
                    FindAccount finder = new FindAccount(accDPO.Id);
                    List<Account> listAccount = vmAccount.ListAccount.ToList();
                    Account a = listAccount.Find(new Predicate<Account>(finder.AccountPredicate));
                    a = a.CopyFromAccountDPO(accDPO);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать счёт для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
            private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewAccount wnAccount = new WindowNewAccount
            {
                Title = "Новый cчёт",
                Owner = this
            };
            // формирование кода нового счёта
            int maxIdAccount = vmAccount.MaxId() + 1;
            AccountDPO acc = new AccountDPO
            {
                Id = maxIdAccount,
            };
            wnAccount.DataContext = acc;
            wnAccount.CbBank.ItemsSource = banks;
            
            if (wnAccount.ShowDialog() == true)
            {
                Bank b = (Bank)wnAccount.CbBank.SelectedValue;
                Agreement agr = (Agreement)wnAccount.CbAgreement.SelectedValue;
                TypeAccount ta = (TypeAccount)wnAccount.CbTypeAccount.SelectedValue;

                acc.Bank = b.NameShort;
                acc.Agreement = agr.Number;
                acc.type = ta.typeAccount;
                accountsDPO.Add(acc);

                // добавление нового сотрудника в коллекцию ListPerson<Person> 
                Account a = new Account();
                a = a.CopyFromAccountDPO(acc);
                vmAccount.ListAccount.Add(a);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            AccountViewModel vmAccount = new AccountViewModel();
            Account account = (Account)lvAccount.SelectedItem;
            if (account != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по счёту: " +
                account.account, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmAccount.ListAccount.Remove(account);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать счёт для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
