using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G16Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G16*lNTOiF*1*MRDQRF*u*M*FZ*I";

		var expected = new G16_CreditMemoDebitMemo()
		{
			CreditMemoDebitMemoDate = "lNTOiF",
			CreditDebitAdjustmentNumber = "1",
			InvoiceDate = "MRDQRF",
			InvoiceNumber = "u",
			VendorOrderNumber = "M",
			ReferenceNumberQualifier = "FZ",
			ReferenceNumber = "I",
		};

		var actual = Map.MapObject<G16_CreditMemoDebitMemo>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lNTOiF", true)]
	public void Validation_RequiredCreditMemoDebitMemoDate(string creditMemoDebitMemoDate, bool isValidExpected)
	{
		var subject = new G16_CreditMemoDebitMemo();
		subject.CreditDebitAdjustmentNumber = "1";
		subject.CreditMemoDebitMemoDate = creditMemoDebitMemoDate;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "FZ";
			subject.ReferenceNumber = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredCreditDebitAdjustmentNumber(string creditDebitAdjustmentNumber, bool isValidExpected)
	{
		var subject = new G16_CreditMemoDebitMemo();
		subject.CreditMemoDebitMemoDate = "lNTOiF";
		subject.CreditDebitAdjustmentNumber = creditDebitAdjustmentNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "FZ";
			subject.ReferenceNumber = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("FZ", "I", true)]
	[InlineData("FZ", "", false)]
	[InlineData("", "I", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new G16_CreditMemoDebitMemo();
		subject.CreditMemoDebitMemoDate = "lNTOiF";
		subject.CreditDebitAdjustmentNumber = "1";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
