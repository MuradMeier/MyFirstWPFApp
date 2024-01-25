using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    class TypeAccountViewModel
    {
        public int MaxId()
        {
            int max = 0;
            foreach (var b in this.ListTypeAccount)
            {
                if (max < b.Id)
                {
                    max = b.Id;
                };
            }
            return max;
        }
        public ObservableCollection<TypeAccount> ListTypeAccount { get; set; } = new ObservableCollection<TypeAccount>();
        public TypeAccountViewModel()
        {
            this.ListTypeAccount.Add(
            new TypeAccount
            {
                Id = 1,
                typeAccount = "брокерский"
            });
            this.ListTypeAccount.Add(
            new TypeAccount
            {
                Id = 2,
                typeAccount = "дилерский"
            });
            this.ListTypeAccount.Add(
            new TypeAccount
            {
                Id = 3,
                typeAccount = "управления"
            });
        }
    }
}