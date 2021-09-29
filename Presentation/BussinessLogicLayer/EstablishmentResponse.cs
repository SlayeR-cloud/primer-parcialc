using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DataAccessLayer;

namespace BussinessLogicLayer
{
    public class EstablishmentResponse
    {
        List<Establishment> rates;
        string message;
        public List<Establishment> Rates { get => rates; set => rates = value; }
        public string Message { get => message; set => message = value; }

        public EstablishmentResponse(string message)
        {
            Message = message;
        }

        public EstablishmentResponse(List<Establishment> rates)
        {
            Rates = rates;
        }
    }
}