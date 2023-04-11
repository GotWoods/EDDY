using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G82Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G82*o*I*KLGDTZxmg*d*mIVPec6QS*u*i8pDadrx*2m0xyqyP*i*jNNdZpFj*sg*m*aG";

		var expected = new G82_DeliveryReturnBaseRecordIdentifier()
		{
			CreditDebitFlagCode = "o",
			SuppliersDeliveryReturnNumber = "I",
			DUNSNumberCode = "KLGDTZxmg",
			ReceiversLocationNumber = "d",
			DUNSNumberCode2 = "mIVPec6QS",
			SuppliersLocationNumber = "u",
			PhysicalDeliveryOrReturnDate = "i8pDadrx",
			ProductOwnershipTransferDate = "2m0xyqyP",
			PurchaseOrderNumber = "i",
			PurchaseOrderDate = "jNNdZpFj",
			ShipmentMethodOfPaymentCode = "sg",
			CODMethodOfPaymentCode = "m",
			ConditionIndicatorCode = "aG",
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
		subject.ReceiversLocationNumber = "d";
		subject.SuppliersLocationNumber = "u";
		subject.PhysicalDeliveryOrReturnDate = "i8pDadrx";
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
		subject.ReceiversLocationNumber = "d";
		subject.SuppliersLocationNumber = "u";
		subject.PhysicalDeliveryOrReturnDate = "i8pDadrx";
		subject.SuppliersDeliveryReturnNumber = suppliersDeliveryReturnNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredReceiversLocationNumber(string receiversLocationNumber, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "o";
		subject.SuppliersDeliveryReturnNumber = "I";
		subject.SuppliersLocationNumber = "u";
		subject.PhysicalDeliveryOrReturnDate = "i8pDadrx";
		subject.ReceiversLocationNumber = receiversLocationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredSuppliersLocationNumber(string suppliersLocationNumber, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "o";
		subject.SuppliersDeliveryReturnNumber = "I";
		subject.ReceiversLocationNumber = "d";
		subject.PhysicalDeliveryOrReturnDate = "i8pDadrx";
		subject.SuppliersLocationNumber = suppliersLocationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i8pDadrx", true)]
	public void Validation_RequiredPhysicalDeliveryOrReturnDate(string physicalDeliveryOrReturnDate, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "o";
		subject.SuppliersDeliveryReturnNumber = "I";
		subject.ReceiversLocationNumber = "d";
		subject.SuppliersLocationNumber = "u";
		subject.PhysicalDeliveryOrReturnDate = physicalDeliveryOrReturnDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
