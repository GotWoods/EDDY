using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G48Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G48*2*WhUAWS*5*Q6RLRM*z*T*y*536935";

		var expected = new G48_StatementInvoiceIdentification()
		{
			InvoiceNumber = "2",
			InvoiceDate = "WhUAWS",
			StoreNumber = "5",
			PurchaseOrderDate = "Q6RLRM",
			PurchaseOrderNumber = "z",
			VendorOrderNumber = "T",
			MasterReferenceLinkNumber = "y",
			LinkSequenceNumber = 536935,
		};

		var actual = Map.MapObject<G48_StatementInvoiceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new G48_StatementInvoiceIdentification();
		//Required fields
		//Test Parameters
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
