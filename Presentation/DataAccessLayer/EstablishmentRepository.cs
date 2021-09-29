using System;
using System.Collections.Generic;
using System.IO;
using Entity;

namespace DataAccessLayer
{
    public class EstablishmentRepository
    {
        private string path = "data.txt";

        public void Save(Establishment establishment)
        {
            if (Search(establishment.ID) != null)
            {
                throw new Exception("ID de Establecimiento previamente REGISTRADA!");
            }
            WriteStream(establishment);
        }
        private void WriteStream(Establishment establishment)
        {
            using (Stream file_stream = new FileStream(path, FileMode.Append))
            {
                using (StreamWriter writer = new StreamWriter(file_stream))
                {
                    writer.WriteLine($"{establishment.ID};" +
                        $"{establishment.Name};{establishment.Annual_Income};" +
                        $"{establishment.Annual_Expenses};{establishment.Work_Time};" +
                        $"{establishment.Responsability_Kind};{establishment.Tax_Value};" +
                        $"{establishment.Rate};");
                }
            }
        }
        public Establishment Search(int id)
        {
            List<Establishment> rates;
            rates = ReadAllFile();

            foreach (var searched_item in rates)
            {
                if (searched_item.ID == id)
                {
                    return searched_item;
                }
            }
            return null;
        }
        public List<Establishment> ReadAllFile()
        {
            List<Establishment> rates;
            using (Stream file_stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(file_stream))
                {
                    rates = BuildEstablishmentFromStream(reader);
                }
            }
            return rates;
        }
        private List<Establishment> BuildEstablishmentFromStream(StreamReader reader)
        {
            List<Establishment> rates = new List<Establishment>();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split(";");
                Establishment establishment;
                if (data[5].Equals("responsable de iva"))
                {
                    establishment = new ResponsibleEstablishment(
                    int.Parse(data[0]), data[1], double.Parse(data[2]),
                    double.Parse(data[3]),
                    int.Parse(data[4]), data[5], double.Parse(data[6]),
                    double.Parse(data[7]));
                }
                else if (data[5].Equals("no responsable de iva"))
                {
                    establishment = new NonResponsibleEstablishment(
                    int.Parse(data[0]), data[1], double.Parse(data[2]),
                    double.Parse(data[3]),
                    int.Parse(data[4]), data[5], double.Parse(data[6]),
                    double.Parse(data[7]));
                }
                else
                {
                    establishment = new SimpleTaxRegimeEstablishment(
                    int.Parse(data[0]), data[1], double.Parse(data[2]),
                    double.Parse(data[3]),
                    int.Parse(data[4]), data[5], double.Parse(data[6]),
                    double.Parse(data[7]));
                }
                rates.Add(establishment);
            }
            return rates;
        }
        public Establishment Delete(int ID)
        {
            Establishment establishment = Search(ID);
            if (establishment != null) 
            { 
                List<Establishment> rates = ReadAllFile();

                FileStream file = new FileStream(path, FileMode.Create);
                file.Close();

                foreach (var item in rates)
                {
                    if (item.ID != establishment.ID)
                    {
                        Save(item);
                    }
                }
            }
            return establishment;
        }
    }
}