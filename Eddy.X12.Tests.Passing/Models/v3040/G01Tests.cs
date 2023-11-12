using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class G01Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G01*phm6Gt*F*AwqpnB*L*4*e*914997*ee";

		var expected = new G01_InvoiceIdentification()
		{
			InvoiceDate = "phm6Gt",
			InvoiceNumber = "F",
			PurchaseOrderDate = "AwqpnB",
			PurchaseOrderNumber = "L",
			VendorOrderNumber = "4",
			MasterReferenceLinkNumber = "e",
			LinkSequenceNumber = 914997,
			TransactionTypeCode = "ee",
		};

		var actual = Map.MapObject<G01_InvoiceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("phm6Gt", true)]
	public void Validation_RequiredInvoiceDate(string invoiceDate, bool isValidExpected)
	{
		var subject = new G01_InvoiceIdentification();
		subject.InvoiceNumber = "F";
		subject.InvoiceDate = invoiceDate;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "e";
			subject.LinkSequenceNumber = 914997;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new G01_InvoiceIdentification();
		subject.InvoiceDate = "phm6Gt";
		subject.InvoiceNumber = invoiceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "e";
			subject.LinkSequenceNumber = 914997;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("e", 914997, true)]
	[InlineData("e", 0, false)]
	[InlineData("", 914997, false)]
	public void Validation_AllAreRequiredMasterReferenceLinkNumber(string masterReferenceLinkNumber, int linkSequenceNumber, bool isValidExpected)
	{
		var subject = new G01_InvoiceIdentification();
		subject.InvoiceDate = "phm6Gt";
		subject.InvoiceNumber = "F";
		subject.MasterReferenceLinkNumber = masterReferenceLinkNumber;
		if (linkSequenceNumber > 0)
			subject.LinkSequenceNumber = linkSequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
