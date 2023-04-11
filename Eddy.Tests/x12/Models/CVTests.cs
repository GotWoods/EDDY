using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CV*D*yu*i*A*9*j*1*6*9*7*7*4*2*6";

		var expected = new CV_CycleSummaryValue()
		{
			LoadEmptyStatusCode = "D",
			PaymentActionCode = "yu",
			CarTypeGroupCode = "i",
			TimePeriodUnitQualifier = "A",
			Quantity = 9,
			MileageSettlementCode = "j",
			Quantity2 = 1,
			Quantity3 = 6,
			MonetaryAmount = 9,
			MonetaryAmount2 = 7,
			MonetaryAmount3 = 7,
			MonetaryAmount4 = 4,
			MonetaryAmount5 = 2,
			PenaltyCode = "6",
		};

		var actual = Map.MapObject<CV_CycleSummaryValue>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validatation_RequiredLoadEmptyStatusCode(string loadEmptyStatusCode, bool isValidExpected)
	{
		var subject = new CV_CycleSummaryValue();
		subject.LoadEmptyStatusCode = loadEmptyStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "A", true)]
	[InlineData(9, "", false)]
	public void Validation_ARequiresBQuantity(decimal quantity, string timePeriodUnitQualifier, bool isValidExpected)
	{
		var subject = new CV_CycleSummaryValue();
		subject.LoadEmptyStatusCode = "D";
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.TimePeriodUnitQualifier = timePeriodUnitQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
