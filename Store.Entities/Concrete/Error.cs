using System;
using Store.Entities.Abstract;

namespace Store.Entities.Concrete
{
	public class Error : IEntityBase
	{
		public int Id { get; set; }
		public string Message { get; set; }
		public string StackTrace { set; get; }
		public DateTime DateOccured { get; set; }
	}
}
