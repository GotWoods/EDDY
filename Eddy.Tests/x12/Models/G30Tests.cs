using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G30Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G30*n*7";

		var expected = new G30_RetailAccountMarketingTypes()
		{
			MarketingTypeCode = "n",
			Number = 7,
		};

		var actual = Map.MapObject<G30_RetailAccountMarketingTypes>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredMarketingTypeCode(string marketingTypeCode, bool isValidExpected)
	{
		var subject = new G30_RetailAccountMarketingTypes();
		subject.MarketingTypeCode = marketingTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
