using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class BLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "BLI+p+++8+2+";

		var expected = new BLI_BillableInformation()
		{
			MonetaryAmountValue = "p",
			Diagnosis = null,
			DateTimePeriod = null,
			ObjectIdentifier = "8",
			YesNoCode = "2",
			RelatedCause = null,
		};

		var actual = Map.MapObject<BLI_BillableInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
