using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class G48Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G48*M*QT9Schmo*Z*eaN3JPeQ*F*d*uC*b*9FGelG1U";

		var expected = new G48_StatementInvoiceIdentification()
		{
			InvoiceNumber = "M",
			Date = "QT9Schmo",
			StoreNumber = "Z",
			Date2 = "eaN3JPeQ",
			PurchaseOrderNumber = "F",
			VendorOrderNumber = "d",
			ReferenceIdentificationQualifier = "uC",
			ReferenceIdentification = "b",
			Date3 = "9FGelG1U",
		};

		var actual = Map.MapObject<G48_StatementInvoiceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("M", "QT9Schmo", true)]
	[InlineData("M", "", false)]
	[InlineData("", "QT9Schmo", false)]
	public void Validation_AllAreRequiredInvoiceNumber(string invoiceNumber, string date, bool isValidExpected)
	{
		var subject = new G48_StatementInvoiceIdentification();
		//Required fields
		//Test Parameters
		subject.InvoiceNumber = invoiceNumber;
		subject.Date = date;

        if (invoiceNumber == "")
            subject.ReferenceIdentificationQualifier = "AA";

        //If one filled, all required
        if (!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "uC";
			subject.ReferenceIdentification = "b";
		}
       

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("M", "uC", true)]
	[InlineData("M", "", true)]
	[InlineData("", "uC", true)]
	public void Validation_AtLeastOneInvoiceNumber(string invoiceNumber, string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new G48_StatementInvoiceIdentification();
		//Required fields
		//Test Parameters
		subject.InvoiceNumber = invoiceNumber;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "uC";
			subject.ReferenceIdentification = "b";
		}
        if (invoiceNumber != "")
            subject.Date = "AAAAAAAA";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("uC", "b", true)]
	[InlineData("uC", "", false)]
	[InlineData("", "b", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new G48_StatementInvoiceIdentification();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//At Least one
		subject.InvoiceNumber = "M";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.InvoiceNumber) || !string.IsNullOrEmpty(subject.InvoiceNumber) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.InvoiceNumber = "M";
			subject.Date = "QT9Schmo";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
