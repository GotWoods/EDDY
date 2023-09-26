using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class CGSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CGS*r*JeV*VbE*9zKI8yQd*mvl";

		var expected = new CGS_Charge()
		{
			AmountCharged = "r",
			CurrencyCode = "JeV",
			DateTimeQualifier = "VbE",
			Date = "9zKI8yQd",
			SpecialChargeOrAllowanceCode = "mvl",
		};

		var actual = Map.MapObject<CGS_Charge>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("r", "mvl", true)]
	[InlineData("r", "", false)]
	[InlineData("", "mvl", false)]
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
			subject.DateTimeQualifier = "VbE";
			subject.Date = "9zKI8yQd";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("VbE", "9zKI8yQd", true)]
	[InlineData("VbE", "", false)]
	[InlineData("", "9zKI8yQd", false)]
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
			subject.AmountCharged = "r";
			subject.SpecialChargeOrAllowanceCode = "mvl";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
