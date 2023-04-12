using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TPPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TPP*d*x*sH2EIf3L*u*H*M*0";

		var expected = new TPP_ThirdPartyPayment()
		{
			TaxPaymentTypeCode = "d",
			ReferenceIdentification = "x",
			Date = "sH2EIf3L",
			TaxAmount = "u",
			ReferenceIdentification2 = "H",
			Name = "M",
			ReferenceIdentification3 = "0",
		};

		var actual = Map.MapObject<TPP_ThirdPartyPayment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredTaxPaymentTypeCode(string taxPaymentTypeCode, bool isValidExpected)
	{
		var subject = new TPP_ThirdPartyPayment();
		subject.ReferenceIdentification = "x";
		subject.Date = "sH2EIf3L";
		subject.TaxAmount = "u";
		subject.ReferenceIdentification2 = "H";
		subject.Name = "M";
		subject.TaxPaymentTypeCode = taxPaymentTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new TPP_ThirdPartyPayment();
		subject.TaxPaymentTypeCode = "d";
		subject.Date = "sH2EIf3L";
		subject.TaxAmount = "u";
		subject.ReferenceIdentification2 = "H";
		subject.Name = "M";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sH2EIf3L", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new TPP_ThirdPartyPayment();
		subject.TaxPaymentTypeCode = "d";
		subject.ReferenceIdentification = "x";
		subject.TaxAmount = "u";
		subject.ReferenceIdentification2 = "H";
		subject.Name = "M";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredTaxAmount(string taxAmount, bool isValidExpected)
	{
		var subject = new TPP_ThirdPartyPayment();
		subject.TaxPaymentTypeCode = "d";
		subject.ReferenceIdentification = "x";
		subject.Date = "sH2EIf3L";
		subject.ReferenceIdentification2 = "H";
		subject.Name = "M";
		subject.TaxAmount = taxAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new TPP_ThirdPartyPayment();
		subject.TaxPaymentTypeCode = "d";
		subject.ReferenceIdentification = "x";
		subject.Date = "sH2EIf3L";
		subject.TaxAmount = "u";
		subject.Name = "M";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new TPP_ThirdPartyPayment();
		subject.TaxPaymentTypeCode = "d";
		subject.ReferenceIdentification = "x";
		subject.Date = "sH2EIf3L";
		subject.TaxAmount = "u";
		subject.ReferenceIdentification2 = "H";
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
