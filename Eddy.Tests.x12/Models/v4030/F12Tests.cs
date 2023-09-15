using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class F12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F12*f*n*BH5oR5Uz*M*n1vaQw40*ZcR*qr5*X";

		var expected = new F12_BasicClaimInformationAutomotive()
		{
			ReferenceIdentification = "f",
			ReferenceIdentification2 = "n",
			Date = "BH5oR5Uz",
			CreditDebitAdjustmentNumber = "M",
			Date2 = "n1vaQw40",
			LaborRate = "ZcR",
			LaborRate2 = "qr5",
			DamageCodeQualifier = "X",
		};

		var actual = Map.MapObject<F12_BasicClaimInformationAutomotive>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification2 = "n";
		subject.Date = "BH5oR5Uz";
		subject.CreditDebitAdjustmentNumber = "M";
		subject.Date2 = "n1vaQw40";
		subject.LaborRate = "ZcR";
		subject.LaborRate2 = "qr5";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "f";
		subject.Date = "BH5oR5Uz";
		subject.CreditDebitAdjustmentNumber = "M";
		subject.Date2 = "n1vaQw40";
		subject.LaborRate = "ZcR";
		subject.LaborRate2 = "qr5";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BH5oR5Uz", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "f";
		subject.ReferenceIdentification2 = "n";
		subject.CreditDebitAdjustmentNumber = "M";
		subject.Date2 = "n1vaQw40";
		subject.LaborRate = "ZcR";
		subject.LaborRate2 = "qr5";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredCreditDebitAdjustmentNumber(string creditDebitAdjustmentNumber, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "f";
		subject.ReferenceIdentification2 = "n";
		subject.Date = "BH5oR5Uz";
		subject.Date2 = "n1vaQw40";
		subject.LaborRate = "ZcR";
		subject.LaborRate2 = "qr5";
		subject.CreditDebitAdjustmentNumber = creditDebitAdjustmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n1vaQw40", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "f";
		subject.ReferenceIdentification2 = "n";
		subject.Date = "BH5oR5Uz";
		subject.CreditDebitAdjustmentNumber = "M";
		subject.LaborRate = "ZcR";
		subject.LaborRate2 = "qr5";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZcR", true)]
	public void Validation_RequiredLaborRate(string laborRate, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "f";
		subject.ReferenceIdentification2 = "n";
		subject.Date = "BH5oR5Uz";
		subject.CreditDebitAdjustmentNumber = "M";
		subject.Date2 = "n1vaQw40";
		subject.LaborRate2 = "qr5";
		subject.LaborRate = laborRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qr5", true)]
	public void Validation_RequiredLaborRate2(string laborRate2, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "f";
		subject.ReferenceIdentification2 = "n";
		subject.Date = "BH5oR5Uz";
		subject.CreditDebitAdjustmentNumber = "M";
		subject.Date2 = "n1vaQw40";
		subject.LaborRate = "ZcR";
		subject.LaborRate2 = laborRate2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
