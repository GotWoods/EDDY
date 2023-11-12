using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class G82Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G82*o*I*tNmYYPB0F*u*c0EHe57uo*o*8A4IJIb4*axAz7Wlo*j*SDWUzjWi*4C*b";

		var expected = new G82_DeliveryReturnBaseRecordIdentifier()
		{
			CreditDebitFlagCode = "o",
			SuppliersDeliveryReturnNumber = "I",
			DUNSNumber = "tNmYYPB0F",
			ReceiversLocationNumber = "u",
			DUNSNumber2 = "c0EHe57uo",
			SuppliersLocationNumber = "o",
			PhysicalDeliveryOrReturnDate = "8A4IJIb4",
			ProductOwnershipTransferDate = "axAz7Wlo",
			PurchaseOrderNumber = "j",
			PurchaseOrderDate = "SDWUzjWi",
			ShipmentMethodOfPayment = "4C",
			CODMethodOfPaymentCode = "b",
		};

		var actual = Map.MapObject<G82_DeliveryReturnBaseRecordIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.SuppliersDeliveryReturnNumber = "I";
		subject.DUNSNumber = "tNmYYPB0F";
		subject.ReceiversLocationNumber = "u";
		subject.DUNSNumber2 = "c0EHe57uo";
		subject.SuppliersLocationNumber = "o";
		subject.PhysicalDeliveryOrReturnDate = "8A4IJIb4";
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredSuppliersDeliveryReturnNumber(string suppliersDeliveryReturnNumber, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "o";
		subject.DUNSNumber = "tNmYYPB0F";
		subject.ReceiversLocationNumber = "u";
		subject.DUNSNumber2 = "c0EHe57uo";
		subject.SuppliersLocationNumber = "o";
		subject.PhysicalDeliveryOrReturnDate = "8A4IJIb4";
		subject.SuppliersDeliveryReturnNumber = suppliersDeliveryReturnNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tNmYYPB0F", true)]
	public void Validation_RequiredDUNSNumber(string dUNSNumber, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "o";
		subject.SuppliersDeliveryReturnNumber = "I";
		subject.ReceiversLocationNumber = "u";
		subject.DUNSNumber2 = "c0EHe57uo";
		subject.SuppliersLocationNumber = "o";
		subject.PhysicalDeliveryOrReturnDate = "8A4IJIb4";
		subject.DUNSNumber = dUNSNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredReceiversLocationNumber(string receiversLocationNumber, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "o";
		subject.SuppliersDeliveryReturnNumber = "I";
		subject.DUNSNumber = "tNmYYPB0F";
		subject.DUNSNumber2 = "c0EHe57uo";
		subject.SuppliersLocationNumber = "o";
		subject.PhysicalDeliveryOrReturnDate = "8A4IJIb4";
		subject.ReceiversLocationNumber = receiversLocationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c0EHe57uo", true)]
	public void Validation_RequiredDUNSNumber2(string dUNSNumber2, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "o";
		subject.SuppliersDeliveryReturnNumber = "I";
		subject.DUNSNumber = "tNmYYPB0F";
		subject.ReceiversLocationNumber = "u";
		subject.SuppliersLocationNumber = "o";
		subject.PhysicalDeliveryOrReturnDate = "8A4IJIb4";
		subject.DUNSNumber2 = dUNSNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredSuppliersLocationNumber(string suppliersLocationNumber, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "o";
		subject.SuppliersDeliveryReturnNumber = "I";
		subject.DUNSNumber = "tNmYYPB0F";
		subject.ReceiversLocationNumber = "u";
		subject.DUNSNumber2 = "c0EHe57uo";
		subject.PhysicalDeliveryOrReturnDate = "8A4IJIb4";
		subject.SuppliersLocationNumber = suppliersLocationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8A4IJIb4", true)]
	public void Validation_RequiredPhysicalDeliveryOrReturnDate(string physicalDeliveryOrReturnDate, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "o";
		subject.SuppliersDeliveryReturnNumber = "I";
		subject.DUNSNumber = "tNmYYPB0F";
		subject.ReceiversLocationNumber = "u";
		subject.DUNSNumber2 = "c0EHe57uo";
		subject.SuppliersLocationNumber = "o";
		subject.PhysicalDeliveryOrReturnDate = physicalDeliveryOrReturnDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
