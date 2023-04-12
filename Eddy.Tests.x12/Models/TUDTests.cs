using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TUDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TUD*kA*B*Su";

		var expected = new TUD_TradeUnionData()
		{
			TradeUnionCode = "kA",
			IdentificationCodeQualifier = "B",
			IdentificationCode = "Su",
		};

		var actual = Map.MapObject<TUD_TradeUnionData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kA", true)]
	public void Validation_RequiredTradeUnionCode(string tradeUnionCode, bool isValidExpected)
	{
		var subject = new TUD_TradeUnionData();
		subject.TradeUnionCode = tradeUnionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("B", "Su", true)]
	[InlineData("", "Su", false)]
	[InlineData("B", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new TUD_TradeUnionData();
		subject.TradeUnionCode = "kA";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
