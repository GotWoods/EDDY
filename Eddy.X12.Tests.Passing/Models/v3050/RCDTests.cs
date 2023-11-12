using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class RCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RCD*u*1*UZ*8*19*9*Hf*Fq*9*iS*a7*5*s6*W8*6*m4*GL*1*5x*AN*7";

		var expected = new RCD_ReceivingConditions()
		{
			AssignedIdentification = "u",
			QuantityUnitsReceivedOrAccepted = 1,
			UnitOrBasisForMeasurementCode = "UZ",
			QuantityUnitsReturned = 8,
			UnitOrBasisForMeasurementCode2 = "19",
			QuantityInQuestion = 9,
			UnitOrBasisForMeasurementCode3 = "Hf",
			ReceivingConditionCode = "Fq",
			QuantityInQuestion2 = 9,
			UnitOrBasisForMeasurementCode4 = "iS",
			ReceivingConditionCode2 = "a7",
			QuantityInQuestion3 = 5,
			UnitOrBasisForMeasurementCode5 = "s6",
			ReceivingConditionCode3 = "W8",
			QuantityInQuestion4 = 6,
			UnitOrBasisForMeasurementCode6 = "m4",
			ReceivingConditionCode4 = "GL",
			QuantityInQuestion5 = 1,
			UnitOrBasisForMeasurementCode7 = "5x",
			ReceivingConditionCode5 = "AN",
			Quantity = 7,
		};

		var actual = Map.MapObject<RCD_ReceivingConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "UZ", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "UZ", false)]
	public void Validation_AllAreRequiredQuantityUnitsReceivedOrAccepted(decimal quantityUnitsReceivedOrAccepted, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new RCD_ReceivingConditions();
		//Required fields
		//Test Parameters
		if (quantityUnitsReceivedOrAccepted > 0) 
			subject.QuantityUnitsReceivedOrAccepted = quantityUnitsReceivedOrAccepted;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(subject.QuantityUnitsReturned > 0 || subject.QuantityUnitsReturned > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityUnitsReturned = 8;
			subject.UnitOrBasisForMeasurementCode2 = "19";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "19", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "19", false)]
	public void Validation_AllAreRequiredQuantityUnitsReturned(decimal quantityUnitsReturned, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new RCD_ReceivingConditions();
		//Required fields
		//Test Parameters
		if (quantityUnitsReturned > 0) 
			subject.QuantityUnitsReturned = quantityUnitsReturned;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.QuantityUnitsReceivedOrAccepted > 0 || subject.QuantityUnitsReceivedOrAccepted > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.QuantityUnitsReceivedOrAccepted = 1;
			subject.UnitOrBasisForMeasurementCode = "UZ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
