using System.Collections.Generic;
using System.Linq;
using Ductia.Domain;

namespace Ductia.Persistence.InMemory
{
	internal class BoardCollection : List<ExamBoard>
	{
		public ExamBoard this[string index]
		{
			get { return this.SingleOrDefault(exBoard => exBoard.Name == index); }
		}
	}
}