using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class FCLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FCL*W*2*e*8*Ht";

		var expected = new FCL_Foreclosure()
		{
			DeficiencyJudgmentCode = "W",
			YesNoConditionOrResponseCode = "2",
			AmountQualifierCode = "e",
			MonetaryAmount = 8,
			AdjustmentReasonCode = "Ht",
		};

		var actual = Map.MapObject<FCL_Foreclosure>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("e", 8, true)]
	[InlineData("e", 0, false)]
	[InlineData("", 8, false)]
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
