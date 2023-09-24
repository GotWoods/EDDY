using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class RCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RCD*5*4*uZ*6*44*1*wR*Ox*7*0c*Y7*3*HK*1A*8*zx*SH*1*O5*sQ*6";

		var expected = new RCD_ReceivingConditions()
		{
			AssignedIdentification = "5",
			QuantityUnitsReceivedOrAccepted = 4,
			UnitOrBasisForMeasurementCode = "uZ",
			QuantityUnitsReturned = 6,
			UnitOrBasisForMeasurementCode2 = "44",
			QuantityInQuestion = 1,
			UnitOrBasisForMeasurementCode3 = "wR",
			ReceivingConditionCode = "Ox",
			QuantityInQuestion2 = 7,
			UnitOrBasisForMeasurementCode4 = "0c",
			ReceivingConditionCode2 = "Y7",
			QuantityInQuestion3 = 3,
			UnitOrBasisForMeasurementCode5 = "HK",
			ReceivingConditionCode3 = "1A",
			QuantityInQuestion4 = 8,
			UnitOrBasisForMeasurementCode6 = "zx",
			ReceivingConditionCode4 = "SH",
			QuantityInQuestion5 = 1,
			UnitOrBasisForMeasurementCode7 = "O5",
			ReceivingConditionCode5 = "sQ",
			Quantity = 6,
		};

		var actual = Map.MapObject<RCD_ReceivingConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "uZ", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "uZ", true)]
	public void Validation_ARequiresBQuantityUnitsReceivedOrAccepted(decimal quantityUnitsReceivedOrAccepted, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new RCD_ReceivingConditions();
		//Required fields
		//Test Parameters
		if (quantityUnitsReceivedOrAccepted > 0) 
			subject.QuantityUnitsReceivedOrAccepted = quantityUnitsReceivedOrAccepted;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "44", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "44", true)]
	public void Validation_ARequiresBQuantityUnitsReturned(decimal quantityUnitsReturned, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new RCD_ReceivingConditions();
		//Required fields
		//Test Parameters
		if (quantityUnitsReturned > 0) 
			subject.QuantityUnitsReturned = quantityUnitsReturned;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
