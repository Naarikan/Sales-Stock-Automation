using Blazor;
using Blazored.LocalStorage;
using Blazored.Toast;
using Business.Managers.Abstract;
using Business.Managers.Concrete;
using Business.Methods.LoginMethods.Implementations;
using Business.Methods.LoginMethods.Interfaces;
using Business.Provider;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddRadzenComponents();
builder.Services.AddBlazoredToast();


builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ILocalityService, LocalityService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<IStockMovementService, StockMovementService>();
builder.Services.AddScoped<IStatisticService, StatisticService>();
builder.Services.AddScoped<ILoginService,LoginService>();
builder.Services.AddScoped<IRegisterService, RegisterService>();



builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();




builder.Services.AddScoped<IStorageMethods,StorageMethods>();
builder.Services.AddScoped<IAuthMethods, AuthMethods>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7146/") });



builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();



await builder.Build().RunAsync();
