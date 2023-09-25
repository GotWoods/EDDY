using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class TUDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TUD*5E*w*4f";

		var expected = new TUD_TradeUnionData()
		{
			TradeUnionCode = "5E",
			IdentificationCodeQualifier = "w",
			IdentificationCode = "4f",
		};

		var actual = Map.MapObject<TUD_TradeUnionData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5E", true)]
	public void Validation_RequiredTradeUnionCode(string tradeUnionCode, bool isValidExpected)
	{
		var subject = new TUD_TradeUnionData();
		//Required fields
		//Test Parameters
		subject.TradeUnionCode = tradeUnionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "w";
			subject.IdentificationCode = "4f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("w", "4f", true)]
	[InlineData("w", "", false)]
	[InlineData("", "4f", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new TUD_TradeUnionData();
		//Required fields
		subject.TradeUnionCode = "5E";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
