using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class FX7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FX7*4*GK*3*wN*5*6*CE*5*0";

		var expected = new FX7_PackAndSize()
		{
			YesNoConditionOrResponseCode = "4",
			QuantityQualifier = "GK",
			Quantity = 3,
			UnitOrBasisForMeasurementCode = "wN",
			Pack = 5,
			InnerPack = 6,
			UnitOrBasisForMeasurementCode2 = "CE",
			Size = 5,
			Description = "0",
		};

		var actual = Map.MapObject<FX7_PackAndSize>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new FX7_PackAndSize();
		//Required fields
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Size > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "CE";
			subject.Size = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("CE", 5, true)]
	[InlineData("CE", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal size, bool isValidExpected)
	{
		var subject = new FX7_PackAndSize();
		//Required fields
		subject.YesNoConditionOrResponseCode = "4";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (size > 0) 
			subject.Size = size;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
