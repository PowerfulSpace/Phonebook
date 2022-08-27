using Microsoft.Extensions.DependencyInjection;
using PS.Phonebook.DAL.Interfaces;
using PS.Phonebook.DAL.Repositories;
using PS.Phonebook.Service.Implementations;
using PS.Phonebook.Service.Interfaces;

namespace PS.Phonebook.Web.Configure
{
    public static class Initialize
    {
        public static void InitializeRepository(this IServiceCollection services)
        {
            services.AddScoped<IDepartment, DepartmentRepository>();
            services.AddScoped<IEmployee,EmployeeRepository>();
            services.AddScoped<IOrganization, OrganizationReposotiry>();
            services.AddScoped<IOrganization1,Organization1Repository>();
            services.AddScoped<IOrganization2,Organization2Repository>();
            services.AddScoped<IOrganization3,Organization3Repository>();
            services.AddScoped<IPosition,PositionRepository>();
            services.AddScoped<ISubdivision, SubdivisionRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped <IEmployeesPhonebookService, EmployeesPhonebookService> ();
        }
    }
}
