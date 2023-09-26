using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class TUDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TUD*Qi*g*OR";

		var expected = new TUD_TradeUnionData()
		{
			TradeUnionCode = "Qi",
			IdentificationCodeQualifier = "g",
			IdentificationCode = "OR",
		};

		var actual = Map.MapObject<TUD_TradeUnionData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Qi", true)]
	public void Validation_RequiredTradeUnionCode(string tradeUnionCode, bool isValidExpected)
	{
		var subject = new TUD_TradeUnionData();
		//Required fields
		//Test Parameters
		subject.TradeUnionCode = tradeUnionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "g";
			subject.IdentificationCode = "OR";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("g", "OR", true)]
	[InlineData("g", "", false)]
	[InlineData("", "OR", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new TUD_TradeUnionData();
		//Required fields
		subject.TradeUnionCode = "Qi";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
