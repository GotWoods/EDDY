using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class FCLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FCL*P*3*E*2*M0";

		var expected = new FCL_Foreclosure()
		{
			DeficiencyJudgmentCode = "P",
			YesNoConditionOrResponseCode = "3",
			AmountQualifierCode = "E",
			MonetaryAmount = 2,
			AdjustmentReasonCode = "M0",
		};

		var actual = Map.MapObject<FCL_Foreclosure>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("E", 2, true)]
	[InlineData("E", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new FCL_Foreclosure();
		//Required fields
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
