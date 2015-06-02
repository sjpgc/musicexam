using System;

namespace Ducita.Domain
{
	public class EntityBase : IEntity
	{
		public Guid Id { get; set; }
	}
}