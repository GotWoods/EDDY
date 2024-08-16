using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class ARDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ARD+";

		var expected = new ARD_AmountsRelationshipDetails()
		{
			MonetaryFunction = null,
		};

		var actual = Map.MapObject<ARD_AmountsRelationshipDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
