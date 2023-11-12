using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class CVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CV*M*rO*p*f*4*X*9*4*2*2*3*5*8*q";

		var expected = new CV_CycleSummaryValue()
		{
			LoadEmptyStatusCode = "M",
			PaymentActionCode = "rO",
			CarTypeGroupCode = "p",
			TimePeriodQualifier = "f",
			Quantity = 4,
			MileageSettlementCode = "X",
			Quantity2 = 9,
			Quantity3 = 4,
			MonetaryAmount = 2,
			MonetaryAmount2 = 2,
			MonetaryAmount3 = 3,
			MonetaryAmount4 = 5,
			MonetaryAmount5 = 8,
			PenaltyCode = "q",
		};

		var actual = Map.MapObject<CV_CycleSummaryValue>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
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
	[InlineData(4, "f", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "f", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string timePeriodQualifier, bool isValidExpected)
	{
		var subject = new CV_CycleSummaryValue();
		//Required fields
		subject.LoadEmptyStatusCode = "M";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.TimePeriodQualifier = timePeriodQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
