using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1
{
    class AccountDPO
    {
        public int Id { get; set; }
        public string Bank { get; set; }
        public string Agreement { get; set; }
        public string type { get; set; }
        public string account { get; set; }
        public AccountDPO() { }
        public AccountDPO(int id, string bank, string agreement, string tp, string acc)
        {
            this.Id = id;
            this.Bank = bank;
            this.Agreement = agreement;
            this.type = tp;
            this.account = acc;
        }
        public AccountDPO ShallowCopy()
        {
            return (AccountDPO)this.MemberwiseClone();
        }
        public AccountDPO CopyFromAccount(Account account)
        {
            AccountDPO accDPO = new AccountDPO();

            BankViewModel vmBank = new BankViewModel();
            string bank = string.Empty;
            foreach (var b in vmBank.ListBank)
            {
                if (b.Id == account.BankId)
                {
                    bank = b.NameShort;
                    break;
                }
            }

            AgreementViewModel vmAgreement = new AgreementViewModel();
            string agreement = string.Empty;
            foreach (var agr in vmAgreement.ListAgreement)
            {
                if (agr.Id == account.BankId)
                {
                    agreement = agr.Number;
                    break;
                }
            }

            TypeAccountViewModel vmTypeAccount = new TypeAccountViewModel();
            string typeAccount = string.Empty;
            foreach (var ta in vmTypeAccount.ListTypeAccount)
            {
                if (ta.Id == account.TypeId)
                {
                    typeAccount = ta.typeAccount;
                    break;
                }
            }

            if (bank != string.Empty & agreement != string.Empty & typeAccount != string.Empty)
            {
                accDPO.Id = account.Id;
                accDPO.Bank = bank;
                accDPO.account = account.account;
                accDPO.Agreement = agreement;
                accDPO.type = typeAccount;
            }
            return accDPO;
        }

    }

}
