using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class BLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "BLI+I+++5+g+";

		var expected = new BLI_BillableInformation()
		{
			MonetaryAmount = "I",
			Diagnosis = null,
			DateTimePeriod = null,
			ObjectIdentifier = "5",
			YesOrNoIndicatorCode = "g",
			RelatedCause = null,
		};

		var actual = Map.MapObject<BLI_BillableInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
