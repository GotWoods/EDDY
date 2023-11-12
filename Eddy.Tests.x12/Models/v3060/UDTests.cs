using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class UDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UD*4j*AS*P*g5YReA*W*Uk*7*sc*1*1*6*4*4*Mk*Df*gM*ib";

		var expected = new UD_UnderwritingStatus()
		{
			StatusCode = "4j",
			StatusCode2 = "AS",
			UnderwritingDecisionCode = "P",
			Date = "g5YReA",
			Description = "W",
			OfferBasisCode = "Uk",
			AssignedNumber = 7,
			OfferBasisCode2 = "sc",
			AssignedNumber2 = 1,
			Description2 = "1",
			Percent = 6,
			Amount = "4",
			Number = 4,
			StateOrProvinceCode = "Mk",
			CountryCode = "Df",
			StateOrProvinceCode2 = "gM",
			CountryCode2 = "ib",
		};

		var actual = Map.MapObject<UD_UnderwritingStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4j", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new UD_UnderwritingStatus();
		//Required fields
		//Test Parameters
		subject.StatusCode = statusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, "", true)]
	[InlineData("1", 6, "4", true)]
	[InlineData("1", 0, "", false)]
	[InlineData("", 6, "4", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_StatusCode(string description2, decimal percent, string amount, bool isValidExpected)
	{
		var subject = new UD_UnderwritingStatus();
		//Required fields
        subject.StatusCode = "AB";
		//Test Parameters
		subject.Description2 = description2;
		if (percent > 0) 
			subject.Percent = percent;
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
