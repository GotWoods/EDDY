using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class UDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UD*Ur*QJ*s*PCwQDMCE*w*uy*2*aI*4*7*5*H*7*gB*uV*35*u9";

		var expected = new UD_UnderwritingStatus()
		{
			StatusCode = "Ur",
			StatusCode2 = "QJ",
			UnderwritingDecisionCode = "s",
			Date = "PCwQDMCE",
			Description = "w",
			OfferBasisCode = "uy",
			AssignedNumber = 2,
			OfferBasisCode2 = "aI",
			AssignedNumber2 = 4,
			Description2 = "7",
			Percent = 5,
			Amount = "H",
			Number = 7,
			StateOrProvinceCode = "gB",
			CountryCode = "uV",
			StateOrProvinceCode2 = "35",
			CountryCode2 = "u9",
		};

		var actual = Map.MapObject<UD_UnderwritingStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ur", true)]
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
	[InlineData("7", 5, "H", true)]
	[InlineData("7", 0, "", false)]
	[InlineData("", 5, "H", true)]
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
