using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class F12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F12*M*z*yfKd2x1v*1*t8jzDNE3*gIt*y3e*V";

		var expected = new F12_BasicClaimInformationAutomotive()
		{
			ReferenceIdentification = "M",
			ReferenceIdentification2 = "z",
			Date = "yfKd2x1v",
			CreditDebitAdjustmentNumber = "1",
			Date2 = "t8jzDNE3",
			LaborRate = "gIt",
			LaborRate2 = "y3e",
			DamageCodeQualifier = "V",
		};

		var actual = Map.MapObject<F12_BasicClaimInformationAutomotive>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification2 = "z";
		subject.Date = "yfKd2x1v";
		subject.CreditDebitAdjustmentNumber = "1";
		subject.Date2 = "t8jzDNE3";
		subject.LaborRate = "gIt";
		subject.LaborRate2 = "y3e";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "M";
		subject.Date = "yfKd2x1v";
		subject.CreditDebitAdjustmentNumber = "1";
		subject.Date2 = "t8jzDNE3";
		subject.LaborRate = "gIt";
		subject.LaborRate2 = "y3e";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yfKd2x1v", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "M";
		subject.ReferenceIdentification2 = "z";
		subject.CreditDebitAdjustmentNumber = "1";
		subject.Date2 = "t8jzDNE3";
		subject.LaborRate = "gIt";
		subject.LaborRate2 = "y3e";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredCreditDebitAdjustmentNumber(string creditDebitAdjustmentNumber, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "M";
		subject.ReferenceIdentification2 = "z";
		subject.Date = "yfKd2x1v";
		subject.Date2 = "t8jzDNE3";
		subject.LaborRate = "gIt";
		subject.LaborRate2 = "y3e";
		subject.CreditDebitAdjustmentNumber = creditDebitAdjustmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t8jzDNE3", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "M";
		subject.ReferenceIdentification2 = "z";
		subject.Date = "yfKd2x1v";
		subject.CreditDebitAdjustmentNumber = "1";
		subject.LaborRate = "gIt";
		subject.LaborRate2 = "y3e";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gIt", true)]
	public void Validation_RequiredLaborRate(string laborRate, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "M";
		subject.ReferenceIdentification2 = "z";
		subject.Date = "yfKd2x1v";
		subject.CreditDebitAdjustmentNumber = "1";
		subject.Date2 = "t8jzDNE3";
		subject.LaborRate2 = "y3e";
		subject.LaborRate = laborRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y3e", true)]
	public void Validation_RequiredLaborRate2(string laborRate2, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "M";
		subject.ReferenceIdentification2 = "z";
		subject.Date = "yfKd2x1v";
		subject.CreditDebitAdjustmentNumber = "1";
		subject.Date2 = "t8jzDNE3";
		subject.LaborRate = "gIt";
		subject.LaborRate2 = laborRate2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
