using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.Tests.Models.v6050;

public class TPPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TPP*F*i*gEo9AlfD*b*0*9*m";

		var expected = new TPP_ThirdPartyPayment()
		{
			TaxPaymentTypeCode = "F",
			ReferenceIdentification = "i",
			Date = "gEo9AlfD",
			TaxAmount = "b",
			ReferenceIdentification2 = "0",
			Name = "9",
			ReferenceIdentification3 = "m",
		};

		var actual = Map.MapObject<TPP_ThirdPartyPayment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredTaxPaymentTypeCode(string taxPaymentTypeCode, bool isValidExpected)
	{
		var subject = new TPP_ThirdPartyPayment();
		//Required fields
		subject.ReferenceIdentification = "i";
		subject.Date = "gEo9AlfD";
		subject.TaxAmount = "b";
		subject.ReferenceIdentification2 = "0";
		subject.Name = "9";
		//Test Parameters
		subject.TaxPaymentTypeCode = taxPaymentTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new TPP_ThirdPartyPayment();
		//Required fields
		subject.TaxPaymentTypeCode = "F";
		subject.Date = "gEo9AlfD";
		subject.TaxAmount = "b";
		subject.ReferenceIdentification2 = "0";
		subject.Name = "9";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gEo9AlfD", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new TPP_ThirdPartyPayment();
		//Required fields
		subject.TaxPaymentTypeCode = "F";
		subject.ReferenceIdentification = "i";
		subject.TaxAmount = "b";
		subject.ReferenceIdentification2 = "0";
		subject.Name = "9";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredTaxAmount(string taxAmount, bool isValidExpected)
	{
		var subject = new TPP_ThirdPartyPayment();
		//Required fields
		subject.TaxPaymentTypeCode = "F";
		subject.ReferenceIdentification = "i";
		subject.Date = "gEo9AlfD";
		subject.ReferenceIdentification2 = "0";
		subject.Name = "9";
		//Test Parameters
		subject.TaxAmount = taxAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new TPP_ThirdPartyPayment();
		//Required fields
		subject.TaxPaymentTypeCode = "F";
		subject.ReferenceIdentification = "i";
		subject.Date = "gEo9AlfD";
		subject.TaxAmount = "b";
		subject.Name = "9";
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new TPP_ThirdPartyPayment();
		//Required fields
		subject.TaxPaymentTypeCode = "F";
		subject.ReferenceIdentification = "i";
		subject.Date = "gEo9AlfD";
		subject.TaxAmount = "b";
		subject.ReferenceIdentification2 = "0";
		//Test Parameters
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
