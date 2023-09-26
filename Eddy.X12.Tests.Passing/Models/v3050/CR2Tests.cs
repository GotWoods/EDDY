using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class CR2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR2*9*9*2t*nX*sD*3*5*s*8*6*5*u";

		var expected = new CR2_ChiropracticCertification()
		{
			Count = 9,
			Quantity = 9,
			SubluxationLevelCode = "2t",
			SubluxationLevelCode2 = "nX",
			UnitOrBasisForMeasurementCode = "sD",
			Quantity2 = 3,
			Quantity3 = 5,
			NatureOfConditionCode = "s",
			YesNoConditionOrResponseCode = "8",
			Description = "6",
			Description2 = "5",
			YesNoConditionOrResponseCode2 = "u",
		};

		var actual = Map.MapObject<CR2_ChiropracticCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(9, 9, true)]
	[InlineData(9, 0, false)]
	[InlineData(0, 9, false)]
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
			subject.UnitOrBasisForMeasurementCode = "sD";
			subject.Quantity2 = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("nX", "2t", true)]
	[InlineData("nX", "", false)]
	[InlineData("", "2t", true)]
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
			subject.Count = 9;
			subject.Quantity = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "sD";
			subject.Quantity2 = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("sD", 3, true)]
	[InlineData("sD", 0, false)]
	[InlineData("", 3, false)]
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
			subject.Count = 9;
			subject.Quantity = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
