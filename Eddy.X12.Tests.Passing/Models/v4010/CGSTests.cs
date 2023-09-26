using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CGSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CGS*P*uL8*deU*s3ePuh5G*ZD4";

		var expected = new CGS_Charge()
		{
			Charge = "P",
			CurrencyCode = "uL8",
			DateTimeQualifier = "deU",
			Date = "s3ePuh5G",
			SpecialChargeOrAllowanceCode = "ZD4",
		};

		var actual = Map.MapObject<CGS_Charge>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("P", "ZD4", true)]
	[InlineData("P", "", false)]
	[InlineData("", "ZD4", false)]
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
			subject.DateTimeQualifier = "deU";
			subject.Date = "s3ePuh5G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("deU", "s3ePuh5G", true)]
	[InlineData("deU", "", false)]
	[InlineData("", "s3ePuh5G", false)]
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
			subject.Charge = "P";
			subject.SpecialChargeOrAllowanceCode = "ZD4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
