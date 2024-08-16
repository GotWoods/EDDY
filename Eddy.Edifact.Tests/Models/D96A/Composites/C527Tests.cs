using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C527Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "H:V:T:n";

		var expected = new C527_StatisticalDetails()
		{
			MeasurementValue = "H",
			MeasureUnitQualifier = "V",
			MeasurementDimensionCoded = "T",
			MeasurementSignificanceCoded = "n",
		};

		var actual = Map.MapComposite<C527_StatisticalDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
