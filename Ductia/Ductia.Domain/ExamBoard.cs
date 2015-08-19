using System.Collections.Generic;

namespace Ductia.Domain
{
	public class ExamBoard : EntityBase
	{
		public string Name { get; set; }
		public IEnumerable<Grade> Grades { get; set; } 
	}
}
