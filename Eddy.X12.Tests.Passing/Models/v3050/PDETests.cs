using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PDETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PDE*I*N**1";

		var expected = new PDE_PropertyMetesAndBoundsDescription()
		{
			FreeFormMessageText = "I",
			DirectionIdentifierCode = "N",
			CompositeUnitOfMeasure = null,
			MeasurementValue = 1,
		};

		var actual = Map.MapObject<PDE_PropertyMetesAndBoundsDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
