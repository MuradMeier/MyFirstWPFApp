using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class TypeAccount
    {
        public int Id { get; set; }
        public string typeAccount { get; set; }
        public TypeAccount() { }
        public TypeAccount(int id, string typeaccount)
        {
            this.Id = id;
            this.typeAccount = typeaccount;
        }
        public TypeAccount ShallowCopy()
        {
            return (TypeAccount)this.MemberwiseClone();
        }
    }
}
