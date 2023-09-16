using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class TD3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TD3*kp*q*S*2*7*Jr*Y*Cg*dY*v8bs";

		var expected = new TD3_CarrierDetailsEquipment()
		{
			EquipmentDescriptionCode = "kp",
			EquipmentInitial = "q",
			EquipmentNumber = "S",
			WeightQualifier = "2",
			Weight = 7,
			UnitOrBasisForMeasurementCode = "Jr",
			OwnershipCode = "Y",
			SealStatusCode = "Cg",
			SealNumber = "dY",
			EquipmentType = "v8bs",
		};

		var actual = Map.MapObject<TD3_CarrierDetailsEquipment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("kp", "v8bs", false)]
	[InlineData("kp", "", true)]
	[InlineData("", "v8bs", true)]
	public void Validation_OnlyOneOfEquipmentDescriptionCode(string equipmentDescriptionCode, string equipmentType, bool isValidExpected)
	{
		var subject = new TD3_CarrierDetailsEquipment();
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		subject.EquipmentType = equipmentType;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Weight = 7;
			subject.UnitOrBasisForMeasurementCode = "Jr";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("q", "S", true)]
	[InlineData("q", "", false)]
	[InlineData("", "S", true)]
	public void Validation_ARequiresBEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new TD3_CarrierDetailsEquipment();
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Weight = 7;
			subject.UnitOrBasisForMeasurementCode = "Jr";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("2", 7, true)]
	[InlineData("2", 0, false)]
	[InlineData("", 7, true)]
	public void Validation_ARequiresBWeightQualifier(string weightQualifier, decimal weight, bool isValidExpected)
	{
		var subject = new TD3_CarrierDetailsEquipment();
		subject.WeightQualifier = weightQualifier;
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Weight = 7;
			subject.UnitOrBasisForMeasurementCode = "Jr";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "Jr", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "Jr", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new TD3_CarrierDetailsEquipment();
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
