    using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class Bank
    {
        public int Id { get; set; }
        public string NameFull { get; set; }
        public string NameShort { get; set; }
        public string Inn { get; set; }
        public string Bik { get; set; }
        public string KorAccount { get; set; }
        public string Account { get; set; }
        public string City { get; set; }
        public Bank() { }
        public Bank(int id, string nameFull, string nameShort, string inn, string bik, string korAccount, string acc, string city)
        {
            this.Id = id;
            this.NameFull = nameFull;
            this.NameShort = nameShort;
            this.Inn = inn;
            this.Bik = bik;
            this.KorAccount = korAccount;
            this.Account = acc;
            this.City = city;
        }
        public Bank ShallowCopy()
        {
            return (Bank)this.MemberwiseClone();
        }

    }
}
