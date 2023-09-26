using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class CVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CV*1*jN*C*3*7*F*1*5*8*6*1*5*3*R";

		var expected = new CV_CycleSummaryValue()
		{
			LoadEmptyStatusCode = "1",
			PaymentActionCode = "jN",
			CarTypeGroupCode = "C",
			TimePeriodUnitQualifier = "3",
			Quantity = 7,
			MileageSettlementCode = "F",
			Quantity2 = 1,
			Quantity3 = 5,
			MonetaryAmount = 8,
			MonetaryAmount2 = 6,
			MonetaryAmount3 = 1,
			MonetaryAmount4 = 5,
			MonetaryAmount5 = 3,
			PenaltyCode = "R",
		};

		var actual = Map.MapObject<CV_CycleSummaryValue>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredLoadEmptyStatusCode(string loadEmptyStatusCode, bool isValidExpected)
	{
		var subject = new CV_CycleSummaryValue();
		//Required fields
		//Test Parameters
		subject.LoadEmptyStatusCode = loadEmptyStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "3", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "3", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string timePeriodUnitQualifier, bool isValidExpected)
	{
		var subject = new CV_CycleSummaryValue();
		//Required fields
		subject.LoadEmptyStatusCode = "1";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.TimePeriodUnitQualifier = timePeriodUnitQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
