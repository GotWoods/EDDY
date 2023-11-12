using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.Tests.Models.v7050;

public class UDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UD*pJ*sE*f*3ba2oGhs*4*wd*7*Fg*9*H*2*v*4*jZ*Au*3I*dC";

		var expected = new UD_UnderwritingStatus()
		{
			StatusCode = "pJ",
			StatusCode2 = "sE",
			UnderwritingDecisionCode = "f",
			Date = "3ba2oGhs",
			Description = "4",
			OfferBasisCode = "wd",
			AssignedNumber = 7,
			OfferBasisCode2 = "Fg",
			AssignedNumber2 = 9,
			Description2 = "H",
			PercentageAsDecimal = 2,
			Amount = "v",
			Number = 4,
			StateOrProvinceCode = "jZ",
			CountryCode = "Au",
			StateOrProvinceCode2 = "3I",
			CountryCode2 = "dC",
		};

		var actual = Map.MapObject<UD_UnderwritingStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pJ", true)]
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
	[InlineData("H", 2, "v", true)]
	[InlineData("H", 0, "", false)]
	[InlineData("", 2, "v", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_StatusCode(string description2, decimal percentageAsDecimal, string amount, bool isValidExpected)
	{
		var subject = new UD_UnderwritingStatus();
        //Required fields
        subject.StatusCode = "AB";
        //Test Parameters
        subject.Description2 = description2;
		if (percentageAsDecimal > 0) 
			subject.PercentageAsDecimal = percentageAsDecimal;
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
