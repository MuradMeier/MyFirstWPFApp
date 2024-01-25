using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class Agreement
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime DataOpen { get; set; }
        public DateTime DataClose { get; set; }
        public Agreement() { }
        public Agreement(int id, string number, DateTime dataOpen, DateTime dataClose)
        {
            this.Id = id;
            this.Number = number;
            this.DataOpen = dataOpen;
            this.DataClose = dataClose;
        }
        public Agreement ShallowCopy()
        {
            return (Agreement)this.MemberwiseClone();
        }
    }
}
