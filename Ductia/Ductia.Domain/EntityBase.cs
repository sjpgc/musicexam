using System;

namespace Ductia.Domain
{
	public class EntityBase : IEntity
	{
		public Guid Id { get; set; }
	}
}