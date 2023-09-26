using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class TUDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TUD*tZ*d*cN";

		var expected = new TUD_TradeUnionData()
		{
			TradeUnionCode = "tZ",
			IdentificationCodeQualifier = "d",
			IdentificationCode = "cN",
		};

		var actual = Map.MapObject<TUD_TradeUnionData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tZ", true)]
	public void Validation_RequiredTradeUnionCode(string tradeUnionCode, bool isValidExpected)
	{
		var subject = new TUD_TradeUnionData();
		//Required fields
		//Test Parameters
		subject.TradeUnionCode = tradeUnionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "d";
			subject.IdentificationCode = "cN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d", "cN", true)]
	[InlineData("d", "", false)]
	[InlineData("", "cN", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new TUD_TradeUnionData();
		//Required fields
		subject.TradeUnionCode = "tZ";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
