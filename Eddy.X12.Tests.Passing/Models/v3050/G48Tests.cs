using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G48Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G48*O*YD1ySV*t*zimAnF*S*F*gd*231834*lsA5L0";

		var expected = new G48_StatementInvoiceIdentification()
		{
			InvoiceNumber = "O",
			Date = "YD1ySV",
			StoreNumber = "t",
			Date2 = "zimAnF",
			PurchaseOrderNumber = "S",
			VendorOrderNumber = "F",
			ReferenceNumberQualifier = "gd",
			LinkSequenceNumber = 231834,
			Date3 = "lsA5L0",
		};

		var actual = Map.MapObject<G48_StatementInvoiceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("O", "YD1ySV", true)]
	[InlineData("O", "", false)]
	[InlineData("", "YD1ySV", false)]
	public void Validation_AllAreRequiredInvoiceNumber(string invoiceNumber, string date, bool isValidExpected)
	{
		var subject = new G48_StatementInvoiceIdentification();
		//Required fields
		//Test Parameters
		subject.InvoiceNumber = invoiceNumber;
		subject.Date = date;
        if (invoiceNumber == "") 
            subject.ReferenceNumberQualifier = "AA";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("O", "gd", true)]
	public void Validation_AtLeastOneInvoiceNumber(string invoiceNumber, string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new G48_StatementInvoiceIdentification();
		//Required fields
		//Test Parameters
		subject.InvoiceNumber = invoiceNumber;
		subject.ReferenceNumberQualifier = referenceNumberQualifier;

        if (invoiceNumber != "")
            subject.Date = "AAAAAA";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
