using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class ITCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ITC++9++V+";

		var expected = new ITC_InstitutionalClaim()
		{
			InvoiceType = null,
			Quantity = "9",
			Admission = null,
			DischargeTypeDescriptionCode = "V",
			BasisOfServiceInformation = null,
		};

		var actual = Map.MapObject<ITC_InstitutionalClaim>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredInvoiceType(string invoiceType, bool isValidExpected)
	{
		var subject = new ITC_InstitutionalClaim();
		//Required fields
		subject.Quantity = "9";
		subject.Admission = new E026_Admission();
		subject.DischargeTypeDescriptionCode = "V";
		//Test Parameters
		if (invoiceType != "") 
			subject.InvoiceType = new E027_InvoiceType();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredQuantity(string quantity, bool isValidExpected)
	{
		var subject = new ITC_InstitutionalClaim();
		//Required fields
		subject.InvoiceType = new E027_InvoiceType();
		subject.Admission = new E026_Admission();
		subject.DischargeTypeDescriptionCode = "V";
		//Test Parameters
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredAdmission(string admission, bool isValidExpected)
	{
		var subject = new ITC_InstitutionalClaim();
		//Required fields
		subject.InvoiceType = new E027_InvoiceType();
		subject.Quantity = "9";
		subject.DischargeTypeDescriptionCode = "V";
		//Test Parameters
		if (admission != "") 
			subject.Admission = new E026_Admission();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredDischargeTypeDescriptionCode(string dischargeTypeDescriptionCode, bool isValidExpected)
	{
		var subject = new ITC_InstitutionalClaim();
		//Required fields
		subject.InvoiceType = new E027_InvoiceType();
		subject.Quantity = "9";
		subject.Admission = new E026_Admission();
		//Test Parameters
		subject.DischargeTypeDescriptionCode = dischargeTypeDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
