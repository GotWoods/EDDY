using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class PDTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PDT+Q+";

		var expected = new PDT_ProductInformation()
		{
			ProductDetailsTypeCodeQualifier = "Q",
			ProductClassDetails = null,
		};

		var actual = Map.MapObject<PDT_ProductInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
