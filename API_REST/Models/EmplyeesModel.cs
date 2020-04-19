using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST
{
    public class EmplyeesModel
    {
        public int BusinessEntityID { get; set; }
        public string NationalIDNumber { get; set; }
		public string LoginId { get; set; }
		public string OrganizationNode { get; set; }
		public string JobTitle { get; set; }
        public int OrganizationLevel { get; set; }
        public DateTime BirthDate { get; set; }
		public char MaritalStatus { get; set; }
		public char Gender { get; set; }
		public DateTime HireDate { get; set; }
		public int SalariedFlag { get; set; }
		public int VacationHours { get; set; }
		public int SickLeaveHours { get; set; }
		public int CurrentFlag { get; set; }
		public DateTime ModifiedDate { get; set; }

	}
}
