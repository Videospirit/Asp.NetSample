using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_PepperoniPizza420.DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        IIncidentRepository IncidentRepository { get; }
        IRegistrationRepository RegistrationRepository { get; }
        IProductRepository ProductRepository { get; }
        ITechnicianRepository TechnicianRepository { get; }
        ICountryRepository CountryRepository { get; }
        void Save();
    }
}
