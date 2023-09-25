using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class AD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AD1*ZC*1*m*Z*oN";

		var expected = new AD1_AdjustmentAmount()
		{
			AdjustmentReasonCode = "ZC",
			MonetaryAmount = 1,
			AdjustmentReasonCodeCharacteristic = "m",
			FrequencyCode = "Z",
			LateReasonCode = "oN",
		};

		var actual = Map.MapObject<AD1_AdjustmentAmount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZC", true)]
	public void Validation_RequiredAdjustmentReasonCode(string adjustmentReasonCode, bool isValidExpected)
	{
		var subject = new AD1_AdjustmentAmount();
		//Required fields
		//Test Parameters
		subject.AdjustmentReasonCode = adjustmentReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
