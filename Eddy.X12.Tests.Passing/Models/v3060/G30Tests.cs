using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class G30Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G30*F*7";

		var expected = new G30_RetailAccountMarketingTypes()
		{
			MarketingTypeCode = "F",
			Number = 7,
		};

		var actual = Map.MapObject<G30_RetailAccountMarketingTypes>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredMarketingTypeCode(string marketingTypeCode, bool isValidExpected)
	{
		var subject = new G30_RetailAccountMarketingTypes();
		//Required fields
		//Test Parameters
		subject.MarketingTypeCode = marketingTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
