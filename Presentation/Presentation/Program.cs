using System;
using Entity;
using BussinessLogicLayer;

namespace Presentation
{
    class Program
    {
        static EstablishmentService establishment_service;
        static void Main(string[] args)
        {
            establishment_service = new EstablishmentService();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Bienvenido a la alcaldia");
                Console.WriteLine("Selecciona la opcion que deseas realizar: ");
                Console.WriteLine("1) Guardar Establecimiento");
                Console.WriteLine("2) Consultar Establecimiento");
                Console.WriteLine("3) Eliminar Establecimiento");
                Console.Write("4) Salir" + "\nOpcion: ");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Establishment establishment = AddEstablishment();
                        SaveAnEstablishment(establishment);
                        break;
                    case 2:
                        ConsultEstablishments();
                        break;
                    case 3:
                        DeleteAnEstablishment();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opcion no valida, " +
                            "Regresando al menú...");
                        break;
                }
            }
        }
        static Establishment AddEstablishment()
        {
            Establishment establishment;
            Console.WriteLine("Registrando establecimiento: ");
            Console.Write("Coloque el ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Coloque el nombre: ");
            string name = Console.ReadLine();
            Console.Write("Coloque el valor de ingresos anuales: ");
            double annual_earnings = double.Parse(Console.ReadLine());
            Console.Write("Coloque el valor de gastos anuales: ");
            double annual_losts = double.Parse(Console.ReadLine());
            Console.Write("Coloque el tiempo de funcionamiento: ");
            int work_time = int.Parse(Console.ReadLine());
            Console.Write("Coloque el tipo de responsabilidad\n1) IVA\n2) NO IVA\nOpcion: ");
            int option = int.Parse(Console.ReadLine());
            string responsability_kind = "";
            if (option == 1)
            {
                responsability_kind = "responsable de iva";
                establishment = new ResponsibleEstablishment(id, name, annual_earnings, annual_losts
                , work_time, responsability_kind);
            }
            else
            {
                responsability_kind = "no responsable de iva";
                establishment = new NonResponsibleEstablishment(id, name, annual_earnings, annual_losts
                , work_time, responsability_kind);
            }
            return establishment;
        }
        static void SaveAnEstablishment(Establishment establishment)
        {
            var response = establishment_service.Save(establishment);
            Console.WriteLine(response.Message);
        }
        public static void ConsultEstablishments()
        {
            Console.WriteLine("\t\tEstablecimientos Registrados");
            var search = establishment_service.ConsultAll();
            if (search.Rates != null)
            {
                if (search.Rates.Count == 0) Console.WriteLine("Aun no hay establecimientos" +
                    " registrados\n");
                else
                {
                    foreach (var item in search.Rates)
                    {
                        Console.WriteLine("----------");
                        Console.WriteLine(item);
                        Console.WriteLine("----------");
                    }
                }
            }
            else
            {
                Console.WriteLine(search.Message);
            }
        }
        static void DeleteAnEstablishment()
        {
            var search = establishment_service.ConsultAll();
            if (search.Rates != null)
            {
                if (search.Rates.Count == 0) Console.WriteLine("Aun no hay establecimientos" +
                    " registrados\n");
                else
                {
                    ConsultEstablishments();
                    Console.Write("Coloca el ID del establecimiento a eliminar: ");
                    int id = int.Parse(Console.ReadLine());
                    var response = establishment_service.Delete(id);
                    Console.WriteLine(response.Message);
                }
            }
            else
            {
                Console.WriteLine("Aun no hay establecimientos" +
                       " registrados\n");
            }
        }
    }
}