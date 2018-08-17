using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalSolver
{
    //Custome class used to store intercept data.
    class Intercepts : IComparable<Intercepts>
    {
        private decimal value;
        private string oper;

        public Intercepts(decimal value, string oper)
        {
            this.value = value;
            this.oper = oper;
        }

        public decimal Value { get => value; set => this.value = value; }
        public string Oper { get => oper; set => oper = value; }

        public int CompareTo(Intercepts inter)
        {
            if (inter.Value < this.Value)
            {
                return 1;
            }
            else if (inter.Value > this.Value)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
