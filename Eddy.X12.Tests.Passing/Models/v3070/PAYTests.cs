using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class PAYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAY*l*7*4*5*3*6**6**2*3*7*7*I*9*1*7*T*8*4*G*D";

		var expected = new PAY_AdjustablePaymentDescription()
		{
			PaymentAdjustmentCode = "l",
			MonetaryAmount = 7,
			Percent = 4,
			MonetaryAmount2 = 5,
			Percent2 = 3,
			MonetaryAmount3 = 6,
			CompositeUnitOfMeasure = null,
			Quantity = 6,
			CompositeUnitOfMeasure2 = null,
			Quantity2 = 2,
			Percent3 = 3,
			Percent4 = 7,
			MonetaryAmount4 = 7,
			YesNoConditionOrResponseCode = "I",
			Quantity3 = 9,
			Percent5 = 1,
			MonetaryAmount5 = 7,
			NegativeAmortizationQualifier = "T",
			Percent6 = 8,
			MonetaryAmount6 = 4,
			NegativeAmortizationCapSourceCode = "G",
			YesNoConditionOrResponseCode2 = "D",
		};

		var actual = Map.MapObject<PAY_AdjustablePaymentDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredPaymentAdjustmentCode(string paymentAdjustmentCode, bool isValidExpected)
	{
		var subject = new PAY_AdjustablePaymentDescription();
		//Required fields
		//Test Parameters
		subject.PaymentAdjustmentCode = paymentAdjustmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
