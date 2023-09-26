using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class FCLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FCL*N*C*O*7*EQ";

		var expected = new FCL_Foreclosure()
		{
			DeficiencyJudgmentCode = "N",
			YesNoConditionOrResponseCode = "C",
			AmountQualifierCode = "O",
			MonetaryAmount = 7,
			AdjustmentReasonCode = "EQ",
		};

		var actual = Map.MapObject<FCL_Foreclosure>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredDeficiencyJudgmentCode(string deficiencyJudgmentCode, bool isValidExpected)
	{
		var subject = new FCL_Foreclosure();
		//Required fields
		//Test Parameters
		subject.DeficiencyJudgmentCode = deficiencyJudgmentCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "O";
			subject.MonetaryAmount = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("O", 7, true)]
	[InlineData("O", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new FCL_Foreclosure();
		//Required fields
		subject.DeficiencyJudgmentCode = "N";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
