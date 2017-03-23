using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Entities.Abstract;

namespace Store.Entities.Concrete
{
	public class Error : IEntityBase
	{
		public int Id { get; set; }
		public string Message { get; set; }
		public string StackTrace { get; set; }
		public DateTime DateOccured { get; set; }
	}
}
