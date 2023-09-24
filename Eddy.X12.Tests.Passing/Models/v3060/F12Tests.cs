using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class F12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F12*L*5*XWVJnB*o*aMOC3X*Bd7*w7A*o";

		var expected = new F12_BasicClaimInformationAutomotive()
		{
			ReferenceIdentification = "L",
			ReferenceIdentification2 = "5",
			Date = "XWVJnB",
			CreditDebitAdjustmentNumber = "o",
			Date2 = "aMOC3X",
			LaborRate = "Bd7",
			LaborRate2 = "w7A",
			DamageCodeQualifier = "o",
		};

		var actual = Map.MapObject<F12_BasicClaimInformationAutomotive>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification2 = "5";
		subject.Date = "XWVJnB";
		subject.CreditDebitAdjustmentNumber = "o";
		subject.Date2 = "aMOC3X";
		subject.LaborRate = "Bd7";
		subject.LaborRate2 = "w7A";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "L";
		subject.Date = "XWVJnB";
		subject.CreditDebitAdjustmentNumber = "o";
		subject.Date2 = "aMOC3X";
		subject.LaborRate = "Bd7";
		subject.LaborRate2 = "w7A";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XWVJnB", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "L";
		subject.ReferenceIdentification2 = "5";
		subject.CreditDebitAdjustmentNumber = "o";
		subject.Date2 = "aMOC3X";
		subject.LaborRate = "Bd7";
		subject.LaborRate2 = "w7A";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredCreditDebitAdjustmentNumber(string creditDebitAdjustmentNumber, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "L";
		subject.ReferenceIdentification2 = "5";
		subject.Date = "XWVJnB";
		subject.Date2 = "aMOC3X";
		subject.LaborRate = "Bd7";
		subject.LaborRate2 = "w7A";
		subject.CreditDebitAdjustmentNumber = creditDebitAdjustmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aMOC3X", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "L";
		subject.ReferenceIdentification2 = "5";
		subject.Date = "XWVJnB";
		subject.CreditDebitAdjustmentNumber = "o";
		subject.LaborRate = "Bd7";
		subject.LaborRate2 = "w7A";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Bd7", true)]
	public void Validation_RequiredLaborRate(string laborRate, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "L";
		subject.ReferenceIdentification2 = "5";
		subject.Date = "XWVJnB";
		subject.CreditDebitAdjustmentNumber = "o";
		subject.Date2 = "aMOC3X";
		subject.LaborRate2 = "w7A";
		subject.LaborRate = laborRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w7A", true)]
	public void Validation_RequiredLaborRate2(string laborRate2, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "L";
		subject.ReferenceIdentification2 = "5";
		subject.Date = "XWVJnB";
		subject.CreditDebitAdjustmentNumber = "o";
		subject.Date2 = "aMOC3X";
		subject.LaborRate = "Bd7";
		subject.LaborRate2 = laborRate2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
