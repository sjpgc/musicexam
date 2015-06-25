using NUnit.Framework;

namespace Ductia.Persistence.Tests
{
	[TestFixture]
    public abstract class PieceRepositoryTests
	{
		protected abstract IPieceRepository PieceRepository { get; }

		[SetUp]
		protected abstract void Setup();

		[TearDown]
		protected abstract void TearDown();
	}
}