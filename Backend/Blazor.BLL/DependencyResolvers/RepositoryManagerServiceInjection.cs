using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.BLL.Managers.Abstract;
using Blazor.BLL.Managers.Concrete;

using Blazor.DAL.Repositories.Abstract;
using Blazor.DAL.Repositories.Concrete;
using Castle.Core.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.BLL.DependencyResolvers
{
    public static class RepositoryManagerServiceInjection
    {
        public static IServiceCollection AddRepositoryManagerService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IManager<>), typeof(BaseManager<>));

            services.AddScoped<ICustomerRepository,CustomerRepository>();
            services.AddScoped<ICustomerManager, CustomerManager>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountManager, AccountManager>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryManager, CategoryManager>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeManager, EmployeeManager>();

            services.AddScoped<ILocalityRepository, LocalityRepository>();
            services.AddScoped<ILocalityManager, LocalityManager>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductManager, ProductManager>();

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleManager, RoleManager>();

            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ISaleManager, SaleManager>();

            services.AddScoped<IStockRepository,StockRepository>();
            services.AddScoped<IStockManager, StockManager>();

            services.AddScoped<IUserRoleRepository,UserRoleRepository>();
            services.AddScoped<IUserRoleManager, UserRoleManager>();    

            services.AddScoped<IStockMovementRepository, StockMovementRepository>();
            services.AddScoped<IStockMovementManager, StockMovementManager>();

            return services;

        }

    }
}
