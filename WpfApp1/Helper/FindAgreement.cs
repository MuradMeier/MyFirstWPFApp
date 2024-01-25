using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Helper
{
    class FindAgreement
    {
        int id;
        public FindAgreement(int id)
        {
            this.id = id;
        }
        public bool AgreementPredicate(Agreement agreement)
        {
            return agreement.Id == id;
        }
    }
}
