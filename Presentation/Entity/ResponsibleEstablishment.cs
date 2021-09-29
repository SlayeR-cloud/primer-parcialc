using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ResponsibleEstablishment : Establishment
    {
        public ResponsibleEstablishment(int iD, string name, 
            double annual_Income, double annual_Expenses, 
            int work_Time, string responsability_Kind) : base(iD, 
                name, annual_Income, annual_Expenses, work_Time, 
                responsability_Kind)
        {
        }

        public ResponsibleEstablishment(int iD, string name, 
            double annual_Income, double annual_Expenses, 
            int work_Time, string responsability_Kind, 
            double tax_Value, double rate) : base(iD, name, 
                annual_Income, annual_Expenses, work_Time, 
                responsability_Kind, tax_Value, rate)
        {
        }

        public override void CalculateRate()
        {
            double uvt = Math.Round(CalculateUVT(), 2);
            if (uvt >= 0 && uvt < (100 * GetUVT))
            {
                Rate = (double)5 / 100;
            }
            else if (uvt >= (100 * GetUVT) && uvt < (500 * GetUVT))
            {
                Rate = (double)10 / 100;
            }
            else if (uvt >= (500 * GetUVT))
            {
                Rate = (double)15 / 100;
            }
            else
            {
                Rate = 0;
            }
        }
    }
}