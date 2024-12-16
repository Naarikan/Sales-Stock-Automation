using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
	public class EmployeeModel
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public string Address { get; set; }

		public string PhoneNumber { get; set; }

		public string Email { get; set; }

		public string PasswordHash { get; set; }

		public Boolean IsConfirmed { get; set; }

		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
	}
}
