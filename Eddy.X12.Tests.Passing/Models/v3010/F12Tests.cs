using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class F12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F12*f*C*kdOGnA*c*BXwr6X*oOL*ZkV*f";

		var expected = new F12_BasicClaimInformationAutomotive()
		{
			ReferenceNumber = "f",
			ReferenceNumber2 = "C",
			Date = "kdOGnA",
			CreditMemoDebitMemoNumber = "c",
			Date2 = "BXwr6X",
			LaborRate = "oOL",
			LaborRate2 = "ZkV",
			DamageCodeQualifier = "f",
		};

		var actual = Map.MapObject<F12_BasicClaimInformationAutomotive>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceNumber2 = "C";
		subject.Date = "kdOGnA";
		subject.CreditMemoDebitMemoNumber = "c";
		subject.Date2 = "BXwr6X";
		subject.LaborRate = "oOL";
		subject.LaborRate2 = "ZkV";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredReferenceNumber2(string referenceNumber2, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceNumber = "f";
		subject.Date = "kdOGnA";
		subject.CreditMemoDebitMemoNumber = "c";
		subject.Date2 = "BXwr6X";
		subject.LaborRate = "oOL";
		subject.LaborRate2 = "ZkV";
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kdOGnA", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceNumber = "f";
		subject.ReferenceNumber2 = "C";
		subject.CreditMemoDebitMemoNumber = "c";
		subject.Date2 = "BXwr6X";
		subject.LaborRate = "oOL";
		subject.LaborRate2 = "ZkV";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredCreditMemoDebitMemoNumber(string creditMemoDebitMemoNumber, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceNumber = "f";
		subject.ReferenceNumber2 = "C";
		subject.Date = "kdOGnA";
		subject.Date2 = "BXwr6X";
		subject.LaborRate = "oOL";
		subject.LaborRate2 = "ZkV";
		subject.CreditMemoDebitMemoNumber = creditMemoDebitMemoNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BXwr6X", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceNumber = "f";
		subject.ReferenceNumber2 = "C";
		subject.Date = "kdOGnA";
		subject.CreditMemoDebitMemoNumber = "c";
		subject.LaborRate = "oOL";
		subject.LaborRate2 = "ZkV";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oOL", true)]
	public void Validation_RequiredLaborRate(string laborRate, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceNumber = "f";
		subject.ReferenceNumber2 = "C";
		subject.Date = "kdOGnA";
		subject.CreditMemoDebitMemoNumber = "c";
		subject.Date2 = "BXwr6X";
		subject.LaborRate2 = "ZkV";
		subject.LaborRate = laborRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZkV", true)]
	public void Validation_RequiredLaborRate2(string laborRate2, bool isValidExpected)
	{
		var subject = new F12_BasicClaimInformationAutomotive();
		subject.ReferenceNumber = "f";
		subject.ReferenceNumber2 = "C";
		subject.Date = "kdOGnA";
		subject.CreditMemoDebitMemoNumber = "c";
		subject.Date2 = "BXwr6X";
		subject.LaborRate = "oOL";
		subject.LaborRate2 = laborRate2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
