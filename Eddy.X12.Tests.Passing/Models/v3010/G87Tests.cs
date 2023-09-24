using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G87Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G87*G*U*S*v*1*J";

		var expected = new G87_DeliveryReturnAdjustmentIdentification()
		{
			InitiatorCode = "G",
			CreditDebitFlagCode = "U",
			SuppliersDeliveryReturnNumber = "S",
			IntegrityCheckValue = "v",
			AdjustmentNumber = 1,
			ReceiverDeliveryReturnNumber = "J",
		};

		var actual = Map.MapObject<G87_DeliveryReturnAdjustmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredInitiatorCode(string initiatorCode, bool isValidExpected)
	{
		var subject = new G87_DeliveryReturnAdjustmentIdentification();
		subject.CreditDebitFlagCode = "U";
		subject.SuppliersDeliveryReturnNumber = "S";
		subject.IntegrityCheckValue = "v";
		subject.AdjustmentNumber = 1;
		subject.InitiatorCode = initiatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new G87_DeliveryReturnAdjustmentIdentification();
		subject.InitiatorCode = "G";
		subject.SuppliersDeliveryReturnNumber = "S";
		subject.IntegrityCheckValue = "v";
		subject.AdjustmentNumber = 1;
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredSuppliersDeliveryReturnNumber(string suppliersDeliveryReturnNumber, bool isValidExpected)
	{
		var subject = new G87_DeliveryReturnAdjustmentIdentification();
		subject.InitiatorCode = "G";
		subject.CreditDebitFlagCode = "U";
		subject.IntegrityCheckValue = "v";
		subject.AdjustmentNumber = 1;
		subject.SuppliersDeliveryReturnNumber = suppliersDeliveryReturnNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredIntegrityCheckValue(string integrityCheckValue, bool isValidExpected)
	{
		var subject = new G87_DeliveryReturnAdjustmentIdentification();
		subject.InitiatorCode = "G";
		subject.CreditDebitFlagCode = "U";
		subject.SuppliersDeliveryReturnNumber = "S";
		subject.AdjustmentNumber = 1;
		subject.IntegrityCheckValue = integrityCheckValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredAdjustmentNumber(int adjustmentNumber, bool isValidExpected)
	{
		var subject = new G87_DeliveryReturnAdjustmentIdentification();
		subject.InitiatorCode = "G";
		subject.CreditDebitFlagCode = "U";
		subject.SuppliersDeliveryReturnNumber = "S";
		subject.IntegrityCheckValue = "v";
		if (adjustmentNumber > 0)
			subject.AdjustmentNumber = adjustmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
