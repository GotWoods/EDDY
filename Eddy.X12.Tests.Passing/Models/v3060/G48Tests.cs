using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class G48Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G48*5*cpemr9*4*GkQItt*a*v*WM*7*4Jn7kl";

		var expected = new G48_StatementInvoiceIdentification()
		{
			InvoiceNumber = "5",
			Date = "cpemr9",
			StoreNumber = "4",
			Date2 = "GkQItt",
			PurchaseOrderNumber = "a",
			VendorOrderNumber = "v",
			ReferenceIdentificationQualifier = "WM",
			ReferenceIdentification = "7",
			Date3 = "4Jn7kl",
		};

		var actual = Map.MapObject<G48_StatementInvoiceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5", "cpemr9", true)]
	[InlineData("5", "", false)]
	[InlineData("", "cpemr9", false)]
	public void Validation_AllAreRequiredInvoiceNumber(string invoiceNumber, string date, bool isValidExpected)
	{
		var subject = new G48_StatementInvoiceIdentification();
		//Required fields
		//Test Parameters
		subject.InvoiceNumber = invoiceNumber;
		subject.Date = date;
        if (invoiceNumber == "")
        {
            subject.ReferenceIdentificationQualifier = "WM";
        }

        //If one filled, all required
        if (!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "WM";
			subject.ReferenceIdentification = "7";
		}

      

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("5", "WM", true)]
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
			subject.ReferenceIdentificationQualifier = "WM";
			subject.ReferenceIdentification = "7";
		}

        if (invoiceNumber != "")
            subject.Date = "AAAAAA";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("WM", "7", true)]
	[InlineData("WM", "", false)]
	[InlineData("", "7", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new G48_StatementInvoiceIdentification();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//At Least one
		subject.InvoiceNumber = "5";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.InvoiceNumber) || !string.IsNullOrEmpty(subject.InvoiceNumber) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.InvoiceNumber = "5";
			subject.Date = "cpemr9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
