using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PDETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PDE*1*L**6";

		var expected = new PDE_PropertyMetesAndBoundsDescription()
		{
			FreeFormMessageText = "1",
			DirectionIdentifierCode = "L",
			CompositeUnitOfMeasure = null,
			MeasurementValue = 6,
		};

		var actual = Map.MapObject<PDE_PropertyMetesAndBoundsDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
