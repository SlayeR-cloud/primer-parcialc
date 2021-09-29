using System;

namespace Entity
{
    public abstract class Establishment
    {
        private const int UVT = 30000;

        public int ID { get; set; }
        public string Name { get; set; }
        public double Annual_Income { get; set; }
        public double Annual_Expenses { get; set; }
        public int Work_Time { get; set; }
        public string Responsability_Kind { get; set; }
        public double Tax_Value { get; set; }

        public double Rate { get; set; }
        public int GetUVT { get => UVT; }

        public Establishment(int iD, string name, double annual_Income,
            double annual_Expenses, int work_Time, string responsability_Kind)
        {
            ID = iD;
            Name = name;
            Annual_Income = annual_Income;
            Annual_Expenses = annual_Expenses;
            Work_Time = work_Time;
            Responsability_Kind = responsability_Kind;
            CalculateTaxValue();
        }
        public Establishment(int iD, string name, double annual_Income,
            double annual_Expenses, int work_Time, string responsability_Kind,
            double tax_Value, double rate)
        {
            ID = iD;
            Name = name;
            Annual_Income = annual_Income;
            Annual_Expenses = annual_Expenses;
            Work_Time = work_Time;
            Responsability_Kind = responsability_Kind;
            Tax_Value = tax_Value;
            Rate = rate;
        }
        public double CalculateEarnings()
        {
            return Annual_Income - Annual_Expenses;
        }
        public double CalculateUVT()
        {
            return CalculateEarnings() / UVT;
        }

        public abstract void CalculateRate();

        public void CalculateTaxValue() 
        {
            CalculateRate();
            if (Rate < 0) Tax_Value = 0;
            else Tax_Value = CalculateEarnings() * Rate;
        }

        public override string ToString()
        {
            return $"ID: {ID}" +
                $"\nNombre: {Name}" +
                $"\nIngresos Anuales (COP): {Annual_Income}" +
                $"\nGastos Anuales (COP): {Annual_Expenses}" +
                $"\nTiempo de funcionamiento (Años): {Work_Time}" +
                $"\nTipo responsabilidad: {Responsability_Kind}" +
                $"\nGanancia: {CalculateEarnings()}" +
                $"\nValor en UVT (1 UVT = 30000 COP): {Math.Round(CalculateUVT(), 2)}" +
                $"\nTarifa Aplicada (%): {Math.Round(Rate * 100, 2)}" +
                $"\nValor del impuesto (COP): {Tax_Value}";
        }
    }
}