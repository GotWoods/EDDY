using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class GRITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GRI*b*U*TV*7*8*2*F*8*CbE*qdvn6oII*y";

		var expected = new GRI_StatisticalGovernmentInformation()
		{
			ReportedDataIDCode = "b",
			ReportedDataResponse = "U",
			QuantityQualifier = "TV",
			Quantity = 7,
			AmountQualifierCode = "8",
			MonetaryAmount = 2,
			PercentQualifier = "F",
			PercentIntegerFormat = 8,
			DateTimeQualifier = "CbE",
			Date = "qdvn6oII",
			Description = "y",
		};

		var actual = Map.MapObject<GRI_StatisticalGovernmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredReportedDataIDCode(string reportedDataIDCode, bool isValidExpected)
	{
		var subject = new GRI_StatisticalGovernmentInformation();
		subject.ReportedDataIDCode = reportedDataIDCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 7, true)]
	[InlineData("TV", 0, false)]
	public void Validation_ARequiresBQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new GRI_StatisticalGovernmentInformation();
		subject.ReportedDataIDCode = "b";
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 2, true)]
	[InlineData("8", 0, false)]
	public void Validation_ARequiresBAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new GRI_StatisticalGovernmentInformation();
		subject.ReportedDataIDCode = "b";
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 8, true)]
	[InlineData("F", 0, false)]
	public void Validation_ARequiresBPercentQualifier(string percentQualifier, int percentIntegerFormat, bool isValidExpected)
	{
		var subject = new GRI_StatisticalGovernmentInformation();
		subject.ReportedDataIDCode = "b";
		subject.PercentQualifier = percentQualifier;
		if (percentIntegerFormat > 0)
		subject.PercentIntegerFormat = percentIntegerFormat;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "qdvn6oII", true)]
	[InlineData("CbE", "", false)]
	public void Validation_ARequiresBDateTimeQualifier(string dateTimeQualifier, string date, bool isValidExpected)
	{
		var subject = new GRI_StatisticalGovernmentInformation();
		subject.ReportedDataIDCode = "b";
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
