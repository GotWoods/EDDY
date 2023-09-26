using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class GRITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GRI*i*H*6c*4*1*2*9*7*X9x*o6F3v1IE*w";

		var expected = new GRI_StatisticalGovernmentInformation()
		{
			ReportedDataIDCode = "i",
			ReportedDataResponse = "H",
			QuantityQualifier = "6c",
			Quantity = 4,
			AmountQualifierCode = "1",
			MonetaryAmount = 2,
			PercentQualifier = "9",
			PercentIntegerFormat = 7,
			DateTimeQualifier = "X9x",
			Date = "o6F3v1IE",
			Description = "w",
		};

		var actual = Map.MapObject<GRI_StatisticalGovernmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
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
	[InlineData("6c", 4, true)]
	[InlineData("6c", 0, false)]
	[InlineData("", 4, true)]
	public void Validation_ARequiresBQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new GRI_StatisticalGovernmentInformation();
		//Required fields
		subject.ReportedDataIDCode = "i";
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("1", 2, true)]
	[InlineData("1", 0, false)]
	[InlineData("", 2, true)]
	public void Validation_ARequiresBAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new GRI_StatisticalGovernmentInformation();
		//Required fields
		subject.ReportedDataIDCode = "i";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("9", 7, true)]
	[InlineData("9", 0, false)]
	[InlineData("", 7, true)]
	public void Validation_ARequiresBPercentQualifier(string percentQualifier, int percentIntegerFormat, bool isValidExpected)
	{
		var subject = new GRI_StatisticalGovernmentInformation();
		//Required fields
		subject.ReportedDataIDCode = "i";
		//Test Parameters
		subject.PercentQualifier = percentQualifier;
		if (percentIntegerFormat > 0) 
			subject.PercentIntegerFormat = percentIntegerFormat;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("X9x", "o6F3v1IE", true)]
	[InlineData("X9x", "", false)]
	[InlineData("", "o6F3v1IE", true)]
	public void Validation_ARequiresBDateTimeQualifier(string dateTimeQualifier, string date, bool isValidExpected)
	{
		var subject = new GRI_StatisticalGovernmentInformation();
		//Required fields
		subject.ReportedDataIDCode = "i";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
