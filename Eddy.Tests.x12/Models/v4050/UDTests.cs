using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class UDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UD*Ti*ry*x*A8PQ1L4D*4*tb*1*Fy*9*S*3*4*2*Rb*9G*uO*km";

		var expected = new UD_UnderwritingStatus()
		{
			StatusCode = "Ti",
			StatusCode2 = "ry",
			UnderwritingDecisionCode = "x",
			Date = "A8PQ1L4D",
			Description = "4",
			OfferBasisCode = "tb",
			AssignedNumber = 1,
			OfferBasisCode2 = "Fy",
			AssignedNumber2 = 9,
			Description2 = "S",
			PercentageAsDecimal = 3,
			Amount = "4",
			Number = 2,
			StateOrProvinceCode = "Rb",
			CountryCode = "9G",
			StateOrProvinceCode2 = "uO",
			CountryCode2 = "km",
		};

		var actual = Map.MapObject<UD_UnderwritingStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ti", true)]
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
	[InlineData("S", 3, "4", true)]
	[InlineData("S", 0, "", false)]
	[InlineData("", 3, "4", true)]
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
