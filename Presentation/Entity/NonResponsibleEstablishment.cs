using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class NonResponsibleEstablishment : Establishment
    {
        public NonResponsibleEstablishment(int iD, string name, 
            double annual_Income, double annual_Expenses, int work_Time,
            string responsability_Kind) : base(iD, name, annual_Income,
                annual_Expenses, work_Time, responsability_Kind)
        {
        }

        public NonResponsibleEstablishment(int iD, string name,
            double annual_Income, double annual_Expenses, int work_Time,
            string responsability_Kind, double tax_Value, double rate) : base(iD,
                name, annual_Income, annual_Expenses, work_Time, 
                responsability_Kind, tax_Value, rate)
        {
        }

        public override void CalculateRate()
        {
            if (CalculateEarnings() > (100 * GetUVT))
            {
                if (Work_Time < 5)
                {
                    Rate = (double)1 / 100;
                }
                else if (Work_Time >= 5 && Work_Time < 10)
                {
                    Rate = (double)2 / 100;
                }
                else if (Work_Time >= 10)
                {
                    Rate = (double)3 / 100;
                }
                else
                {
                    Rate = 0;
                }
            }
            else
            {
                Rate = 0;
            }
        }
    }
}