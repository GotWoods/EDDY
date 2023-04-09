using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CGSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CGS*b*cwp*6hY*aJDpNohx*wOk";

		var expected = new CGS_Charge()
		{
			AmountCharged = "b",
			CurrencyCode = "cwp",
			DateTimeQualifier = "6hY",
			Date = "aJDpNohx",
			SpecialChargeOrAllowanceCode = "wOk",
		};

		var actual = Map.MapObject<CGS_Charge>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("b", "wOk", true)]
	[InlineData("", "wOk", false)]
	[InlineData("b", "", false)]
	public void Validation_AllAreRequiredAmountCharged(string amountCharged, string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new CGS_Charge();
		subject.AmountCharged = amountCharged;
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("6hY", "aJDpNohx", true)]
	[InlineData("", "aJDpNohx", false)]
	[InlineData("6hY", "", false)]
	public void Validation_AllAreRequiredDateTimeQualifier(string dateTimeQualifier, string date, bool isValidExpected)
	{
		var subject = new CGS_Charge();
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
