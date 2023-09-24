using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G48Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G48*p*gTnol82Y*r*ZBTcNtyB*1*j*9a*W*7pryEmQF";

		var expected = new G48_StatementInvoiceIdentification()
		{
			InvoiceNumber = "p",
			Date = "gTnol82Y",
			StoreNumber = "r",
			Date2 = "ZBTcNtyB",
			PurchaseOrderNumber = "1",
			VendorOrderNumber = "j",
			ReferenceIdentificationQualifier = "9a",
			ReferenceIdentification = "W",
			Date3 = "7pryEmQF",
		};

		var actual = Map.MapObject<G48_StatementInvoiceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("p", "gTnol82Y", true)]
	[InlineData("", "gTnol82Y", false)]
	[InlineData("p", "", false)]
	public void Validation_AllAreRequiredInvoiceNumber(string invoiceNumber, string date, bool isValidExpected)
	{
		var subject = new G48_StatementInvoiceIdentification();
		subject.InvoiceNumber = invoiceNumber;
		subject.Date = date;

		if (invoiceNumber == "")
		{
			subject.ReferenceIdentificationQualifier = "AB";
			subject.ReferenceIdentification = "AB";
		}


		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("p","9a", true)]
	[InlineData("", "9a", true)]
	[InlineData("p", "", true)]
	public void Validation_AtLeastOneInvoiceNumber(string invoiceNumber, string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new G48_StatementInvoiceIdentification();
		subject.InvoiceNumber = invoiceNumber;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;

		if (referenceIdentificationQualifier != "")
			subject.ReferenceIdentification = "AB";

		if (invoiceNumber!= "")
            subject.Date = "20020101";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("9a", "W", true)]
	[InlineData("", "W", false)]
	[InlineData("9a", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new G48_StatementInvoiceIdentification();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		subject.InvoiceNumber = "AB";
		subject.Date = "20020101";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
