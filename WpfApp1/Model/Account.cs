using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModel;

namespace WpfApp1.Model
{
    class Account
    {
        public int Id { get; set; }
        public int BankId { get; set; }
        public int AgreementId { get; set; }
        public int TypeId { get; set; }
        public string account { get; set; }
        public Account() { }
        public Account(int id, int bankId, int agreementId, int typeId, string acc)
        {
            this.Id = id;
            this.BankId = bankId;
            this.AgreementId = agreementId;
            this.TypeId = typeId;
            this.account = acc;
        }
        public Account ShallowCopy()
        {
            return (Account)this.MemberwiseClone();
        }
        public Account CopyFromAccountDPO(AccountDPO a)
        {
            BankViewModel vmBank = new BankViewModel();
            int bankId = 0;
            foreach (var b in vmBank.ListBank)
            {
                if (b.NameShort == a.Bank)
                {
                    bankId = b.Id;
                    break;
                }
            }

            AgreementViewModel vmAgreement = new AgreementViewModel();
            int agreementId = 0;
            foreach (var agr in vmAgreement.ListAgreement)
            {
                if (agr.Number == a.Agreement)
                {
                    agreementId = agr.Id;
                    break;

                }
            }
                TypeAccountViewModel vmTypeAccount = new TypeAccountViewModel();
                int typeAccountId = 0;
                foreach (var ta in vmTypeAccount.ListTypeAccount)
                {
                    if (ta.typeAccount == a.type)
                    {
                        typeAccountId = ta.Id;
                        break;
                    }
                }
                if (bankId != 0 & agreementId != 0 & typeAccountId != 0)
                {
                    this.Id = a.Id;
                    this.BankId = bankId;
                    this.AgreementId = agreementId;
                    this.TypeId = typeAccountId;
                    this.account = a.account;
                }
                return this;
            }

        }

    }