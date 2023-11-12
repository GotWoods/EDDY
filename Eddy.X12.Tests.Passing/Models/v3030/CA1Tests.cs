using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CA1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CA1*f*4*C*o";

		var expected = new CA1_ClaimAdjudication()
		{
			PaymentStatusCode = "f",
			ClaimAdjustmentReasonCode = "4",
			ClaimAdjustmentReasonCode2 = "C",
			ClaimAdjustmentReasonCode3 = "o",
		};

		var actual = Map.MapObject<CA1_ClaimAdjudication>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredPaymentStatusCode(string paymentStatusCode, bool isValidExpected)
	{
		var subject = new CA1_ClaimAdjudication();
		//Required fields
		//Test Parameters
		subject.PaymentStatusCode = paymentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
