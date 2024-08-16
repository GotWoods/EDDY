using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class PGITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PGI+i+";

		var expected = new PGI_ProductGroupInformation()
		{
			ProductGroupTypeCode = "i",
			ProductGroup = null,
		};

		var actual = Map.MapObject<PGI_ProductGroupInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredProductGroupTypeCode(string productGroupTypeCode, bool isValidExpected)
	{
		var subject = new PGI_ProductGroupInformation();
		//Required fields
		//Test Parameters
		subject.ProductGroupTypeCode = productGroupTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
