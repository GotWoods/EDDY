using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FCLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FCL*I*6*u*8*N5";

		var expected = new FCL_Foreclosure()
		{
			DeficiencyJudgmentCode = "I",
			YesNoConditionOrResponseCode = "6",
			AmountQualifierCode = "u",
			MonetaryAmount = 8,
			AdjustmentReasonCode = "N5",
		};

		var actual = Map.MapObject<FCL_Foreclosure>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("u", 8, true)]
	[InlineData("", 8, false)]
	[InlineData("u", 0, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new FCL_Foreclosure();
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
