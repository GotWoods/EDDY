using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class PDTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PDT+H+";

		var expected = new PDT_ProductInformation()
		{
			ProductDetailsQualifier = "H",
			ProductClassDetails = null,
		};

		var actual = Map.MapObject<PDT_ProductInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
