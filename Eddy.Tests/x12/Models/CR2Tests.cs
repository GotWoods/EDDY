using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CR2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR2*1*5*Xo*ay*Yl*8*6*D*F*4*H*0";

		var expected = new CR2_ChiropracticCertification()
		{
			Count = 1,
			Quantity = 5,
			SubluxationLevelCode = "Xo",
			SubluxationLevelCode2 = "ay",
			UnitOrBasisForMeasurementCode = "Yl",
			Quantity2 = 8,
			Quantity3 = 6,
			NatureOfConditionCode = "D",
			YesNoConditionOrResponseCode = "F",
			Description = "4",
			Description2 = "H",
			YesNoConditionOrResponseCode2 = "0",
		};

		var actual = Map.MapObject<CR2_ChiropracticCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0,0, true)]
	[InlineData(1, 5, true)]
	[InlineData(0, 5, false)]
	[InlineData(1, 0, false)]
	public void Validation_AllAreRequiredCount(int count, decimal quantity, bool isValidExpected)
	{
		var subject = new CR2_ChiropracticCertification();
		if (count > 0)
		subject.Count = count;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "Xo", true)]
	[InlineData("ay", "", false)]
	public void Validation_ARequiresBSubluxationLevelCode2(string subluxationLevelCode2, string subluxationLevelCode, bool isValidExpected)
	{
		var subject = new CR2_ChiropracticCertification();
		subject.SubluxationLevelCode2 = subluxationLevelCode2;
		subject.SubluxationLevelCode = subluxationLevelCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("Yl", 8, true)]
	[InlineData("", 8, false)]
	[InlineData("Yl", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity2, bool isValidExpected)
	{
		var subject = new CR2_ChiropracticCertification();
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity2 > 0)
		subject.Quantity2 = quantity2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
