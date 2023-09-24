using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FX7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FX7*F*7U*3*xs*2*2*wo*9*C";

		var expected = new FX7_PackAndSize()
		{
			YesNoConditionOrResponseCode = "F",
			QuantityQualifier = "7U",
			Quantity = 3,
			UnitOrBasisForMeasurementCode = "xs",
			Pack = 2,
			InnerPack = 2,
			UnitOrBasisForMeasurementCode2 = "wo",
			Size = 9,
			Description = "C",
		};

		var actual = Map.MapObject<FX7_PackAndSize>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new FX7_PackAndSize();
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("wo", 9, true)]
	[InlineData("", 9, false)]
	[InlineData("wo", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal size, bool isValidExpected)
	{
		var subject = new FX7_PackAndSize();
		subject.YesNoConditionOrResponseCode = "F";
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (size > 0)
		subject.Size = size;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
