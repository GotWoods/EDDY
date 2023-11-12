using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class GRITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GRI*9*W*jz*5*s*3*6*1*A1i*tFAc3OFN*w";

		var expected = new GRI_StatisticalGovernmentInformation()
		{
			ReportedDataIDCode = "9",
			ReportedDataResponse = "W",
			QuantityQualifier = "jz",
			Quantity = 5,
			AmountQualifierCode = "s",
			MonetaryAmount = 3,
			PercentQualifier = "6",
			Percent = 1,
			DateTimeQualifier = "A1i",
			Date = "tFAc3OFN",
			Description = "w",
		};

		var actual = Map.MapObject<GRI_StatisticalGovernmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredReportedDataIDCode(string reportedDataIDCode, bool isValidExpected)
	{
		var subject = new GRI_StatisticalGovernmentInformation();
		//Required fields
		//Test Parameters
		subject.ReportedDataIDCode = reportedDataIDCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("jz", 5, true)]
	[InlineData("jz", 0, false)]
	[InlineData("", 5, true)]
	public void Validation_ARequiresBQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new GRI_StatisticalGovernmentInformation();
		//Required fields
		subject.ReportedDataIDCode = "9";
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("s", 3, true)]
	[InlineData("s", 0, false)]
	[InlineData("", 3, true)]
	public void Validation_ARequiresBAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new GRI_StatisticalGovernmentInformation();
		//Required fields
		subject.ReportedDataIDCode = "9";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("6", 1, true)]
	[InlineData("6", 0, false)]
	[InlineData("", 1, true)]
	public void Validation_ARequiresBPercentQualifier(string percentQualifier, int percent, bool isValidExpected)
	{
		var subject = new GRI_StatisticalGovernmentInformation();
		//Required fields
		subject.ReportedDataIDCode = "9";
		//Test Parameters
		subject.PercentQualifier = percentQualifier;
		if (percent > 0) 
			subject.Percent = percent;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A1i", "tFAc3OFN", true)]
	[InlineData("A1i", "", false)]
	[InlineData("", "tFAc3OFN", true)]
	public void Validation_ARequiresBDateTimeQualifier(string dateTimeQualifier, string date, bool isValidExpected)
	{
		var subject = new GRI_StatisticalGovernmentInformation();
		//Required fields
		subject.ReportedDataIDCode = "9";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
