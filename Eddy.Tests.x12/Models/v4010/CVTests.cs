using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CV*q*85*1*H*7*J*2*1*3*1*3*9*6*u";

		var expected = new CV_CycleSummaryValue()
		{
			LoadEmptyStatusCode = "q",
			PaymentActionCode = "85",
			CarTypeGroupCode = "1",
			TimePeriodQualifier = "H",
			Quantity = 7,
			MileageSettlementCode = "J",
			Quantity2 = 2,
			Quantity3 = 1,
			MonetaryAmount = 3,
			MonetaryAmount2 = 1,
			MonetaryAmount3 = 3,
			MonetaryAmount4 = 9,
			MonetaryAmount5 = 6,
			PenaltyCode = "u",
		};

		var actual = Map.MapObject<CV_CycleSummaryValue>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
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
	[InlineData(7, "H", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "H", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string timePeriodQualifier, bool isValidExpected)
	{
		var subject = new CV_CycleSummaryValue();
		//Required fields
		subject.LoadEmptyStatusCode = "q";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.TimePeriodQualifier = timePeriodQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
