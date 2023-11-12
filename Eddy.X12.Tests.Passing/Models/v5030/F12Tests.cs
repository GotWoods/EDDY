using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class F12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F12*K*P*l3VdXJqk*v*SAP9JL6N*fzJ*lbE*B";

		var expected = new F12_BasicClaimInformationAutomotive()
		{
			ReferenceIdentification = "K",
			ReferenceIdentification2 = "P",
			Date = "l3VdXJqk",
			CreditDebitAdjustmentNumber = "v",
			Date2 = "SAP9JL6N",
			LaborRate = "fzJ",
			LaborRate2 = "lbE",
			DamageCodeQualifier = "B",
		};

		var actual = Map.MapObject<F12_BasicClaimInformationAutomotive>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification2 = "P";
		subject.Date = "l3VdXJqk";
		subject.CreditDebitAdjustmentNumber = "v";
		subject.Date2 = "SAP9JL6N";
		subject.LaborRate = "fzJ";
		subject.LaborRate2 = "lbE";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "K";
		subject.Date = "l3VdXJqk";
		subject.CreditDebitAdjustmentNumber = "v";
		subject.Date2 = "SAP9JL6N";
		subject.LaborRate = "fzJ";
		subject.LaborRate2 = "lbE";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l3VdXJqk", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "K";
		subject.ReferenceIdentification2 = "P";
		subject.CreditDebitAdjustmentNumber = "v";
		subject.Date2 = "SAP9JL6N";
		subject.LaborRate = "fzJ";
		subject.LaborRate2 = "lbE";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredCreditDebitAdjustmentNumber(string creditDebitAdjustmentNumber, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "K";
		subject.ReferenceIdentification2 = "P";
		subject.Date = "l3VdXJqk";
		subject.Date2 = "SAP9JL6N";
		subject.LaborRate = "fzJ";
		subject.LaborRate2 = "lbE";
		subject.CreditDebitAdjustmentNumber = creditDebitAdjustmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SAP9JL6N", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "K";
		subject.ReferenceIdentification2 = "P";
		subject.Date = "l3VdXJqk";
		subject.CreditDebitAdjustmentNumber = "v";
		subject.LaborRate = "fzJ";
		subject.LaborRate2 = "lbE";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fzJ", true)]
	public void Validation_RequiredLaborRate(string laborRate, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "K";
		subject.ReferenceIdentification2 = "P";
		subject.Date = "l3VdXJqk";
		subject.CreditDebitAdjustmentNumber = "v";
		subject.Date2 = "SAP9JL6N";
		subject.LaborRate2 = "lbE";
		subject.LaborRate = laborRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lbE", true)]
	public void Validation_RequiredLaborRate2(string laborRate2, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceIdentification = "K";
		subject.ReferenceIdentification2 = "P";
		subject.Date = "l3VdXJqk";
		subject.CreditDebitAdjustmentNumber = "v";
		subject.Date2 = "SAP9JL6N";
		subject.LaborRate = "fzJ";
		subject.LaborRate2 = laborRate2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
