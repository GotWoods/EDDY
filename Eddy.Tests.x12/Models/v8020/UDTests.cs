using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.Tests.Models.v8020;

public class UDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UD*tk*QU*p*faBnNpyl*b*OV*1*DD*4*q*5*K*4*fp*dB*nz*Jc";

		var expected = new UD_UnderwritingStatus()
		{
			StatusCode = "tk",
			StatusCode2 = "QU",
			UnderwritingDecisionCode = "p",
			Date = "faBnNpyl",
			Description = "b",
			OfferBasisCode = "OV",
			AssignedNumber = 1,
			OfferBasisCode2 = "DD",
			AssignedNumber2 = 4,
			Description2 = "q",
			PercentageAsDecimal = 5,
			Amount = "K",
			Number = 4,
			StateOrProvinceCode = "fp",
			CountryCode = "dB",
			StateOrProvinceCode2 = "nz",
			CountryCode2 = "Jc",
		};

		var actual = Map.MapObject<UD_UnderwritingStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tk", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new UD_UnderwritingStatus();
		//Required fields
		//Test Parameters
		subject.StatusCode = statusCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.Description2) || !string.IsNullOrEmpty(subject.Description2) || subject.PercentageAsDecimal > 0 || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.Description2 = "q";
			subject.PercentageAsDecimal = 5;
			subject.Amount = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, "", true)]
	[InlineData("q", 5, "K", true)]
	[InlineData("q", 0, "", false)]
	[InlineData("", 5, "K", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Description2(string description2, decimal percentageAsDecimal, string amount, bool isValidExpected)
	{
		var subject = new UD_UnderwritingStatus();
		//Required fields
		subject.StatusCode = "tk";
		//Test Parameters
		subject.Description2 = description2;
		if (percentageAsDecimal > 0) 
			subject.PercentageAsDecimal = percentageAsDecimal;
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
