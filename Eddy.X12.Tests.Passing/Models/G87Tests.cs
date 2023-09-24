using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G87Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G87*v*i*6*V*2*5";

		var expected = new G87_DeliveryReturnAdjustmentIdentification()
		{
			InitiatorCode = "v",
			CreditDebitFlagCode = "i",
			SuppliersDeliveryReturnNumber = "6",
			IntegrityCheckValue = "V",
			AdjustmentSequenceNumber = 2,
			ReceiverDeliveryReturnNumber = "5",
		};

		var actual = Map.MapObject<G87_DeliveryReturnAdjustmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredInitiatorCode(string initiatorCode, bool isValidExpected)
	{
		var subject = new G87_DeliveryReturnAdjustmentIdentification();
		subject.CreditDebitFlagCode = "i";
		subject.SuppliersDeliveryReturnNumber = "6";
		subject.IntegrityCheckValue = "V";
		subject.AdjustmentSequenceNumber = 2;
		subject.InitiatorCode = initiatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new G87_DeliveryReturnAdjustmentIdentification();
		subject.InitiatorCode = "v";
		subject.SuppliersDeliveryReturnNumber = "6";
		subject.IntegrityCheckValue = "V";
		subject.AdjustmentSequenceNumber = 2;
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredSuppliersDeliveryReturnNumber(string suppliersDeliveryReturnNumber, bool isValidExpected)
	{
		var subject = new G87_DeliveryReturnAdjustmentIdentification();
		subject.InitiatorCode = "v";
		subject.CreditDebitFlagCode = "i";
		subject.IntegrityCheckValue = "V";
		subject.AdjustmentSequenceNumber = 2;
		subject.SuppliersDeliveryReturnNumber = suppliersDeliveryReturnNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredIntegrityCheckValue(string integrityCheckValue, bool isValidExpected)
	{
		var subject = new G87_DeliveryReturnAdjustmentIdentification();
		subject.InitiatorCode = "v";
		subject.CreditDebitFlagCode = "i";
		subject.SuppliersDeliveryReturnNumber = "6";
		subject.AdjustmentSequenceNumber = 2;
		subject.IntegrityCheckValue = integrityCheckValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredAdjustmentSequenceNumber(int adjustmentSequenceNumber, bool isValidExpected)
	{
		var subject = new G87_DeliveryReturnAdjustmentIdentification();
		subject.InitiatorCode = "v";
		subject.CreditDebitFlagCode = "i";
		subject.SuppliersDeliveryReturnNumber = "6";
		subject.IntegrityCheckValue = "V";
		if (adjustmentSequenceNumber > 0)
		subject.AdjustmentSequenceNumber = adjustmentSequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
