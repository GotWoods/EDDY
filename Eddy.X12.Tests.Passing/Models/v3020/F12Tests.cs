using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class F12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F12*U*a*om6n0X*w*eLQsH5*1qS*Ld4*t";

		var expected = new F12_BasicClaimInformationAutomotive()
		{
			ReferenceNumber = "U",
			ReferenceNumber2 = "a",
			Date = "om6n0X",
			CreditDebitAdjustmentNumber = "w",
			Date2 = "eLQsH5",
			LaborRate = "1qS",
			LaborRate2 = "Ld4",
			DamageCodeQualifier = "t",
		};

		var actual = Map.MapObject<F12_BasicClaimInformationAutomotive>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceNumber2 = "a";
		subject.Date = "om6n0X";
		subject.CreditDebitAdjustmentNumber = "w";
		subject.Date2 = "eLQsH5";
		subject.LaborRate = "1qS";
		subject.LaborRate2 = "Ld4";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredReferenceNumber2(string referenceNumber2, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceNumber = "U";
		subject.Date = "om6n0X";
		subject.CreditDebitAdjustmentNumber = "w";
		subject.Date2 = "eLQsH5";
		subject.LaborRate = "1qS";
		subject.LaborRate2 = "Ld4";
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("om6n0X", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceNumber = "U";
		subject.ReferenceNumber2 = "a";
		subject.CreditDebitAdjustmentNumber = "w";
		subject.Date2 = "eLQsH5";
		subject.LaborRate = "1qS";
		subject.LaborRate2 = "Ld4";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredCreditDebitAdjustmentNumber(string creditDebitAdjustmentNumber, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceNumber = "U";
		subject.ReferenceNumber2 = "a";
		subject.Date = "om6n0X";
		subject.Date2 = "eLQsH5";
		subject.LaborRate = "1qS";
		subject.LaborRate2 = "Ld4";
		subject.CreditDebitAdjustmentNumber = creditDebitAdjustmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eLQsH5", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceNumber = "U";
		subject.ReferenceNumber2 = "a";
		subject.Date = "om6n0X";
		subject.CreditDebitAdjustmentNumber = "w";
		subject.LaborRate = "1qS";
		subject.LaborRate2 = "Ld4";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1qS", true)]
	public void Validation_RequiredLaborRate(string laborRate, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceNumber = "U";
		subject.ReferenceNumber2 = "a";
		subject.Date = "om6n0X";
		subject.CreditDebitAdjustmentNumber = "w";
		subject.Date2 = "eLQsH5";
		subject.LaborRate2 = "Ld4";
		subject.LaborRate = laborRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ld4", true)]
	public void Validation_RequiredLaborRate2(string laborRate2, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceNumber = "U";
		subject.ReferenceNumber2 = "a";
		subject.Date = "om6n0X";
		subject.CreditDebitAdjustmentNumber = "w";
		subject.Date2 = "eLQsH5";
		subject.LaborRate = "1qS";
		subject.LaborRate2 = laborRate2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
