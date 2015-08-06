using System.Collections.Generic;
using Ductia.Domain;

namespace Ductia.Web.Controllers
{
	public class GradeRequest
	{
		public Instrument Instrument { get; set; }
		public IEnumerable<byte> SelectedGrades { get; set; }
	}
}