using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G16Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G16*Kj9FDg*V*oHGZAd*i*b*Tx*J";

		var expected = new G16_CreditMemoDebitMemo()
		{
			CreditMemoDebitMemoDate = "Kj9FDg",
			CreditMemoDebitMemoNumber = "V",
			InvoiceDate = "oHGZAd",
			InvoiceNumber = "i",
			VendorOrderNumber = "b",
			ReferenceNumberQualifier = "Tx",
			ReferenceNumber = "J",
		};

		var actual = Map.MapObject<G16_CreditMemoDebitMemo>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Kj9FDg", true)]
	public void Validation_RequiredCreditMemoDebitMemoDate(string creditMemoDebitMemoDate, bool isValidExpected)
	{
		var subject = new G16_CreditMemoDebitMemo();
		subject.CreditMemoDebitMemoNumber = "V";
		subject.CreditMemoDebitMemoDate = creditMemoDebitMemoDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredCreditMemoDebitMemoNumber(string creditMemoDebitMemoNumber, bool isValidExpected)
	{
		var subject = new G16_CreditMemoDebitMemo();
		subject.CreditMemoDebitMemoDate = "Kj9FDg";
		subject.CreditMemoDebitMemoNumber = creditMemoDebitMemoNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
