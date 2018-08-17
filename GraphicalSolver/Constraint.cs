using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicalSolver
{
    //Custome class used to hole constraint data.
    class Constraint
    {
        private Point point;
        private string oper;

        public Constraint(Point point, string oper)
        {
            this.point = point;
            this.oper = oper;
        }

        public Point Point { get => point; set => point = value; }
        public string Oper { get => oper; set => oper = value; }
    }
}
