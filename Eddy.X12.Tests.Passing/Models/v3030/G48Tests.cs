using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class G48Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G48*R*D7V2jU*x*K9vI89*s*C*nR*682663*ulVmbT";

		var expected = new G48_StatementInvoiceIdentification()
		{
			InvoiceNumber = "R",
			InvoiceDate = "D7V2jU",
			StoreNumber = "x",
			PurchaseOrderDate = "K9vI89",
			PurchaseOrderNumber = "s",
			VendorOrderNumber = "C",
			ReferenceNumberQualifier = "nR",
			LinkSequenceNumber = 682663,
			Date = "ulVmbT",
		};

		var actual = Map.MapObject<G48_StatementInvoiceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("R", "D7V2jU", true)]
	[InlineData("R", "", false)]
	[InlineData("", "D7V2jU", false)]
	public void Validation_AllAreRequiredInvoiceNumber(string invoiceNumber, string invoiceDate, bool isValidExpected)
	{
		var subject = new G48_StatementInvoiceIdentification();
		//Required fields
		//Test Parameters
		subject.InvoiceNumber = invoiceNumber;
		subject.InvoiceDate = invoiceDate;

        if (invoiceNumber == "")
        {
            subject.ReferenceNumberQualifier = "AA";
        }

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("R", "nR", true)]
	public void Validation_AtLeastOneInvoiceNumber(string invoiceNumber, string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new G48_StatementInvoiceIdentification();
		//Required fields
		//Test Parameters
		subject.InvoiceNumber = invoiceNumber;
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
        if (invoiceNumber != "")
            subject.InvoiceDate = "AAAAAA";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
