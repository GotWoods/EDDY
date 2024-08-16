using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class QVRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "QVR++P+";

		var expected = new QVR_QuantityVariances()
		{
			QuantityDifferenceInformation = null,
			DiscrepancyCoded = "P",
			ReasonForChange = null,
		};

		var actual = Map.MapObject<QVR_QuantityVariances>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
