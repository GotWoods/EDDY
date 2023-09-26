using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class GRITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GRI*Y*p*KI*3*t*9*i*1*pKd*mhR2NB*b";

		var expected = new GRI_StatisticalGovernmentInformation()
		{
			ReportedDataIDCode = "Y",
			ReportedDataResponse = "p",
			QuantityQualifier = "KI",
			Quantity = 3,
			AmountQualifierCode = "t",
			MonetaryAmount = 9,
			PercentQualifier = "i",
			Percent = 1,
			DateTimeQualifier = "pKd",
			Date = "mhR2NB",
			Description = "b",
		};

		var actual = Map.MapObject<GRI_StatisticalGovernmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
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
	[InlineData("KI", 3, true)]
	[InlineData("KI", 0, false)]
	[InlineData("", 3, true)]
	public void Validation_ARequiresBQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new GRI_StatisticalGovernmentInformation();
		//Required fields
		subject.ReportedDataIDCode = "Y";
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("t", 9, true)]
	[InlineData("t", 0, false)]
	[InlineData("", 9, true)]
	public void Validation_ARequiresBAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new GRI_StatisticalGovernmentInformation();
		//Required fields
		subject.ReportedDataIDCode = "Y";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("i", 1, true)]
	[InlineData("i", 0, false)]
	[InlineData("", 1, true)]
	public void Validation_ARequiresBPercentQualifier(string percentQualifier, int percent, bool isValidExpected)
	{
		var subject = new GRI_StatisticalGovernmentInformation();
		//Required fields
		subject.ReportedDataIDCode = "Y";
		//Test Parameters
		subject.PercentQualifier = percentQualifier;
		if (percent > 0) 
			subject.Percent = percent;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("pKd", "mhR2NB", true)]
	[InlineData("pKd", "", false)]
	[InlineData("", "mhR2NB", true)]
	public void Validation_ARequiresBDateTimeQualifier(string dateTimeQualifier, string date, bool isValidExpected)
	{
		var subject = new GRI_StatisticalGovernmentInformation();
		//Required fields
		subject.ReportedDataIDCode = "Y";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
