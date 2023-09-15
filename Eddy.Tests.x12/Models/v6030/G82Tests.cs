using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class G82Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G82*1*H*EHPaFLPpb*D*S3LJRmZXV*h*deWE8U9w*wINlTDzn*9*I8ajLdEf*Dw*n";

		var expected = new G82_DeliveryReturnBaseRecordIdentifier()
		{
			CreditDebitFlagCode = "1",
			SuppliersDeliveryReturnNumber = "H",
			DUNSNumberCode = "EHPaFLPpb",
			ReceiversLocationNumber = "D",
			DUNSNumberCode2 = "S3LJRmZXV",
			SuppliersLocationNumber = "h",
			PhysicalDeliveryOrReturnDate = "deWE8U9w",
			ProductOwnershipTransferDate = "wINlTDzn",
			PurchaseOrderNumber = "9",
			PurchaseOrderDate = "I8ajLdEf",
			ShipmentMethodOfPaymentCode = "Dw",
			CODMethodOfPaymentCode = "n",
		};

		var actual = Map.MapObject<G82_DeliveryReturnBaseRecordIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.SuppliersDeliveryReturnNumber = "H";
		subject.ReceiversLocationNumber = "D";
		subject.SuppliersLocationNumber = "h";
		subject.PhysicalDeliveryOrReturnDate = "deWE8U9w";
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredSuppliersDeliveryReturnNumber(string suppliersDeliveryReturnNumber, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "1";
		subject.ReceiversLocationNumber = "D";
		subject.SuppliersLocationNumber = "h";
		subject.PhysicalDeliveryOrReturnDate = "deWE8U9w";
		subject.SuppliersDeliveryReturnNumber = suppliersDeliveryReturnNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredReceiversLocationNumber(string receiversLocationNumber, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "1";
		subject.SuppliersDeliveryReturnNumber = "H";
		subject.SuppliersLocationNumber = "h";
		subject.PhysicalDeliveryOrReturnDate = "deWE8U9w";
		subject.ReceiversLocationNumber = receiversLocationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredSuppliersLocationNumber(string suppliersLocationNumber, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "1";
		subject.SuppliersDeliveryReturnNumber = "H";
		subject.ReceiversLocationNumber = "D";
		subject.PhysicalDeliveryOrReturnDate = "deWE8U9w";
		subject.SuppliersLocationNumber = suppliersLocationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("deWE8U9w", true)]
	public void Validation_RequiredPhysicalDeliveryOrReturnDate(string physicalDeliveryOrReturnDate, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "1";
		subject.SuppliersDeliveryReturnNumber = "H";
		subject.ReceiversLocationNumber = "D";
		subject.SuppliersLocationNumber = "h";
		subject.PhysicalDeliveryOrReturnDate = physicalDeliveryOrReturnDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
