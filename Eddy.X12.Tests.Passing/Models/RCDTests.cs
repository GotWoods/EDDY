using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class RCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RCD*G*9**4**4**OD*5**UU*1**Ss*4**3g*5**Za*9";

		var expected = new RCD_ReceivingConditions()
		{
			AssignedIdentification = "G",
			QuantityUnitsReceivedOrAccepted = 9,
			CompositeUnitOfMeasure = null,
			QuantityUnitsReturned = 4,
			CompositeUnitOfMeasure2 = null,
			QuantityInQuestion = 4,
			CompositeUnitOfMeasure3 = null,
			ReceivingConditionCode = "OD",
			QuantityInQuestion2 = 5,
			CompositeUnitOfMeasure4 = null,
			ReceivingConditionCode2 = "UU",
			QuantityInQuestion3 = 1,
			CompositeUnitOfMeasure5 = null,
			ReceivingConditionCode3 = "Ss",
			QuantityInQuestion4 = 4,
			CompositeUnitOfMeasure6 = null,
			ReceivingConditionCode4 = "3g",
			QuantityInQuestion5 = 5,
			CompositeUnitOfMeasure7 = null,
			ReceivingConditionCode5 = "Za",
			Quantity = 9,
		};

		var actual = Map.MapObject<RCD_ReceivingConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(9, "AA", true)]
	[InlineData(0, "AA", false)]
	[InlineData(9, "", false)]
	public void Validation_AllAreRequiredQuantityUnitsReceivedOrAccepted(decimal quantityUnitsReceivedOrAccepted, string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new RCD_ReceivingConditions();
		if (quantityUnitsReceivedOrAccepted > 0)
		subject.QuantityUnitsReceivedOrAccepted = quantityUnitsReceivedOrAccepted;
        if (compositeUnitOfMeasure != "")
            subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure() { UnitOrBasisForMeasurementCode = compositeUnitOfMeasure };

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(4, "AA", true)]
	[InlineData(0, "AA", false)]
	[InlineData(4, "", false)]
	public void Validation_AllAreRequiredQuantityUnitsReturned(decimal quantityUnitsReturned, string compositeUnitOfMeasure2, bool isValidExpected)
	{
		var subject = new RCD_ReceivingConditions();
		if (quantityUnitsReturned > 0)
		subject.QuantityUnitsReturned = quantityUnitsReturned;
        if (compositeUnitOfMeasure2 != "")
            subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure() { UnitOrBasisForMeasurementCode = compositeUnitOfMeasure2};

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
