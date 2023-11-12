using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.Tests.Models.v5020;

public class G82Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G82*L*5*fzLBwW8KJ*F*11kaxzRxY*G*ElPtZR7y*GVAtnFfy*n*jRf35HC3*Xr*9";

		var expected = new G82_DeliveryReturnBaseRecordIdentifier()
		{
			CreditDebitFlagCode = "L",
			SuppliersDeliveryReturnNumber = "5",
			DUNSNumber = "fzLBwW8KJ",
			ReceiversLocationNumber = "F",
			DUNSNumber2 = "11kaxzRxY",
			SuppliersLocationNumber = "G",
			PhysicalDeliveryOrReturnDate = "ElPtZR7y",
			ProductOwnershipTransferDate = "GVAtnFfy",
			PurchaseOrderNumber = "n",
			PurchaseOrderDate = "jRf35HC3",
			ShipmentMethodOfPayment = "Xr",
			CODMethodOfPaymentCode = "9",
		};

		var actual = Map.MapObject<G82_DeliveryReturnBaseRecordIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.SuppliersDeliveryReturnNumber = "5";
		subject.ReceiversLocationNumber = "F";
		subject.SuppliersLocationNumber = "G";
		subject.PhysicalDeliveryOrReturnDate = "ElPtZR7y";
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredSuppliersDeliveryReturnNumber(string suppliersDeliveryReturnNumber, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "L";
		subject.ReceiversLocationNumber = "F";
		subject.SuppliersLocationNumber = "G";
		subject.PhysicalDeliveryOrReturnDate = "ElPtZR7y";
		subject.SuppliersDeliveryReturnNumber = suppliersDeliveryReturnNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredReceiversLocationNumber(string receiversLocationNumber, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "L";
		subject.SuppliersDeliveryReturnNumber = "5";
		subject.SuppliersLocationNumber = "G";
		subject.PhysicalDeliveryOrReturnDate = "ElPtZR7y";
		subject.ReceiversLocationNumber = receiversLocationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredSuppliersLocationNumber(string suppliersLocationNumber, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "L";
		subject.SuppliersDeliveryReturnNumber = "5";
		subject.ReceiversLocationNumber = "F";
		subject.PhysicalDeliveryOrReturnDate = "ElPtZR7y";
		subject.SuppliersLocationNumber = suppliersLocationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ElPtZR7y", true)]
	public void Validation_RequiredPhysicalDeliveryOrReturnDate(string physicalDeliveryOrReturnDate, bool isValidExpected)
	{
		var subject = new G82_DeliveryReturnBaseRecordIdentifier();
		subject.CreditDebitFlagCode = "L";
		subject.SuppliersDeliveryReturnNumber = "5";
		subject.ReceiversLocationNumber = "F";
		subject.SuppliersLocationNumber = "G";
		subject.PhysicalDeliveryOrReturnDate = physicalDeliveryOrReturnDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
