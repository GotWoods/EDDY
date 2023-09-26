using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class PAYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAY*8*4*8*4*6*5**7**6*8*1*6*R*8*8*6*k*8*1*l*c";

		var expected = new PAY_AdjustablePaymentDescription()
		{
			PaymentAdjustmentCode = "8",
			MonetaryAmount = 4,
			PercentageAsDecimal = 8,
			MonetaryAmount2 = 4,
			PercentageAsDecimal2 = 6,
			MonetaryAmount3 = 5,
			CompositeUnitOfMeasure = null,
			Quantity = 7,
			CompositeUnitOfMeasure2 = null,
			Quantity2 = 6,
			PercentageAsDecimal3 = 8,
			PercentageAsDecimal4 = 1,
			MonetaryAmount4 = 6,
			YesNoConditionOrResponseCode = "R",
			Quantity3 = 8,
			PercentageAsDecimal5 = 8,
			MonetaryAmount5 = 6,
			NegativeAmortizationQualifier = "k",
			PercentageAsDecimal6 = 8,
			MonetaryAmount6 = 1,
			NegativeAmortizationCapSourceCode = "l",
			YesNoConditionOrResponseCode2 = "c",
		};

		var actual = Map.MapObject<PAY_AdjustablePaymentDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredPaymentAdjustmentCode(string paymentAdjustmentCode, bool isValidExpected)
	{
		var subject = new PAY_AdjustablePaymentDescription();
		//Required fields
		//Test Parameters
		subject.PaymentAdjustmentCode = paymentAdjustmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
