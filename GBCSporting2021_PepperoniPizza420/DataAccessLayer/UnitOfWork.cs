using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_PepperoniPizza420.DataAccessLayer.Interfaces;
using GBCSporting2021_PepperoniPizza420.DataAccessLayer.Repositories;
using GBCSporting2021_PepperoniPizza420.Models;

namespace GBCSporting2021_PepperoniPizza420.DataAccessLayer
{
    public class UnitOfWork :  IUnitOfWork
    {
        private SportsProContext ctx;
        public IRepository<Incident> incidentRepo;
        public IRepository<Customer> customerRepo;
        public IRepository<Registration> registrationRepo;
        public IRepository<Product> productRepo;
        public IRepository<Technician> technicianRepo;
        public IRepository<Country> countryRepo;
        public UnitOfWork(SportsProContext context)
        {
            this.ctx = context;
        }
        public ICountryRepository CountryRepository
        {
            get
            {
                return new CountryRepository(ctx);
            }
        }
        public ICustomerRepository CustomerRepository
        {
            get
            {
                return new CustomerRepository(ctx);
            }
        }
        public IIncidentRepository IncidentRepository
        {
            get
            {
                return new IncidentRepository(ctx);
            }
        }
        public IRegistrationRepository RegistrationRepository
        {
            get
            {
                return new RegistrationRepository(ctx);
            }
        }
        public IProductRepository ProductRepository
        {
            get
            {
                return new ProductRepository(ctx);
            }
        }
        public ITechnicianRepository TechnicianRepository
        {
            get
            {
                return new TechnicianRepository(ctx);
            }
        }
        public void Save()
        {
            this.ctx.SaveChanges();
        }

        
    }
}
