using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class G48Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G48*u*OKTGBAYG*w*u8oDozCG*U*Y*4T*n*MQkWH6Ba";

		var expected = new G48_StatementInvoiceIdentification()
		{
			InvoiceNumber = "u",
			Date = "OKTGBAYG",
			StoreNumber = "w",
			Date2 = "u8oDozCG",
			PurchaseOrderNumber = "U",
			VendorOrderNumber = "Y",
			ReferenceIdentificationQualifier = "4T",
			ReferenceIdentification = "n",
			Date3 = "MQkWH6Ba",
		};

		var actual = Map.MapObject<G48_StatementInvoiceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("u", "OKTGBAYG", true)]
	[InlineData("u", "", false)]
	[InlineData("", "OKTGBAYG", false)]
	public void Validation_AllAreRequiredInvoiceNumber(string invoiceNumber, string date, bool isValidExpected)
	{
		var subject = new G48_StatementInvoiceIdentification();
		//Required fields
		//Test Parameters
		subject.InvoiceNumber = invoiceNumber;
		subject.Date = date;
		//If one filled, all required

        if (invoiceNumber == "")
            subject.ReferenceIdentificationQualifier = "AA";

		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "4T";
			subject.ReferenceIdentification = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("u", "4T", true)]
	[InlineData("u", "", true)]
	[InlineData("", "4T", true)]
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
			subject.ReferenceIdentificationQualifier = "4T";
			subject.ReferenceIdentification = "n";
		}

        if (invoiceNumber != "")
            subject.Date = "AAAAAAAA";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4T", "n", true)]
	[InlineData("4T", "", false)]
	[InlineData("", "n", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new G48_StatementInvoiceIdentification();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//At Least one
		subject.InvoiceNumber = "u";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.InvoiceNumber) || !string.IsNullOrEmpty(subject.InvoiceNumber) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.InvoiceNumber = "u";
			subject.Date = "OKTGBAYG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
