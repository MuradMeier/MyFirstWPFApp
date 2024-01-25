using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.View;
using WpfApp1.ViewModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static AccountViewModel vmAccount;

        public MainWindow()
        {
            InitializeComponent();
        }
        public static int IdAccount { get; set; }
        private void Account_OnClick(object sender, RoutedEventArgs e)
        {
            WindowAccount wAccount = new WindowAccount();
            wAccount.Show();
        }
        private void Agreement_OnClick(object sender, RoutedEventArgs e)
        {
            WindowAgreement wAgreement = new WindowAgreement();
            wAgreement.Show();
        }
        private void Bank_OnClick(object sender, RoutedEventArgs e)
        {
            WindowBank wBank = new WindowBank();
            wBank.Show();
        }
        private void TypeAccount_OnClick(object sender, RoutedEventArgs e)
        {
            WindowTypeAccount wTypeAccount = new WindowTypeAccount();
            wTypeAccount.Show();
        }
    }
    }