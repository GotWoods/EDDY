using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.Tests.Models.v8010;

public class TD3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TD3*XG*7*7*v*1*KX*W*YP*D*OPC6";

		var expected = new TD3_CarrierDetailsEquipment()
		{
			EquipmentDescriptionCode = "XG",
			EquipmentInitial = "7",
			EquipmentNumber = "7",
			WeightQualifier = "v",
			Weight = 1,
			UnitOrBasisForMeasurementCode = "KX",
			OwnershipCode = "W",
			SealStatusCode = "YP",
			SealNumber = "D",
			EquipmentTypeCode = "OPC6",
		};

		var actual = Map.MapObject<TD3_CarrierDetailsEquipment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("XG", "OPC6", false)]
	[InlineData("XG", "", true)]
	[InlineData("", "OPC6", true)]
	public void Validation_OnlyOneOfEquipmentDescriptionCode(string equipmentDescriptionCode, string equipmentTypeCode, bool isValidExpected)
	{
		var subject = new TD3_CarrierDetailsEquipment();
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		subject.EquipmentTypeCode = equipmentTypeCode;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode = "KX";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7", "7", true)]
	[InlineData("7", "", false)]
	[InlineData("", "7", true)]
	public void Validation_ARequiresBEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new TD3_CarrierDetailsEquipment();
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode = "KX";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("v", 1, true)]
	[InlineData("v", 0, false)]
	[InlineData("", 1, true)]
	public void Validation_ARequiresBWeightQualifier(string weightQualifier, decimal weight, bool isValidExpected)
	{
		var subject = new TD3_CarrierDetailsEquipment();
		subject.WeightQualifier = weightQualifier;
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode = "KX";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "KX", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "KX", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new TD3_CarrierDetailsEquipment();
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
