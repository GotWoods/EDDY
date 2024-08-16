using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class ARDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ARD++";

		var expected = new ARD_MonetaryAmountFunction()
		{
			MonetaryAmountFunction = null,
			MonetaryAmountFunctionDetail = null,
		};

		var actual = Map.MapObject<ARD_MonetaryAmountFunction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
