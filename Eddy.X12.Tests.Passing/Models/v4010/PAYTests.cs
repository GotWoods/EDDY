using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PAYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAY*x*2*5*3*6*7**7**9*3*7*9*v*5*4*1*J*3*1*q*V";

		var expected = new PAY_AdjustablePaymentDescription()
		{
			PaymentAdjustmentCode = "x",
			MonetaryAmount = 2,
			Percent = 5,
			MonetaryAmount2 = 3,
			Percent2 = 6,
			MonetaryAmount3 = 7,
			CompositeUnitOfMeasure = null,
			Quantity = 7,
			CompositeUnitOfMeasure2 = null,
			Quantity2 = 9,
			Percent3 = 3,
			Percent4 = 7,
			MonetaryAmount4 = 9,
			YesNoConditionOrResponseCode = "v",
			Quantity3 = 5,
			Percent5 = 4,
			MonetaryAmount5 = 1,
			NegativeAmortizationQualifier = "J",
			Percent6 = 3,
			MonetaryAmount6 = 1,
			NegativeAmortizationCapSourceCode = "q",
			YesNoConditionOrResponseCode2 = "V",
		};

		var actual = Map.MapObject<PAY_AdjustablePaymentDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredPaymentAdjustmentCode(string paymentAdjustmentCode, bool isValidExpected)
	{
		var subject = new PAY_AdjustablePaymentDescription();
		//Required fields
		//Test Parameters
		subject.PaymentAdjustmentCode = paymentAdjustmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
