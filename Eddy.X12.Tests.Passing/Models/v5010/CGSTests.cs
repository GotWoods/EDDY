using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class CGSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CGS*I*qXv*Ggo*7Csmu3g6*vWo";

		var expected = new CGS_Charge()
		{
			AmountCharged = "I",
			CurrencyCode = "qXv",
			DateTimeQualifier = "Ggo",
			Date = "7Csmu3g6",
			SpecialChargeOrAllowanceCode = "vWo",
		};

		var actual = Map.MapObject<CGS_Charge>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("I", "vWo", true)]
	[InlineData("I", "", false)]
	[InlineData("", "vWo", false)]
	public void Validation_AllAreRequiredAmountCharged(string amountCharged, string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new CGS_Charge();
		//Required fields
		//Test Parameters
		subject.AmountCharged = amountCharged;
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateTimeQualifier = "Ggo";
			subject.Date = "7Csmu3g6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ggo", "7Csmu3g6", true)]
	[InlineData("Ggo", "", false)]
	[InlineData("", "7Csmu3g6", false)]
	public void Validation_AllAreRequiredDateTimeQualifier(string dateTimeQualifier, string date, bool isValidExpected)
	{
		var subject = new CGS_Charge();
		//Required fields
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountCharged) || !string.IsNullOrEmpty(subject.AmountCharged) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.AmountCharged = "I";
			subject.SpecialChargeOrAllowanceCode = "vWo";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
