using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class PGITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PGI+M+";

		var expected = new PGI_ProductGroupInformation()
		{
			ProductGroupTypeCoded = "M",
			ProductGroup = null,
		};

		var actual = Map.MapObject<PGI_ProductGroupInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredProductGroupTypeCoded(string productGroupTypeCoded, bool isValidExpected)
	{
		var subject = new PGI_ProductGroupInformation();
		//Required fields
		//Test Parameters
		subject.ProductGroupTypeCoded = productGroupTypeCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
