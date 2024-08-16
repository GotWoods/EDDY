using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class QVRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "QVR++C+";

		var expected = new QVR_QuantityVariances()
		{
			QuantityDifferenceInformation = null,
			DiscrepancyNatureIdentificationCode = "C",
			ReasonForChange = null,
		};

		var actual = Map.MapObject<QVR_QuantityVariances>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
