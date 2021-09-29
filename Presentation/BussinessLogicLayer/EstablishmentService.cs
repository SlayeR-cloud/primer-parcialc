using System;
using Entity;
using DataAccessLayer;

namespace BussinessLogicLayer
{
    public class EstablishmentService
    {
        public EstablishmentRepository Establishment_Repository { get; set; }

        public EstablishmentService()
        {
            Establishment_Repository = new EstablishmentRepository();
        }

        public EstablishmentResponse Save(Establishment establishment)
        {
            try
            {
                Establishment_Repository.Save(establishment);
                return new EstablishmentResponse("Guardado Correctamente");
            }
            catch (Exception e)
            {
                return new EstablishmentResponse("Algo salió mal :( , mira: " + e.Message);
            }
        }
        public EstablishmentResponse ConsultAll()
        {
            try
            {
                return new EstablishmentResponse(Establishment_Repository.ReadAllFile());
            }
            catch (Exception e)
            {
                return new EstablishmentResponse("Algo salió mal :( , mira: " + e.Message);
            }
        }
        public EstablishmentResponse Delete(int ID)
        {
            try
            {
                if (Establishment_Repository.Delete(ID) != null)
                    return new EstablishmentResponse("Borrado Correctamente");
                else 
                    return new EstablishmentResponse("No fue posible encontrar " +
                    "el establecimiento");
            }
            catch (Exception e)
            {
                return new EstablishmentResponse("Algo salió mal :( , mira: " + e.Message);
            }
        }
    }
}