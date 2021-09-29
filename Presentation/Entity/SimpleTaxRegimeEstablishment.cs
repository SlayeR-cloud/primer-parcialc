using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SimpleTaxRegimeEstablishment : Establishment
    {
        public SimpleTaxRegimeEstablishment(int iD, string name, 
            double annual_Income, double annual_Expenses,
            int work_Time, string responsability_Kind) : base(iD,
                name, annual_Income, annual_Expenses, work_Time, responsability_Kind)
        {
        }

        public SimpleTaxRegimeEstablishment(int iD, string name, 
            double annual_Income, double annual_Expenses, 
            int work_Time, string responsability_Kind, 
            double tax_Value, double rate) : base(iD, name,
                annual_Income, annual_Expenses, work_Time,
                responsability_Kind, tax_Value, rate)
        {
        }

        public override void CalculateRate()
        {
            if (CalculateEarnings() > (50 * GetUVT))
            {
                Rate = (double) 5 / 100;
            }
            else
            {
                Rate = 0;
            }
        }
    }
}
