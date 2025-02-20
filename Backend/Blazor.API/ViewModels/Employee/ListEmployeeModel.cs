﻿namespace Blazor.API.ViewModels.Employee
{
	public class ListEmployeeModel
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public string Address { get; set; }

		public string PhoneNumber { get; set; }

		public string Email { get; set; }

		public Boolean IsConfirmed { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
