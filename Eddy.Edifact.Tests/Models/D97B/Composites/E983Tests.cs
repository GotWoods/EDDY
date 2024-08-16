using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B.Composites;

public class E983Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "S:k:o:2";

		var expected = new E983_RateInformation()
		{
			RateTariffClassIdentification = "S",
			RangeMinimum = "k",
			RangeMaximum = "o",
			ProcessingIndicatorCoded = "2",
		};

		var actual = Map.MapComposite<E983_RateInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
