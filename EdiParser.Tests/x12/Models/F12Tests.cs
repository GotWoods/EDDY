using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class F12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F12*s*5*JPpMRYAY*4*uPLrDzTA*iQx*uSU*c";

		var expected = new F12_BasicClaimInformationAutomotive()
		{
			ReferenceIdentification = "s",
			ReferenceIdentification2 = "5",
			Date = "JPpMRYAY",
			CreditDebitAdjustmentNumber = "4",
			Date2 = "uPLrDzTA",
			LaborRate = "iQx",
			LaborRate2 = "uSU",
			DamageCodeQualifier = "c",
		};

		var actual = Map.MapObject<F12_BasicClaimInformationAutomotive>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validatation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification2 = "5";
		subject.Date = "JPpMRYAY";
		subject.CreditDebitAdjustmentNumber = "4";
		subject.Date2 = "uPLrDzTA";
		subject.LaborRate = "iQx";
		subject.LaborRate2 = "uSU";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validatation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "s";
		subject.Date = "JPpMRYAY";
		subject.CreditDebitAdjustmentNumber = "4";
		subject.Date2 = "uPLrDzTA";
		subject.LaborRate = "iQx";
		subject.LaborRate2 = "uSU";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JPpMRYAY", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "s";
		subject.ReferenceIdentification2 = "5";
		subject.CreditDebitAdjustmentNumber = "4";
		subject.Date2 = "uPLrDzTA";
		subject.LaborRate = "iQx";
		subject.LaborRate2 = "uSU";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validatation_RequiredCreditDebitAdjustmentNumber(string creditDebitAdjustmentNumber, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "s";
		subject.ReferenceIdentification2 = "5";
		subject.Date = "JPpMRYAY";
		subject.Date2 = "uPLrDzTA";
		subject.LaborRate = "iQx";
		subject.LaborRate2 = "uSU";
		subject.CreditDebitAdjustmentNumber = creditDebitAdjustmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uPLrDzTA", true)]
	public void Validatation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "s";
		subject.ReferenceIdentification2 = "5";
		subject.Date = "JPpMRYAY";
		subject.CreditDebitAdjustmentNumber = "4";
		subject.LaborRate = "iQx";
		subject.LaborRate2 = "uSU";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iQx", true)]
	public void Validatation_RequiredLaborRate(string laborRate, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "s";
		subject.ReferenceIdentification2 = "5";
		subject.Date = "JPpMRYAY";
		subject.CreditDebitAdjustmentNumber = "4";
		subject.Date2 = "uPLrDzTA";
		subject.LaborRate2 = "uSU";
		subject.LaborRate = laborRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uSU", true)]
	public void Validatation_RequiredLaborRate2(string laborRate2, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "s";
		subject.ReferenceIdentification2 = "5";
		subject.Date = "JPpMRYAY";
		subject.CreditDebitAdjustmentNumber = "4";
		subject.Date2 = "uPLrDzTA";
		subject.LaborRate = "iQx";
		subject.LaborRate2 = laborRate2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
