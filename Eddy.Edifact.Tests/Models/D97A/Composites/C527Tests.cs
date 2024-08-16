using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class C527Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "u:P:h:A";

		var expected = new C527_StatisticalDetails()
		{
			MeasurementValue = "u",
			MeasureUnitQualifier = "P",
			PropertyMeasuredCoded = "h",
			MeasurementSignificanceCoded = "A",
		};

		var actual = Map.MapComposite<C527_StatisticalDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
