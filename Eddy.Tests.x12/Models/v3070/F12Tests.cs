using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class F12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F12*c*O*LY0tqV*N*ATc9iG*3bF*cuk*z";

		var expected = new F12_BasicClaimInformationAutomotive()
		{
			ReferenceIdentification = "c",
			ReferenceIdentification2 = "O",
			Date = "LY0tqV",
			CreditDebitAdjustmentNumber = "N",
			Date2 = "ATc9iG",
			LaborRate = "3bF",
			LaborRate2 = "cuk",
			DamageCodeQualifier = "z",
		};

		var actual = Map.MapObject<F12_BasicClaimInformationAutomotive>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification2 = "O";
		subject.Date = "LY0tqV";
		subject.CreditDebitAdjustmentNumber = "N";
		subject.Date2 = "ATc9iG";
		subject.LaborRate = "3bF";
		subject.LaborRate2 = "cuk";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "c";
		subject.Date = "LY0tqV";
		subject.CreditDebitAdjustmentNumber = "N";
		subject.Date2 = "ATc9iG";
		subject.LaborRate = "3bF";
		subject.LaborRate2 = "cuk";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LY0tqV", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "c";
		subject.ReferenceIdentification2 = "O";
		subject.CreditDebitAdjustmentNumber = "N";
		subject.Date2 = "ATc9iG";
		subject.LaborRate = "3bF";
		subject.LaborRate2 = "cuk";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredCreditDebitAdjustmentNumber(string creditDebitAdjustmentNumber, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "c";
		subject.ReferenceIdentification2 = "O";
		subject.Date = "LY0tqV";
		subject.Date2 = "ATc9iG";
		subject.LaborRate = "3bF";
		subject.LaborRate2 = "cuk";
		subject.CreditDebitAdjustmentNumber = creditDebitAdjustmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ATc9iG", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "c";
		subject.ReferenceIdentification2 = "O";
		subject.Date = "LY0tqV";
		subject.CreditDebitAdjustmentNumber = "N";
		subject.LaborRate = "3bF";
		subject.LaborRate2 = "cuk";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3bF", true)]
	public void Validation_RequiredLaborRate(string laborRate, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "c";
		subject.ReferenceIdentification2 = "O";
		subject.Date = "LY0tqV";
		subject.CreditDebitAdjustmentNumber = "N";
		subject.Date2 = "ATc9iG";
		subject.LaborRate2 = "cuk";
		subject.LaborRate = laborRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cuk", true)]
	public void Validation_RequiredLaborRate2(string laborRate2, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "c";
		subject.ReferenceIdentification2 = "O";
		subject.Date = "LY0tqV";
		subject.CreditDebitAdjustmentNumber = "N";
		subject.Date2 = "ATc9iG";
		subject.LaborRate = "3bF";
		subject.LaborRate2 = laborRate2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
