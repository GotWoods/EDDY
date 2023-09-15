using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G82Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G82*A*a*YHVTO7iV0*5*XOwXnaI6c*U*GowKv4*q9vim4*d*wVLM3I*bW*t";

		var expected = new G82_DeliveryReturnBaseRecordIdentifier()
		{
			CreditDebitFlagCode = "A",
			SuppliersDeliveryReturnNumber = "a",
			DunsNumber = "YHVTO7iV0",
			ReceiversLocationNumber = "5",
			DunsNumber2 = "XOwXnaI6c",
			SuppliersLocationNumber = "U",
			PhysicalDeliveryOrReturnDate = "GowKv4",
			ProductOwnershipTransferDate = "q9vim4",
			PurchaseOrderNumber = "d",
			PurchaseOrderDate = "wVLM3I",
			ShipmentMethodOfPayment = "bW",
			CODMethodOfPaymentCode = "t",
		};

		var actual = Map.MapObject<G82_DeliveryReturnBaseRecordIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.SuppliersDeliveryReturnNumber = "a";
		subject.DunsNumber = "YHVTO7iV0";
		subject.ReceiversLocationNumber = "5";
		subject.DunsNumber2 = "XOwXnaI6c";
		subject.SuppliersLocationNumber = "U";
		subject.PhysicalDeliveryOrReturnDate = "GowKv4";
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredSuppliersDeliveryReturnNumber(string suppliersDeliveryReturnNumber, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "A";
		subject.DunsNumber = "YHVTO7iV0";
		subject.ReceiversLocationNumber = "5";
		subject.DunsNumber2 = "XOwXnaI6c";
		subject.SuppliersLocationNumber = "U";
		subject.PhysicalDeliveryOrReturnDate = "GowKv4";
		subject.SuppliersDeliveryReturnNumber = suppliersDeliveryReturnNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YHVTO7iV0", true)]
	public void Validation_RequiredDunsNumber(string dunsNumber, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "A";
		subject.SuppliersDeliveryReturnNumber = "a";
		subject.ReceiversLocationNumber = "5";
		subject.DunsNumber2 = "XOwXnaI6c";
		subject.SuppliersLocationNumber = "U";
		subject.PhysicalDeliveryOrReturnDate = "GowKv4";
		subject.DunsNumber = dunsNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredReceiversLocationNumber(string receiversLocationNumber, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "A";
		subject.SuppliersDeliveryReturnNumber = "a";
		subject.DunsNumber = "YHVTO7iV0";
		subject.DunsNumber2 = "XOwXnaI6c";
		subject.SuppliersLocationNumber = "U";
		subject.PhysicalDeliveryOrReturnDate = "GowKv4";
		subject.ReceiversLocationNumber = receiversLocationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XOwXnaI6c", true)]
	public void Validation_RequiredDunsNumber2(string dunsNumber2, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "A";
		subject.SuppliersDeliveryReturnNumber = "a";
		subject.DunsNumber = "YHVTO7iV0";
		subject.ReceiversLocationNumber = "5";
		subject.SuppliersLocationNumber = "U";
		subject.PhysicalDeliveryOrReturnDate = "GowKv4";
		subject.DunsNumber2 = dunsNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredSuppliersLocationNumber(string suppliersLocationNumber, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "A";
		subject.SuppliersDeliveryReturnNumber = "a";
		subject.DunsNumber = "YHVTO7iV0";
		subject.ReceiversLocationNumber = "5";
		subject.DunsNumber2 = "XOwXnaI6c";
		subject.PhysicalDeliveryOrReturnDate = "GowKv4";
		subject.SuppliersLocationNumber = suppliersLocationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GowKv4", true)]
	public void Validation_RequiredPhysicalDeliveryOrReturnDate(string physicalDeliveryOrReturnDate, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "A";
		subject.SuppliersDeliveryReturnNumber = "a";
		subject.DunsNumber = "YHVTO7iV0";
		subject.ReceiversLocationNumber = "5";
		subject.DunsNumber2 = "XOwXnaI6c";
		subject.SuppliersLocationNumber = "U";
		subject.PhysicalDeliveryOrReturnDate = physicalDeliveryOrReturnDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
