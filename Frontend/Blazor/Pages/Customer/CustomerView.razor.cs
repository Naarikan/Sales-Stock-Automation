using Entities.Models;
using Radzen.Blazor;

namespace Blazor.Pages.Customer
{
	public partial class CustomerView
	{
		private List<CustomerModel>? customers;
		RadzenDataGrid<CustomerModel>? customersGrid;
		List<CustomerModel> customersToInsert = new List<CustomerModel>();
		private CustomerModel newCustomer = new CustomerModel(); // Added

		protected override async Task OnInitializedAsync()
		{
            await _authMethods.CheckAuthBeforeRequests();
            customers = await _customerService.GetCustomersAsync();
		}

		async Task InsertRow()
		{
			newCustomer = new CustomerModel(); // Reset newCustomer
			customersToInsert.Add(newCustomer);
			await customersGrid.InsertRow(newCustomer); // Using newCustomer
		}

		async Task OnCreateRow(CustomerModel Customer)
		{
			await _customerService.AddCustomerAsync(Customer);
			await Task.Delay(TimeSpan.FromSeconds(0.1));
			customers = await _customerService.GetCustomersAsync();
			await InvokeAsync(StateHasChanged);
		}

		void CancelEdit(CustomerModel CustomerModel)
		{
			customersGrid.CancelEditRow(CustomerModel);

		}

		void SaveRow(CustomerModel CustomerModel)
		{
			customersGrid?.UpdateRow(CustomerModel);

		}
		async Task OnUpdateRow(CustomerModel CustomerModel)
		{

			await _customerService.UpdateCustomerAsync(CustomerModel);
			await Task.Delay(TimeSpan.FromSeconds(0.2));
			customers = await _customerService.GetCustomersAsync();
			await InvokeAsync(StateHasChanged);
		}

		async void DeleteRow(CustomerModel model)
		{
			await _customerService.DeleteCustomerAsync(model.Id);
			customers = await _customerService.GetCustomersAsync();
			await InvokeAsync(StateHasChanged);
		}

		void EditRow(CustomerModel model) { customersGrid.EditRow(model); }
	}
}

