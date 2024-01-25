using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    class AccountViewModel
    {
        public ObservableCollection<Account> ListAccount { get; set; } = new ObservableCollection<Account>();
        public AccountViewModel()
        {
            this.ListAccount.Add(
            new Account
            {
                Id = 1,
                TypeId = 1,
                BankId = 1,
                AgreementId = 1,
                account = "3546"
            });
            this.ListAccount.Add(
            new Account
            {
                Id = 2,
                TypeId = 3,
                BankId = 2,
                AgreementId = 2,
                account = "3557"

            });
            this.ListAccount.Add(
            new Account
            {
                Id = 3,
                TypeId = 2,
                BankId = 3,
                AgreementId = 3,
                account = "7293"
            });
        }
        public int MaxId()
        {
            int max = 0;
            foreach (var a in this.ListAccount)
            {
                if (max < a.Id)
                {
                    max = a.Id;
                };
            }
            return max;
        }
    }
}