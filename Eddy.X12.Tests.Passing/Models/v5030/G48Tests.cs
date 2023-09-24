using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class G48Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G48*u*RVkh7TZY*u*dRMUKhJF*u*1*bL*M*wMfEcbl9";

		var expected = new G48_StatementInvoiceIdentification()
		{
			InvoiceNumber = "u",
			Date = "RVkh7TZY",
			StoreNumber = "u",
			Date2 = "dRMUKhJF",
			PurchaseOrderNumber = "u",
			VendorOrderNumber = "1",
			ReferenceIdentificationQualifier = "bL",
			ReferenceIdentification = "M",
			Date3 = "wMfEcbl9",
		};

		var actual = Map.MapObject<G48_StatementInvoiceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "RVkh7TZY", true)]
	[InlineData("u", "", false)]
	[InlineData("", "RVkh7TZY", false)]
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
			subject.ReferenceIdentificationQualifier = "bL";
			subject.ReferenceIdentification = "M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("u", "bL", true)]
	[InlineData("u", "", true)]
	[InlineData("", "bL", true)]
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
			subject.ReferenceIdentificationQualifier = "bL";
			subject.ReferenceIdentification = "M";
		}

        if (invoiceNumber != "")
            subject.Date = "AAAAAAAA";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("bL", "M", true)]
	[InlineData("bL", "", false)]
	[InlineData("", "M", false)]
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
			subject.Date = "RVkh7TZY";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
