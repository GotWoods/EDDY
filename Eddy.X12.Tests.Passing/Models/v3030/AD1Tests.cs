using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class AD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AD1*tX*6*a";

		var expected = new AD1_AdjustmentAmount()
		{
			AdjustmentReasonCode = "tX",
			MonetaryAmount = 6,
			AdjustmentReasonCodeCharacteristic = "a",
		};

		var actual = Map.MapObject<AD1_AdjustmentAmount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tX", true)]
	public void Validation_RequiredAdjustmentReasonCode(string adjustmentReasonCode, bool isValidExpected)
	{
		var subject = new AD1_AdjustmentAmount();
		//Required fields
		subject.MonetaryAmount = 6;
		//Test Parameters
		subject.AdjustmentReasonCode = adjustmentReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new AD1_AdjustmentAmount();
		//Required fields
		subject.AdjustmentReasonCode = "tX";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
