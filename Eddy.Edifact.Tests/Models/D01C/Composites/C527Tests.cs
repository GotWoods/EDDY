using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class C527Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "l:7:e:N";

		var expected = new C527_StatisticalDetails()
		{
			Measure = "l",
			MeasurementUnitCode = "7",
			MeasuredAttributeCode = "e",
			MeasurementSignificanceCode = "N",
		};

		var actual = Map.MapComposite<C527_StatisticalDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
