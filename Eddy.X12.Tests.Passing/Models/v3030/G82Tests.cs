using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class G82Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G82*q*w*7McoZqgVd*I*BBGIgsn1k*1*3RCIYR*7zhuBH*K*Nnjb9D*x0*D";

		var expected = new G82_DeliveryReturnBaseRecordIdentifier()
		{
			CreditDebitFlagCode = "q",
			SuppliersDeliveryReturnNumber = "w",
			DUNSNumber = "7McoZqgVd",
			ReceiversLocationNumber = "I",
			DUNSNumber2 = "BBGIgsn1k",
			SuppliersLocationNumber = "1",
			PhysicalDeliveryOrReturnDate = "3RCIYR",
			ProductOwnershipTransferDate = "7zhuBH",
			PurchaseOrderNumber = "K",
			PurchaseOrderDate = "Nnjb9D",
			ShipmentMethodOfPayment = "x0",
			CODMethodOfPaymentCode = "D",
		};

		var actual = Map.MapObject<G82_DeliveryReturnBaseRecordIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.SuppliersDeliveryReturnNumber = "w";
		subject.DUNSNumber = "7McoZqgVd";
		subject.ReceiversLocationNumber = "I";
		subject.DUNSNumber2 = "BBGIgsn1k";
		subject.SuppliersLocationNumber = "1";
		subject.PhysicalDeliveryOrReturnDate = "3RCIYR";
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredSuppliersDeliveryReturnNumber(string suppliersDeliveryReturnNumber, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "q";
		subject.DUNSNumber = "7McoZqgVd";
		subject.ReceiversLocationNumber = "I";
		subject.DUNSNumber2 = "BBGIgsn1k";
		subject.SuppliersLocationNumber = "1";
		subject.PhysicalDeliveryOrReturnDate = "3RCIYR";
		subject.SuppliersDeliveryReturnNumber = suppliersDeliveryReturnNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7McoZqgVd", true)]
	public void Validation_RequiredDUNSNumber(string dUNSNumber, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "q";
		subject.SuppliersDeliveryReturnNumber = "w";
		subject.ReceiversLocationNumber = "I";
		subject.DUNSNumber2 = "BBGIgsn1k";
		subject.SuppliersLocationNumber = "1";
		subject.PhysicalDeliveryOrReturnDate = "3RCIYR";
		subject.DUNSNumber = dUNSNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredReceiversLocationNumber(string receiversLocationNumber, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "q";
		subject.SuppliersDeliveryReturnNumber = "w";
		subject.DUNSNumber = "7McoZqgVd";
		subject.DUNSNumber2 = "BBGIgsn1k";
		subject.SuppliersLocationNumber = "1";
		subject.PhysicalDeliveryOrReturnDate = "3RCIYR";
		subject.ReceiversLocationNumber = receiversLocationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BBGIgsn1k", true)]
	public void Validation_RequiredDUNSNumber2(string dUNSNumber2, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "q";
		subject.SuppliersDeliveryReturnNumber = "w";
		subject.DUNSNumber = "7McoZqgVd";
		subject.ReceiversLocationNumber = "I";
		subject.SuppliersLocationNumber = "1";
		subject.PhysicalDeliveryOrReturnDate = "3RCIYR";
		subject.DUNSNumber2 = dUNSNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredSuppliersLocationNumber(string suppliersLocationNumber, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "q";
		subject.SuppliersDeliveryReturnNumber = "w";
		subject.DUNSNumber = "7McoZqgVd";
		subject.ReceiversLocationNumber = "I";
		subject.DUNSNumber2 = "BBGIgsn1k";
		subject.PhysicalDeliveryOrReturnDate = "3RCIYR";
		subject.SuppliersLocationNumber = suppliersLocationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3RCIYR", true)]
	public void Validation_RequiredPhysicalDeliveryOrReturnDate(string physicalDeliveryOrReturnDate, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "q";
		subject.SuppliersDeliveryReturnNumber = "w";
		subject.DUNSNumber = "7McoZqgVd";
		subject.ReceiversLocationNumber = "I";
		subject.DUNSNumber2 = "BBGIgsn1k";
		subject.SuppliersLocationNumber = "1";
		subject.PhysicalDeliveryOrReturnDate = physicalDeliveryOrReturnDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
