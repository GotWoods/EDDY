using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class CR2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR2*8*7*vi*0f*W1*8*8*6*W*V*p";

		var expected = new CR2_ChiropracticCertification()
		{
			Count = 8,
			Quantity = 7,
			SubluxationLevelCode = "vi",
			SubluxationLevelCode2 = "0f",
			UnitOrBasisForMeasurementCode = "W1",
			Quantity2 = 8,
			Quantity3 = 8,
			NatureOfConditionCode = "6",
			YesNoConditionOrResponseCode = "W",
			Description = "V",
			Description2 = "p",
		};

		var actual = Map.MapObject<CR2_ChiropracticCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(8, 7, true)]
	[InlineData(8, 0, false)]
	[InlineData(0, 7, false)]
	public void Validation_AllAreRequiredCount(int count, decimal quantity, bool isValidExpected)
	{
		var subject = new CR2_ChiropracticCertification();
		//Required fields
		//Test Parameters
		if (count > 0) 
			subject.Count = count;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "W1";
			subject.Quantity2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0f", "vi", true)]
	[InlineData("0f", "", false)]
	[InlineData("", "vi", true)]
	public void Validation_ARequiresBSubluxationLevelCode2(string subluxationLevelCode2, string subluxationLevelCode, bool isValidExpected)
	{
		var subject = new CR2_ChiropracticCertification();
		//Required fields
		//Test Parameters
		subject.SubluxationLevelCode2 = subluxationLevelCode2;
		subject.SubluxationLevelCode = subluxationLevelCode;
		//If one filled, all required
		if(subject.Count > 0 || subject.Count > 0 || subject.Quantity > 0)
		{
			subject.Count = 8;
			subject.Quantity = 7;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "W1";
			subject.Quantity2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("W1", 8, true)]
	[InlineData("W1", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity2, bool isValidExpected)
	{
		var subject = new CR2_ChiropracticCertification();
		//Required fields
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(subject.Count > 0 || subject.Count > 0 || subject.Quantity > 0)
		{
			subject.Count = 8;
			subject.Quantity = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
