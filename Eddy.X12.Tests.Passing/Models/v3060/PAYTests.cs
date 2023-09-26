using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class PAYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAY*l*1*2*6*4*8**6**2*1*7*7*t*8*4*9*2*7*6*R*X";

		var expected = new PAY_AdjustablePaymentDescription()
		{
			PaymentAdjustmentCode = "l",
			MonetaryAmount = 1,
			Percent = 2,
			MonetaryAmount2 = 6,
			Percent2 = 4,
			MonetaryAmount3 = 8,
			CompositeUnitOfMeasure = null,
			Quantity = 6,
			CompositeUnitOfMeasure2 = null,
			Quantity2 = 2,
			Percent3 = 1,
			Percent4 = 7,
			MonetaryAmount4 = 7,
			YesNoConditionOrResponseCode = "t",
			Quantity3 = 8,
			Percent5 = 4,
			MonetaryAmount5 = 9,
			NegativeAmortizationQualifier = "2",
			Percent6 = 7,
			MonetaryAmount6 = 6,
			NegativeAmoritzationCapSourceCode = "R",
			YesNoConditionOrResponseCode2 = "X",
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
