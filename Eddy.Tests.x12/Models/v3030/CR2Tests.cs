using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CR2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR2*2*1*qX*Nt*I5*7*5*E*Z*Z*l";

		var expected = new CR2_ChiropracticCertification()
		{
			Count = 2,
			Quantity = 1,
			SubluxationLevelCode = "qX",
			SubluxationLevelCode2 = "Nt",
			UnitOrBasisForMeasurementCode = "I5",
			Quantity2 = 7,
			Quantity3 = 5,
			NatureOfConditionCode = "E",
			YesNoConditionOrResponseCode = "Z",
			Description = "Z",
			Description2 = "l",
		};

		var actual = Map.MapObject<CR2_ChiropracticCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(2, 1, true)]
	[InlineData(2, 0, false)]
	[InlineData(0, 1, false)]
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
			subject.UnitOrBasisForMeasurementCode = "I5";
			subject.Quantity2 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Nt", "qX", true)]
	[InlineData("Nt", "", false)]
	[InlineData("", "qX", true)]
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
			subject.Count = 2;
			subject.Quantity = 1;
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "I5";
			subject.Quantity2 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("I5", 7, true)]
	[InlineData("I5", 0, false)]
	[InlineData("", 7, false)]
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
			subject.Count = 2;
			subject.Quantity = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
