using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class FCLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FCL*4*S*h*5*FK";

		var expected = new FCL_Foreclosure()
		{
			DeficiencyJudgmentCode = "4",
			YesNoConditionOrResponseCode = "S",
			AmountQualifierCode = "h",
			MonetaryAmount = 5,
			AdjustmentReasonCode = "FK",
		};

		var actual = Map.MapObject<FCL_Foreclosure>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("h", 5, true)]
	[InlineData("h", 0, false)]
	[InlineData("", 5, false)]
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
