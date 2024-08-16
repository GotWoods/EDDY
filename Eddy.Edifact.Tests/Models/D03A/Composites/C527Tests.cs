using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D03A;
using Eddy.Edifact.Models.D03A.Composites;

namespace Eddy.Edifact.Tests.Models.D03A.Composites;

public class C527Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "7:Q:V:I";

		var expected = new C527_StatisticalDetails()
		{
			Measure = "7",
			MeasurementUnitCode = "Q",
			MeasuredAttributeCode = "V",
			MeasurementSignificanceCode = "I",
		};

		var actual = Map.MapComposite<C527_StatisticalDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
