using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class G87Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G87*i*2*L*b*1*Z";

		var expected = new G87_DeliveryReturnAdjustmentIdentification()
		{
			InitiatorCode = "i",
			CreditDebitFlagCode = "2",
			SuppliersDeliveryReturnNumber = "L",
			IntegrityCheckValue = "b",
			AdjustmentSequenceNumber = 1,
			ReceiverDeliveryReturnNumber = "Z",
		};

		var actual = Map.MapObject<G87_DeliveryReturnAdjustmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredInitiatorCode(string initiatorCode, bool isValidExpected)
	{
		var subject = new G87_DeliveryReturnAdjustmentIdentification();
		subject.CreditDebitFlagCode = "2";
		subject.SuppliersDeliveryReturnNumber = "L";
		subject.IntegrityCheckValue = "b";
		subject.AdjustmentSequenceNumber = 1;
		subject.InitiatorCode = initiatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new G87_DeliveryReturnAdjustmentIdentification();
		subject.InitiatorCode = "i";
		subject.SuppliersDeliveryReturnNumber = "L";
		subject.IntegrityCheckValue = "b";
		subject.AdjustmentSequenceNumber = 1;
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredSuppliersDeliveryReturnNumber(string suppliersDeliveryReturnNumber, bool isValidExpected)
	{
		var subject = new G87_DeliveryReturnAdjustmentIdentification();
		subject.InitiatorCode = "i";
		subject.CreditDebitFlagCode = "2";
		subject.IntegrityCheckValue = "b";
		subject.AdjustmentSequenceNumber = 1;
		subject.SuppliersDeliveryReturnNumber = suppliersDeliveryReturnNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredIntegrityCheckValue(string integrityCheckValue, bool isValidExpected)
	{
		var subject = new G87_DeliveryReturnAdjustmentIdentification();
		subject.InitiatorCode = "i";
		subject.CreditDebitFlagCode = "2";
		subject.SuppliersDeliveryReturnNumber = "L";
		subject.AdjustmentSequenceNumber = 1;
		subject.IntegrityCheckValue = integrityCheckValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredAdjustmentSequenceNumber(int adjustmentSequenceNumber, bool isValidExpected)
	{
		var subject = new G87_DeliveryReturnAdjustmentIdentification();
		subject.InitiatorCode = "i";
		subject.CreditDebitFlagCode = "2";
		subject.SuppliersDeliveryReturnNumber = "L";
		subject.IntegrityCheckValue = "b";
		if (adjustmentSequenceNumber > 0)
			subject.AdjustmentSequenceNumber = adjustmentSequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
