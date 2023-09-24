using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.Tests.Models.v6040;

public class G82Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G82*0*o*44jfwSWgz*r*3bqYOJ3Ag*Y*1oHqyrM9*dTouo5zF*C*unrC0aI1*gI*r*O5";

		var expected = new G82_DeliveryReturnBaseRecordIdentifier()
		{
			CreditDebitFlagCode = "0",
			SuppliersDeliveryReturnNumber = "o",
			DUNSNumberCode = "44jfwSWgz",
			ReceiversLocationNumber = "r",
			DUNSNumberCode2 = "3bqYOJ3Ag",
			SuppliersLocationNumber = "Y",
			PhysicalDeliveryOrReturnDate = "1oHqyrM9",
			ProductOwnershipTransferDate = "dTouo5zF",
			PurchaseOrderNumber = "C",
			PurchaseOrderDate = "unrC0aI1",
			ShipmentMethodOfPaymentCode = "gI",
			CODMethodOfPaymentCode = "r",
			ConditionIndicatorCode = "O5",
		};

		var actual = Map.MapObject<G82_DeliveryReturnBaseRecordIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.SuppliersDeliveryReturnNumber = "o";
		subject.ReceiversLocationNumber = "r";
		subject.SuppliersLocationNumber = "Y";
		subject.PhysicalDeliveryOrReturnDate = "1oHqyrM9";
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredSuppliersDeliveryReturnNumber(string suppliersDeliveryReturnNumber, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "0";
		subject.ReceiversLocationNumber = "r";
		subject.SuppliersLocationNumber = "Y";
		subject.PhysicalDeliveryOrReturnDate = "1oHqyrM9";
		subject.SuppliersDeliveryReturnNumber = suppliersDeliveryReturnNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredReceiversLocationNumber(string receiversLocationNumber, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "0";
		subject.SuppliersDeliveryReturnNumber = "o";
		subject.SuppliersLocationNumber = "Y";
		subject.PhysicalDeliveryOrReturnDate = "1oHqyrM9";
		subject.ReceiversLocationNumber = receiversLocationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredSuppliersLocationNumber(string suppliersLocationNumber, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "0";
		subject.SuppliersDeliveryReturnNumber = "o";
		subject.ReceiversLocationNumber = "r";
		subject.PhysicalDeliveryOrReturnDate = "1oHqyrM9";
		subject.SuppliersLocationNumber = suppliersLocationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1oHqyrM9", true)]
	public void Validation_RequiredPhysicalDeliveryOrReturnDate(string physicalDeliveryOrReturnDate, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "0";
		subject.SuppliersDeliveryReturnNumber = "o";
		subject.ReceiversLocationNumber = "r";
		subject.SuppliersLocationNumber = "Y";
		subject.PhysicalDeliveryOrReturnDate = physicalDeliveryOrReturnDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
