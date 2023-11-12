using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class CGSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CGS*i*9Ca*EHn*aApHMS*HAh";

		var expected = new CGS_Charge()
		{
			Charge = "i",
			CurrencyCode = "9Ca",
			DateTimeQualifier = "EHn",
			Date = "aApHMS",
			SpecialChargeOrAllowanceCode = "HAh",
		};

		var actual = Map.MapObject<CGS_Charge>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "HAh", true)]
	[InlineData("i", "", false)]
	[InlineData("", "HAh", false)]
	public void Validation_AllAreRequiredCharge(string charge, string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new CGS_Charge();
		//Required fields
		//Test Parameters
		subject.Charge = charge;
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateTimeQualifier = "EHn";
			subject.Date = "aApHMS";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("EHn", "aApHMS", true)]
	[InlineData("EHn", "", false)]
	[InlineData("", "aApHMS", false)]
	public void Validation_AllAreRequiredDateTimeQualifier(string dateTimeQualifier, string date, bool isValidExpected)
	{
		var subject = new CGS_Charge();
		//Required fields
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Charge) || !string.IsNullOrEmpty(subject.Charge) || !string.IsNullOrEmpty(subject.SpecialChargeOrAllowanceCode))
		{
			subject.Charge = "i";
			subject.SpecialChargeOrAllowanceCode = "HAh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
